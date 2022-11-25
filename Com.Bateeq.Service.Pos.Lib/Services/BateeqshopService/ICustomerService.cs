using Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Com.Bateeq.Service.Pos.Lib.Services.BateeqshopService
{
    public interface ICustomerService
    {
        IQueryable<CustomerViewModel> Read(string email, string name, string  phoneNumber, string dobFrom, string dobTo, string membershipTier);
        IQueryable<CustomerViewModel> ReadById(int id);
        IQueryable<AddressBookViewModel> ReadAddressById(int id);
        IQueryable<OrderViewModel> ReadOrderByUserId(int id);
        MemoryStream GenerateExcel(string email, string name, string phoneNumber, string dobFrom, string dobTo, string membershipTier);
        IQueryable<CustomerByOrderViewModel> ReadCustomerByOrder(string startOrder, string endOrder, string orderStatus, decimal totalOrderFrom, decimal totalOrderTo);
        MemoryStream GenerateExcelCustomerByOrder(string starOrder, string endOrder, string orderState, decimal totalOrderFrom, decimal totalOrderTo);
        IQueryable<MembershipViewModel> ReadMembership();
    }
}
