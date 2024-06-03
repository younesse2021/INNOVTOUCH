using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Sheet1
    {
        public double? Codesite { get; set; }
        public string Codeart { get; set; }
        public string DateStock { get; set; }
        public double? QteStock { get; set; }
        public double? Seuil { get; set; }
        public DateTime? DtderniereVente { get; set; }
        public double? QteVendu { get; set; }
        public DateTime? DtderniereReception { get; set; }
        public double? QteRecu { get; set; }
        public DateTime? DtderniereCommande { get; set; }
        public DateTime? Dateupdate { get; set; }
    }
}
