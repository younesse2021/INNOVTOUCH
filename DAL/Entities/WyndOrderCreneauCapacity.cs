using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class WyndOrderCreneauCapacity
    {
        public string OrderWyndUuid { get; set; }
        public string OrderWyndReference { get; set; }
        public string OrderWyndStatusCode { get; set; }
        public int? DestinationId { get; set; }
        public string DestinationCode { get; set; }
        public int? SiteCode { get; set; }
        public int? SiteCodeWynd { get; set; }
        public string SiteLabel { get; set; }
        public DateTime? DateDebutLivraison { get; set; }
        public DateTime? DateFinLivraison { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateMiseAjour { get; set; }
    }
}
