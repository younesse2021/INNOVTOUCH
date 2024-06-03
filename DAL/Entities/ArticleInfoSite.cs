using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ArticleInfoSite
    {
        public long CodeSite { get; set; }
        public long Codeart { get; set; }
        public DateTime DateStock { get; set; }
        public double QteStock { get; set; }
        public double Seuil { get; set; }
        public DateTime? DtderniereVente { get; set; }
        public double? QteVendu { get; set; }
        public DateTime? DtderniereReception { get; set; }
        public double? QteRecu { get; set; }
        public DateTime? DtderniereCommande { get; set; }
        public DateTime Dateupdate { get; set; }
    }
}
