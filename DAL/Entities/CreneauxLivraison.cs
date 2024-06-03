using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class CreneauxLivraison
    {
        public CreneauxLivraison()
        {
            CreneauCapacityDefaultSite = new HashSet<CreneauCapacityDefaultSite>();
            CreneauCapacitySpecifSite = new HashSet<CreneauCapacitySpecifSite>();
        }

        public string Id { get; set; }
        public string TypeLivraison { get; set; }
        public int HeureDebut { get; set; }
        public int HeureFin { get; set; }
        public int HeureCutoff { get; set; }
        public int? JourCutoff { get; set; }

        public virtual ICollection<CreneauCapacityDefaultSite> CreneauCapacityDefaultSite { get; set; }
        public virtual ICollection<CreneauCapacitySpecifSite> CreneauCapacitySpecifSite { get; set; }
    }
}
