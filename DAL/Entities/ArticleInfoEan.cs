using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ArticleInfoEan
    {
        public long Codeart { get; set; }
        public string Ean { get; set; }
        public DateTime Dateupdate { get; set; }

        public virtual ArticleInfo CodeartNavigation { get; set; }
    }
}
