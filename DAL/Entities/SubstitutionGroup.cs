using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class SubstitutionGroup
    {
        public string Id { get; set; }
        public long Codeart { get; set; }

        public virtual ArticleInfo CodeartNavigation { get; set; }
    }
}
