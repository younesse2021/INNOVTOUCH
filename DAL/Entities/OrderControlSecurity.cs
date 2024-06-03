using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class OrderControlSecurity
    {
        public long Id { get; set; }
        public string Ean { get; set; }
        public string HeaderUuid { get; set; }

        public virtual OrderControlHeader HeaderUu { get; set; }
    }
}
