using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class OrderControlProductEan
    {
        public long Id { get; set; }
        public string Ean { get; set; }
        public string DetailUuid { get; set; }
        public string HeaderUuid { get; set; }

        public virtual OrderControlDetail OrderControlDetail { get; set; }
    }
}
