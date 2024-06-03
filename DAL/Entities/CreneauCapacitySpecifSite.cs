using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class CreneauCapacitySpecifSite
    {
        public int SiteCode { get; set; }
        public DateTime DateSpecif { get; set; }
        public string CreneauId { get; set; }
        public int NewCapacity { get; set; }
        public DateTime DateCreation { get; set; }

        public virtual CreneauxLivraison Creneau { get; set; }
    }
}
