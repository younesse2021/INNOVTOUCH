using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class WyndDisabledArticleHistorique
    {
        public long Id { get; set; }
        public long? Codeart { get; set; }
        public int? SiteCodeWynd { get; set; }
        public string Utilisateur { get; set; }
        public DateTime? Date { get; set; }

        public virtual ArticleInfo CodeartNavigation { get; set; }
    }
}
