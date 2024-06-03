using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class SitePolygonLex
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? SiteCodeWynd { get; set; }

        public virtual SiteCorrespondance SiteCodeWyndNavigation { get; set; }
    }
}
