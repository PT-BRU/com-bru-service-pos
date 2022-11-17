using Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels;
using Com.Danliris.Service.Inventory.Lib;
using Com.Danliris.Service.Inventory.Lib.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient; 
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Data;
using Com.Danliris.Service.Inventory.Lib.Helpers;

namespace Com.Bateeq.Service.Pos.Lib.Services.BateeqshopService
{
   public class CustomerService : ICustomerService
    {
        private const string UserAgent = "discount-service";
      
        public IIdentityService IdentityService;
        public readonly IServiceProvider ServiceProvider;
        public PosDbContext DbContext;
        public CustomerService(IServiceProvider serviceProvider, PosDbContext dbContext)
        {
            DbContext = dbContext;
            ServiceProvider = serviceProvider;
           
            IdentityService = serviceProvider.GetService<IIdentityService>();

        }
        public IQueryable<CustomerViewModel> Read(string email, string name, string phoneNumber, string dobFrom, string dobTo, string membershipTier)
        {
            SqlConnection conn = new SqlConnection("Server=com-bateeqefrata-sqlserver.database.windows.net;Database=com-bateeqshop-db-auth;User=adminPrd@com-bateeqefrata-sqlserver;password=Standar123.;Trusted_Connection=False;MultipleActiveResultSets=true");
            conn.Open();
            string _email = String.IsNullOrEmpty(email) ? "" : email;
            string _name = String.IsNullOrEmpty(name) ? "" : name;
            string _phoneNumber = String.IsNullOrEmpty(phoneNumber) ? "" : phoneNumber;
            string _dobFrom = String.IsNullOrEmpty(dobFrom) ?  DateTime.MinValue.Date.ToShortDateString() : DateTime.MinValue.Date.ToShortDateString();
            string  _dobTo = String.IsNullOrEmpty(dobTo) ? DateTime.MinValue.Date.ToShortDateString() : DateTime.Now.Date.ToShortDateString();
            string _membershipTier = String.IsNullOrEmpty(membershipTier) ? "" : membershipTier;
            SqlCommand command = new SqlCommand("SELECT u.id,firstName,lastName ,dbo,email,gender,phoneNumber,totalPoint, mm.Name userMemberships "  + 
                                                 "FROM Users   u join UserMemberships m on u.UserMembershipId = m.Id " +
                                                 "join Memberships mm on mm.Id = m.MembershipId where u.IsDeleted = 0 and email like '%"+ _email +
                                                 "%' and (firstName like '%" + _name + "%' or lastName like '%" + _name + "%') and phoneNumber like '%" + _phoneNumber +
                                                 "%' and dbo between '" + _dobFrom + "' and '" +  _dobTo + "'  and mm.Name like '%" + _membershipTier +"%'", conn);
            List <CustomerViewModel> viewModels = new List<CustomerViewModel>();
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    CustomerViewModel customer = new CustomerViewModel
                    {
                        id= Convert.ToInt32(reader["id"]),
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString(),
                        dbo = Convert.ToDateTime(reader["dbo"]),
                        email = reader["email"].ToString(),
                        gender = reader["gender"].ToString(),
                        phoneNumber = reader["phoneNumber"].ToString(),
                        totalPoint = Convert.ToDecimal(reader["totalPoint"]),
                        userMemberships = reader["userMemberships"].ToString()
                    };
                    viewModels.Add(customer);
                }
            }
            conn.Close();

            return viewModels.AsQueryable();

           
        }
        public MemoryStream GenerateExcel(string email, string name, string phoneNumber, string dobFrom, string dobTo, string membershipTier)
        {
           
            var Query = Read(email, name, phoneNumber, dobFrom, dobTo, membershipTier);
            
            DataTable result = new DataTable();

            //result.Columns.Add(new DataColumn());
            result.Columns.Add(new DataColumn() { ColumnName = "No", DataType = typeof(int) });
            result.Columns.Add(new DataColumn() { ColumnName = "Email", DataType = typeof(String) });
            result.Columns.Add(new DataColumn() { ColumnName = "Phone Number", DataType = typeof(String) });
            result.Columns.Add(new DataColumn() { ColumnName = "Full Name", DataType = typeof(String) });
            result.Columns.Add(new DataColumn() { ColumnName = "Membership Tier", DataType = typeof(String) });
            

            if (Query.Count() == 0)
                result.Rows.Add("", "", "", "","");
            else
            {
                int index = 0;
                foreach (var item in Query)
                {
                    index++;
                    result.Rows.Add(index, item.email, item.phoneNumber, item.firstName +" " + item.lastName, item.userMemberships);
                }
            }

            return Excel.CreateExcel(new List<KeyValuePair<DataTable, string>> { (new KeyValuePair<DataTable, string>(result, "Customer BateeqShop")) }, true);

        }

        public IQueryable<CustomerViewModel> ReadById(int id)
        {
            SqlConnection conn = new SqlConnection("Server=com-bateeqefrata-sqlserver.database.windows.net;Database=com-bateeqshop-db-auth;User=adminPrd@com-bateeqefrata-sqlserver;password=Standar123.;Trusted_Connection=False;MultipleActiveResultSets=true");
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT u.id,firstName,lastName ,dbo,email,gender,phoneNumber,totalPoint, mm.Name userMemberships " +
                                                 "FROM Users   u join UserMemberships m on u.UserMembershipId = m.Id " +
                                                 "join Memberships mm on mm.Id = m.MembershipId where u.IsDeleted = 0 and u.id= " + id, conn);
            List<CustomerViewModel> viewModels = new List<CustomerViewModel>();
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CustomerViewModel customer = new CustomerViewModel
                    {
                        id = Convert.ToInt32(reader["id"]),
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString(),
                        dbo = Convert.ToDateTime(reader["dbo"]),
                        email = reader["email"].ToString(),
                        gender = reader["gender"].ToString(),
                        phoneNumber = reader["phoneNumber"].ToString(),
                        totalPoint = Convert.ToDecimal(reader["totalPoint"]),
                        userMemberships = reader["userMemberships"].ToString()
                    };
                    viewModels.Add(customer);
                }
            }

            conn.Close();
            return viewModels.AsQueryable();

            
        }
        public IQueryable<AddressBookViewModel> ReadAddressById(int id)
        {
            SqlConnection conn = new SqlConnection("Server=com-bateeqefrata-sqlserver.database.windows.net;Database=com-bateeqshop-db-auth;User=adminPrd@com-bateeqefrata-sqlserver;password=Standar123.;Trusted_Connection=False;MultipleActiveResultSets=true");
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT FirstName,LastName,PhoneNumber,Email,Company,Detail,City,Province ,Country ,PostalCode ,IsMain,UserId FROM dbo.AddressBooks u where u.IsDeleted = 0 and u.Userid= " + id, conn);
            List<AddressBookViewModel> viewModels = new List<AddressBookViewModel>();
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    AddressBookViewModel addressBook = new AddressBookViewModel
                    {
                        
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString(),
                        phoneNumber =  reader["PhoneNumber"].ToString(),
                        email = reader["email"].ToString(),
                        company = reader["company"].ToString(),
                        detail = reader["detail"].ToString(),
                        city = reader["city"].ToString(),
                        province = reader["province"].ToString(),
                        country = reader["country"].ToString(),
                        postalCode = reader["postalCode"].ToString(),
                    };
                    viewModels.Add(addressBook);
                }
            }
            conn.Close();

            return viewModels.AsQueryable();

           
        }
        public IQueryable<OrderViewModel> ReadOrderByUserId(int id)
        {
            SqlConnection conn = new SqlConnection("Server=com-bateeqshop-sqlserver.database.windows.net;Database=com-bateeqshop-db-order;User=adminPrd@com-bateeqshop-sqlserver;password=Standar123.;Trusted_Connection=False;MultipleActiveResultSets=true");
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT distinct orderNo,userid,o.paymentName,shipmentStatus,total,o.orderStatus,paymentStatus,agent FROM [dbo].[Orders] o join OrderDetails d on o.Id= d.OrderId where o.IsDeleted=0 and o.Userid= " + id, conn);
            List<OrderViewModel> viewModels = new List<OrderViewModel>();
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    OrderViewModel addressBook = new OrderViewModel
                    {

                        orderNo = reader["orderNo"].ToString(),
                        paymentName = reader["paymentName"].ToString(),
                        shipmentStatus = reader["shipmentStatus"].ToString(),
                        total = Convert.ToDecimal(reader["total"]),
                        orderStatus = reader["orderStatus"].ToString(),
                        paymentStatus = reader["paymentStatus"].ToString(),
                        agent = reader["agent"].ToString() 
                    };
                    viewModels.Add(addressBook);
                }
            }
            conn.Close();

            return viewModels.AsQueryable();

           
        }
        public IQueryable<MembershipViewModel> ReadMembership()
        {
            SqlConnection conn = new SqlConnection("Server=com-bateeqefrata-sqlserver.database.windows.net;Database=com-bateeqshop-db-auth;User=adminPrd@com-bateeqefrata-sqlserver;password=Standar123.;Trusted_Connection=False;MultipleActiveResultSets=true");
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT name,minAccumulation,percentageDiscValue,description,minPoint FROM dbo.Memberships u where u.IsDeleted = 0", conn);
            List<MembershipViewModel> viewModels = new List<MembershipViewModel>();
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MembershipViewModel membership = new MembershipViewModel
                    {

                        name = reader["name"].ToString(),
                        minAccumulation = Convert.ToDecimal(reader["minAccumulation"]),
                        percentageDiscValue = Convert.ToInt32(reader["percentageDiscValue"]),
                        description = reader["description"].ToString(),
                        minPoint = reader["minPoint"].ToString()
                       
                    };
                    viewModels.Add(membership);
                }
            }
            conn.Close();
            return viewModels.AsQueryable();

           
        }

    }
}
