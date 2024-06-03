using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class CaCategorie
    {
        public DateTime? DateLivraison { get; set; }
        public string Reference { get; set; }
        public double? Flp { get; set; }
        public double? Ca { get; set; }
        public int NbCmd { get; set; }
        public double? CaPgc { get; set; }
        public int NbCmdPgc { get; set; }
        public double? CaApls { get; set; }
        public int NbCmdApls { get; set; }
        public double? CaMarche { get; set; }
        public int NbCmdMarche { get; set; }
        public double? CaPem { get; set; }
        public int NbCmdPem { get; set; }
    }
}
