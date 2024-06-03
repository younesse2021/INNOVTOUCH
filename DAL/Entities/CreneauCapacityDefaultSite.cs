using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class CreneauCapacityDefaultSite
    {
        public int SiteCode { get; set; }
        public string CreneauId { get; set; }
        public int Capacity { get; set; }

        public virtual CreneauxLivraison Creneau { get; set; }
    }
}
