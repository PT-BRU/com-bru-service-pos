using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Pos.Lib.ViewModels.BateeqshopViewModels
{
    public class AddressBookViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string company { get; set; }
        public string detail { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string isMain { get; set; }

        public int userId { get; set; }
    }
}
