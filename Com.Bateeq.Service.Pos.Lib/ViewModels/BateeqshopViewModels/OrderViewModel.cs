using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels
{
    public class OrderViewModel
    {
        public int userId { get; set; }
        public string orderNo { get; set; }
        public string paymentName { get; set; }
        public string shipmentStatus { get; set; }
        public decimal total { get; set; }
        public string orderStatus { get; set; }
        public string paymentStatus { get; set; }
        public string agent { get; set; }
    }
}
