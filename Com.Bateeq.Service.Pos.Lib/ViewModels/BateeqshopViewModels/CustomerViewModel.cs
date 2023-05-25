using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels
{
    public class CustomerViewModel
    {
        public int id { get; set; }
        public string firstName  { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gender { get; set; }
        public DateTime dbo { get; set; }
        public string userMemberships { get; set; }
        public decimal totalPoint { get; set; }
    }
}
