using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class CapacityOrderInfo
    {
        public string OrderWyndUuid { get; set; }
        public long OrderWyndId { get; set; }
        public string OrderWyndLabel { get; set; }
        public int SiteCode { get; set; }
        public int SiteCodeWynd { get; set; }
        public DateTime OrderDate { get; set; }
        public int? TotalItems { get; set; }
        public DateTime DateFinal { get; set; }
        public string Position { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
