using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class SiteLex
    {
        public long Id { get; set; }
        public int? SiteCodeWynd { get; set; }
        public TimeSpan? TimeDebut { get; set; }
        public TimeSpan? TimeFin { get; set; }
        public int? Capacite { get; set; }

        public virtual SiteCorrespondance SiteCodeWyndNavigation { get; set; }
    }
}
