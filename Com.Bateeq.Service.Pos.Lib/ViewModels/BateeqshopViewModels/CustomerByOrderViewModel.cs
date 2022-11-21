using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels
{
    public class CustomerByOrderViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public int numberOfOrders { get; set; }
        public decimal orderTotal { get; set; }
    }
}
