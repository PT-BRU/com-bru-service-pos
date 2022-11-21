using Com.Danliris.Service.Inventory.Lib;
using Com.Danliris.Service.Inventory.Lib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels;
using System.Data.SqlClient;

namespace Com.Bateeq.Service.Pos.Lib.Services.BateeqshopService.VoucherServices
{
    public class VoucherService : IVoucherService
    {
        private const string UserAgent = "voucher-service";

        public IIdentityService IdentityService;
        public readonly IServiceProvider ServiceProvider;
        public PosDbContext DbContext;
        public VoucherService(IServiceProvider serviceProvider, PosDbContext dbContext)
        {
            DbContext = dbContext;
            ServiceProvider = serviceProvider;

            IdentityService = serviceProvider.GetService<IIdentityService>();

        }
        public IQueryable<VoucherViewModel> Read(DateTime startDate, DateTime endDate, string voucherType, string code, string name, string keyword)
        {
            SqlConnection conn = new SqlConnection("Server=com-bateeqefrata-sqlserver.database.windows.net;Database=com-bateeqshop-db-voucher;User=adminPrd@com-bateeqefrata-sqlserver;password=Standar123.;Trusted_Connection=False;MultipleActiveResultSets=true");
            conn.Open();
            string _type = String.IsNullOrEmpty(voucherType) ? "" : voucherType;
            string _name = String.IsNullOrEmpty(name) ? "" : name;
            string _code = String.IsNullOrEmpty(code) ? "" : code;
            string _keyword = String.IsNullOrEmpty(keyword) ? "" : keyword;
            DateTime _dateFrom = startDate==null || startDate.Year==1 ? DateTime.MinValue.Date : startDate;
            DateTime _dateTo = endDate == null && endDate.Year == 1 ? DateTime.MaxValue.Date : endDate;
            SqlCommand command = new SqlCommand(
                "	SELECT isnull(q.Id, 0) as VoucherId , isnull(q.code, NULL) as VoucherName, q.Type as vType	" +
                "		, isnull(percentages.Id, 0) as PId, isnull(percentages.name, NULL) as percentagesname, isnull(percentages.ExpiredDate, NULL) as pExpDate, isnull(percentages.StartDate, NULL) as pStartDate, isnull(percentages.MaxQty, NULL) as pMaxQty, isnull(percentages.LastModifiedUtc, NULL) as pLastModifiedUtc						" +
                "		, isnull(nominals.Id, 0) as NId  , isnull(nominals.name, NULL) as nominalsname, isnull(nominals.ExpiredDate, NULL) as nominalsExpDate, isnull(nominals.StartDate, NULL) as nominalsStartDate, isnull(nominals.MaxQty, NULL) as nominalsMaxQty, isnull(nominals.LastModifiedUtc, NULL) as nominalsLastModifiedUtc			" +
                "		, isnull(products.Id, 0) as productsId, isnull(products.name, NULL) as productsname, isnull(products.ExpiredDate, NULL) as productsExpDate, isnull(products.StartDate, NULL) as productsStartDate, null as productsMaxQty, isnull( products.LastModifiedUtc, NULL) as  productsLastModifiedUtc	" +
                "		, isnull(type1.Id, 0) as type1Id, isnull(type1.name, NULL) as type1name, isnull(type1.ExpiredDate, NULL) as type1ExpDate, isnull(type1.StartDate, NULL) as type1StartDate, isnull(type1.MaxQty, NULL) as type1MaxQty, isnull(type1.LastModifiedUtc, NULL) as type1LastModifiedUtc			" +
                "		, isnull(type2categ1s.Id, 0) as type2categ1sId, isnull(type2categ1s.name, NULL) as type2categ1sname, isnull(type2categ1s.ExpiredDate, NULL) as type2categ1sExpDate, isnull(type2categ1s.StartDate, NULL) as type2categ1sStartDate, isnull(type2categ1s.MaxQty, NULL) as type2categ1sMaxQty, isnull(type2categ1s.LastModifiedUtc, NULL) as type2categ1sLastModifiedUtc		" +
                "		, isnull(type3s.Id, 0) as type3sId, isnull(type3s.name, NULL) as type3sname, isnull(type3s.ExpiredDate, NULL) as type3sExpDate, isnull(type3s.StartDate, NULL) as type3sStartDate, isnull(type3s.MaxQty, NULL) as type3sMaxQty, isnull(type3s.LastModifiedUtc, NULL) as type3sLastModifiedUtc		" +
                "		, isnull(type4s.Id, 0) as type4sId, isnull(type4s.name, NULL) as type4sname, isnull(type4s.ExpiredDate, NULL) as type4sExpDate, isnull(type4s.StartDate, NULL) as type4sStartDate, isnull(type4s.MaxQty, NULL) as type4sMaxQty, isnull(type4s.LastModifiedUtc, NULL) as type4sLastModifiedUtc		" +
                "		, isnull(type2products.Id, 0) as type2productsId, isnull(type2products.name, NULL) as type2productsName, isnull(type2products.ExpiredDate, NULL) as type2productsExpDate, isnull(type2products.StartDate, NULL) as type2productsStartDate, isnull(type2products.MaxQty, NULL) as type2productsMaxQty, isnull(type2products.LastModifiedUtc, NULL) as type2productsLastModifiedUtc	" +
                "	into #temp																		" +
                "	FROM [dbo].[Vouchers] q 														" +
                "	  left join VoucherPercentages percentages on q.TypeId= percentages.Id 			" +
                "	  left join VoucherNominals nominals on q.TypeId= nominals.Id					" +
                "	  left join VoucherProducts products on q.TypeId= products.Id					" +
                "	  left join VoucherType1s type1 on q.TypeId= type1.Id							" +
                "	  left join VoucherType2Categories type2categ1s on q.TypeId= type2categ1s.Id	" +
                "	  left join VoucherType2Products type2products on q.TypeId= type2products.Id	" +
                "	  left join VoucherType3s type3s on q.TypeId= type3s.Id							" +
                "	  left join VoucherType4s type4s on q.TypeId= type4s.Id							" +
                "	  where q.IsDeleted=0 and q.code is not null 									" +
                "	  order by q.LastModifiedUtc desc												" +
                "																					" +
                "	  SELECT Count(VoucherId) as count, VoucherId into #temp1						" +
                "	  FROM [dbo].[UserVouchers] where IsDeleted=0  group by VoucherId				" +
                "																					" +
                "	  select a.voucherId, isnull(b.Count,0) as UseCount	,vType	, a.VoucherName					" +
                "		, (case when percentagesname is not null and vType=1  then  percentagesname	" +
                "			  when nominalsname is not null and vType=0 then nominalsname			" +
                "			  when type4sname is not null and vType=7 then type4sname				" +
                "			  when type1name is not null and vType=3 then type1name					" +
                "			  when type2categ1sname is not null and vType=4 then type2categ1sname	" +
                "			  when type2productsname is not null and vType=5 then type2productsname	" +
                "			  when type3sname is not null and vType=6 then type3sname				" +
                "			  else  productsname end ) as name										" +
                "		,(case when percentagesname is not null and vType=1 then  'percentage' 	" +
                "			  when nominalsname is not null and vType=0 then 'nominal'				" +
                "			  when type4sname is not null and vType=7 then 'pay nominal rp.xx, free 1 product'	" +
                "			  when type1name is not null and vType=3 then 'Buy n free m'					" +
                "			  when type2categ1sname is not null and vType=4 then 'Buy n discount m%'		" +
                "			  when type2productsname is not null and vType=5 then 'Buy n discount m%'			" +
                "			  when type3sname is not null and vType=6 then 'buy n discount m% product (n)th'	" +
                "			  else  'product' end ) as type													" +
                "		 ,(case when percentagesname is not null and vType=1  then  pStartDate				" +
                "			  when nominalsname is not null and vType=0 then nominalsStartDate				" +
                "			  when type4sname is not null and vType=7 then type4sStartDate					" +
                "			  when type1name is not null and vType=3 then type1StartDate					" +
                "			  when type2categ1sname is not null and vType=4 then type2categ1sStartDate		" +
                "			  when type2productsname is not null and vType=5 then type2productsStartDate	" +
                "			  when type3sname is not null and vType=6 then type3sStartDate					" +
                "			  else  productsStartDate end ) as startDate									" +
                "		,(case when percentagesname is not null and vType=1  then  pExpDate					" +
                "			  when nominalsname is not null and vType=0 then nominalsExpDate				" +
                "			  when type4sname is not null and vType=7 then type4sExpDate					" +
                "			  when type1name is not null and vType=3 then type1ExpDate						" +
                "			  when type2categ1sname is not null and vType=4 then type2categ1sExpDate		" +
                "			  when type2productsname is not null and vType=5 then type2productsExpDate		" +
                "			  when type3sname is not null and vType=6 then type3sExpDate					" +
                "			  else  productsStartDate end ) as endDate										" +
                "		,(case when percentagesname is not null and vType=1  then  pMaxQty					" +
                "			  when nominalsname is not null and vType=0 then nominalsMaxQty					" +
                "			  when type4sname is not null and vType=7 then type4sMaxQty						" +
                "			  when type1name is not null and vType=3 then type1MaxQty						" +
                "			  when type2categ1sname is not null and vType=4 then type2categ1sMaxQty			" +
                "			  when type2productsname is not null and vType=5 then type2productsMaxQty		" +
                "			  when type3sname is not null and vType=6 then type3sMaxQty		" +
                "			  else  productsMaxQty end ) as MaxQty			" +
                "		,(case when percentagesname is not null and vType=1 and pStartDate<= GETDATE() and pExpDate >= GETDATE() and isnull(b.Count,0) <pMaxQty then  1			" +
                "			  when nominalsname is not null and vType=0 and	nominalsStartDate		<= GETDATE()	and	nominalsExpDate	>= GETDATE() and isnull(b.Count,0) <nominalsMaxQty then 1			" +
                "			  when type4sname is not null and vType=7 and	type4sStartDate		<= GETDATE()	and	type4sExpDate	>= GETDATE() and isnull(b.Count,0) <type4sMaxQty then 1		" +
                "			  when type1name is not null and vType=3 and	type1StartDate		<= GETDATE()	and	type1ExpDate	>= GETDATE() and isnull(b.Count,0) <type1MaxQty then 1		" +
                "			  when type2categ1sname is not null and vType=4 and	type2categ1sStartDate		<= GETDATE()	and	type2categ1sExpDate	>= GETDATE() and isnull(b.Count,0) <type2categ1sMaxQty then 1				" +
                "			  when type2productsname is not null and vType=5 and	type2productsStartDate		<= GETDATE()	and	type2productsExpDate	>= GETDATE() and isnull(b.Count,0) <type2productsMaxQty then 1		" +
                "			  when type3sname is not null and vType=6 and	type3sStartDate		<= GETDATE()	and	type3sExpDate	>= GETDATE() and isnull(b.Count,0) <type3sMaxQty then 1				" +
                "			  else  0 end ) as active	" +
                "		,(case when percentagesname is not null and vType=1  then  pLastModifiedUtc				" +
                "			  when nominalsname is not null and vType=0 then nominalsLastModifiedUtc			" +
                "			  when type4sname is not null and vType=7 then type4sLastModifiedUtc				" +
                "			  when type1name is not null and vType=3 then type1LastModifiedUtc					" +
                "			  when type2categ1sname is not null and vType=4 then type2categ1sLastModifiedUtc	" +
                "			  when type2productsname is not null and vType=5 then type2productsLastModifiedUtc	" +
                "			  when type3sname is not null and vType=6 then type3sLastModifiedUtc			" +
                "			  else  productsLastModifiedUtc end ) as ModifiedDate	" +
                "	  from  #temp a	 " +
                "	  left join #temp1 b on a.VoucherId= b.VoucherId	", conn);
                //"where u.IsDeleted = 0 and name like '%" + _name + "%'" +
                //"and  code like '%" + _code + " %' and type like '%" + _type + " %'" +
                //" and startDate between '" + _dateFrom + "' and '" + _dateTo + "'  and type like '%" + _type + "%'", conn);
            List<VoucherViewModel> viewModels = new List<VoucherViewModel>();
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    VoucherViewModel voucher = new VoucherViewModel
                    {
                        id = Convert.ToInt32(reader["voucherId"]),
                        DiscountName = reader["name"].ToString(),
                        DiscountType = reader["type"].ToString(),
                        StartDate = (Convert.ToDateTime(reader["startDate"])).ToString("yyyy-MM-dd"),
                        EndDate = (Convert.ToDateTime(reader["endDate"])).ToString("yyyy-MM-dd"),
                        TotalUse = Convert.ToInt32(reader["UseCount"]),
                        Status = Convert.ToBoolean(reader["active"]) ? "Not Active" : "Active",
                        ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]),
                        DiscountCode= reader["VoucherName"].ToString(),
                        TypeCode= reader["vType"].ToString(),
                    };
                    viewModels.Add(voucher);
                }
            }
            conn.Close();

            var data = viewModels.AsQueryable();
            if (!string.IsNullOrEmpty(_keyword))
            {
                data = data.Where(a => a.DiscountName.Contains(_keyword) || a.DiscountCode.Contains(_keyword) || a.DiscountType.Contains(_keyword));
            }
            if (_dateFrom.Year > 1)
            {
                data = data.Where(a => Convert.ToDateTime(a.StartDate) >= _dateFrom);
            }
            if (!string.IsNullOrEmpty(_name))
            {
                data = data.Where(a => a.DiscountName.Contains(_name));
            }
            if (_dateTo.Year > 1)
            {
                data = data.Where(a => Convert.ToDateTime(a.EndDate) <= _dateTo);
            }
            if (!string.IsNullOrEmpty(_type))
            {
                data = data.Where(a => a.TypeCode.Contains(_type));
            }
            if (!string.IsNullOrEmpty(_code))
            {
                data = data.Where(a => a.DiscountCode.Contains(_code));
            }

            return data.OrderByDescending(a => a.ModifiedDate);
        }
    }
}
