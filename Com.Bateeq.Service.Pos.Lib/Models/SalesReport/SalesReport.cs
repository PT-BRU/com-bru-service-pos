using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.Bateeq.Service.Pos.Lib.Models.SalesReport
{
    public class SalesReport : StandardEntity
    {
        [MaxLength(255)]
        public string ItemCode { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        [MaxLength(255)]
        public string Date { get; set; }
        [MaxLength(255)]
        public string Category { get; set; }
        [MaxLength(255)]
        public string Collection { get; set; }
        [MaxLength(255)]
        public string SeasonCode { get; set; }
        [MaxLength(255)]
        public string SeasonYear { get; set; }
        [MaxLength(255)]
        public string ItemArticleRealizationOrder { get; set; }
        [MaxLength(255)]
        public string TransactionNo { get; set; }
        [MaxLength(255)]
        public string ItemName { get; set; }
        [MaxLength(255)]
        public string Color { get; set; }
        [MaxLength(255)]
        public string Size { get; set; }
        [MaxLength(255)]
        public string Style { get; set; }
        [MaxLength(255)]
        public string Group { get; set; }
        public double Quantity { get; set; }
        [MaxLength(255)]
        public string Location { get; set; }
        public double OriginalCost { get; set; }
        public double Gross { get; set; }
        public double Nett { get; set; }
        public double Discount1 { get; set; }
        public double Discount2 { get; set; }
        public double DiscountNominal { get; set; }
        public double SpecialDiscount { get; set; }
        public double TotalOriCost { get; set; }
        public double TotalGross { get; set; }
        public double TotalNett { get; set; }
        public double Margin { get; set; }

    }
}
