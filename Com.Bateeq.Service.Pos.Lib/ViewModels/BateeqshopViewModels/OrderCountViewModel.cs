using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels
{
    public class OrderCountViewModel
    {
        public int userId { get; set; }
        public int orderCount { get; set; }
        public string orderStatus { get; set; }
        public  decimal total { get; set; }
    }
}
