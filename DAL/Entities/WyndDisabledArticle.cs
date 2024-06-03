using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class WyndDisabledArticle
    {
        public long Id { get; set; }
        public long Codeart { get; set; }
        public int SiteCodeWynd { get; set; }
        public DateTime DateDisable { get; set; }

        public virtual ArticleInfo CodeartNavigation { get; set; }
    }
}
