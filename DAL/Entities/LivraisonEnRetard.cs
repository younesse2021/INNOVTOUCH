using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class LivraisonEnRetard
    {
        public string Reference { get; set; }
        public string Magasin { get; set; }
        public DateTime DateDeCréation { get; set; }
        public DateTime DateDeMaj { get; set; }
        public DateTime? DateDebutLivraison { get; set; }
        public DateTime? DateFinLivraison { get; set; }
        public string Client { get; set; }
        public string Statut { get; set; }
        public string Type { get; set; }
        public string DeliveryLat { get; set; }
        public string DeliveryLon { get; set; }
        public DateTime DateUpdateJob { get; set; }
        public DateTime? DatePriseLivraison { get; set; }
        public DateTime? DateLivraisonEffective { get; set; }
        public int LivraisonResepecte { get; set; }
        public string VilleMagasin { get; set; }
    }
}
