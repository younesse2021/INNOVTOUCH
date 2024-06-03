using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class AdresseArticle
    {
        public int SiteCode { get; set; }
        public int Cexrart { get; set; }
        public string CodeAdresse { get; set; }
        public string CodeArticleEan { get; set; }
        public string Libart { get; set; }
        public int Dept { get; set; }
        public int Ray { get; set; }
        public int Fam { get; set; }
        public int Sfam { get; set; }
        public int? Ssfam { get; set; }
        public int? Ub { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateMaj { get; set; }
    }
}
