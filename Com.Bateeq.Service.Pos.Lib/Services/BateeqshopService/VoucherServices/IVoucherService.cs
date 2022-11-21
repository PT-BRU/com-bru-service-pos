using Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Bateeq.Service.Pos.Lib.Services.BateeqshopService.VoucherServices
{
    public interface IVoucherService
    {
        IQueryable<VoucherViewModel> Read(DateTime startDate, DateTime endDate, string voucherType, string code, string name, string keyword);
    }
}
