using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class OrderHeader
    {
        public string Reference { get; set; }
        public string Magasin { get; set; }
        public double SubTotalStandard { get; set; }
        public double SubTotalExpress { get; set; }
        public double SousTotal { get; set; }
        public double Total { get; set; }
        public DateTime DateDeCréation { get; set; }
        public DateTime DateDeMaj { get; set; }
        public int? PickerId { get; set; }
        public string PickerUuid { get; set; }
        public string PickerFullName { get; set; }
        public DateTime? DatePreparationStart { get; set; }
        public DateTime? DatePreparationFinish { get; set; }
        public DateTime? DateDeLivraisonPrévue { get; set; }
        public string Client { get; set; }
        public string Statut { get; set; }
        public string Type { get; set; }
        public string DeliveryLat { get; set; }
        public string DeliveryLon { get; set; }
        public DateTime DateUpdateJob { get; set; }
        public decimal? TauxRupture { get; set; }
        public decimal? TauxRuptureSubstituable { get; set; }
        public decimal? TauxSubstitution { get; set; }
        public decimal? TauxAnnulation { get; set; }
        public int? NbRupture { get; set; }
        public int? NbRuptureSubstituable { get; set; }
        public int? NbSubstitution { get; set; }
        public int? NbArticles { get; set; }
        public int? NbAnnulation { get; set; }
        public int RuptureZero { get; set; }
        public int CommandeAvecAnnulation { get; set; }
        public int CommandeAvecRupture { get; set; }
        public int RuptureTolere { get; set; }
        public int RuptureNonTolere { get; set; }
        public int CommandeCompleteAvecSubstitution { get; set; }
        public int CommandeCompleteSansSubstitution { get; set; }
        public int CommandeAvecSubstitution { get; set; }
        public DateTime? DateDeLivraison { get; set; }
        public DateTime? DatePriseLivraison { get; set; }
        public int DateLivraisonEffective { get; set; }
        public int? MinTempsTrajet { get; set; }
        public int? MinTempsTrajetLex { get; set; }
        public int? MinRetardLiv { get; set; }
        public int? LivraionEnRetard { get; set; }
        public int? LivraionRespecté { get; set; }
        public int LivraionLexRespecté { get; set; }
        public int UrbanShip { get; set; }
        public int? ClickColect { get; set; }
        public string VilleMagasin { get; set; }
        public DateTime? DateDebutLivraison { get; set; }
        public DateTime? DateFinLivraison { get; set; }
        public long? ChannelId { get; set; }
        public string ChannelUuid { get; set; }
        public string ChannelCode { get; set; }
        public int Mobile { get; set; }
        public int Web { get; set; }
        public int? Rating1 { get; set; }
        public int? Rating2 { get; set; }
        public int? Rating3 { get; set; }
        public int CommandeStandard { get; set; }
        public int CommandeExpress { get; set; }
    }
}
