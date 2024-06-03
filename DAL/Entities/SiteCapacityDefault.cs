using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class SiteCapacityDefault
    {
        public int SiteCode { get; set; }
        public int CapacityAm { get; set; }
        public int CapacityPm { get; set; }
    }
}
