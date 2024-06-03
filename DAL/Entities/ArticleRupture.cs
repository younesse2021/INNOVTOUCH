using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ArticleRupture
    {
        public long? Codeart { get; set; }
        public string Lblart { get; set; }
        public int? SiteCodeWynd { get; set; }
        public string Libsite { get; set; }
        public string CategoryNiv1Lib { get; set; }
        public string CategoryNiv2Lib { get; set; }
        public string CategoryNiv3Lib { get; set; }
        public string Utilisateur { get; set; }
        public string Date { get; set; }
    }
}
