using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class SiteCapacitySpecif
    {
        public int SiteCode { get; set; }
        public DateTime DateSpecif { get; set; }
        public int NewCapacityAm { get; set; }
        public int NewCapacityPm { get; set; }
        public DateTime DateCreation { get; set; }
        public string AddedByUsername { get; set; }
    }
}
