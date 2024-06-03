using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Livreur
    {
        public string Uuid { get; set; }
        public long Id { get; set; }
        public string Label { get; set; }
        public string OpUuid { get; set; }
        public long? OpId { get; set; }
        public string OpLabel { get; set; }
        public string OpStatusCode { get; set; }
        public DateTime? DueDateStart { get; set; }
        public DateTime? DueDate { get; set; }
        public string StatusCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserUuid { get; set; }
        public long UserId { get; set; }
        public string CustomerFirstname { get; set; }
        public string CustomerLastname { get; set; }
        public int DestinationId { get; set; }
        public int? Code { get; set; }
        public string Reference { get; set; }
        public string PaymentMethod { get; set; }
        public double? SubTotal { get; set; }
        public double? Total { get; set; }
        public double? TotalVatExcluded { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? EntityId { get; set; }
        public string EntityUuid { get; set; }
        public string EntityLabel { get; set; }
        public int? EntityErpStoreId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerUuid { get; set; }
        public string CustomerFullName { get; set; }
        public string DestinationUuid { get; set; }
        public string DestinationCode { get; set; }
        public string DestinationLabel { get; set; }
        public string DeliveryAddressLatitude { get; set; }
        public string DeliveryAddressLongitude { get; set; }
        public string DeliveryAddressTelephone { get; set; }
        public string DeliveryAddressAddressInline { get; set; }
        public string DeliveryAddressFloor { get; set; }
        public string DeliveryAddressDoor { get; set; }
        public string DeliveryAddressComplement { get; set; }
        public string DeliveryAddressStreetNumber { get; set; }
        public string DeliveryAddressStreetName { get; set; }
        public string DeliveryAddressPostalCode { get; set; }
        public string DeliveryAddressCity { get; set; }
        public string KaalixReferenceId { get; set; }
        public string KaalixProviderId { get; set; }
        public string KaalixProviderName { get; set; }
        public string KaalixProviderPhone { get; set; }
        public double KaalixProviderLocationLatitude { get; set; }
        public double KaalixProviderLocationLongitude { get; set; }
        public double? SiteCorrespondanceLatitude { get; set; }
        public double? SiteCorrespondanceLongitude { get; set; }
        public DateTime? ShipDateTimeWhenInTransport { get; set; }
        public DateTime? ShipDateTimeWhenDelivrered { get; set; }
        public DateTime? ShipDateTimeLastUpdate { get; set; }
        public DateTime? ShipJobUpdateDate { get; set; }
        public long? ChannelId { get; set; }
        public string ChannelUuid { get; set; }
        public string ChannelCode { get; set; }
        public DateTime? DatePreparationFinish { get; set; }
        public int? PickerId { get; set; }
        public string PickerUuid { get; set; }
        public string PickerFullName { get; set; }
        public DateTime? DatePreparationStart { get; set; }
        public string Env { get; set; }
        public DateTime? DateUpdateJobUtc { get; set; }
        public int CommandeAvecAnnulation { get; set; }
        public int CommandeAvecRupture { get; set; }
        public int? NbArticles { get; set; }
        public int? NbRupture { get; set; }
        public int? NbSubstitution { get; set; }
        public int? MinTempsTrajetLex { get; set; }
        public int LivraionLexRespecté { get; set; }
        public int? RatingCommandeRating1 { get; set; }
        public int? RatingCommandeRating2 { get; set; }
        public int? RatingLivraisonRating1 { get; set; }
        public int? RatingLivraisonRating2 { get; set; }
        public string PhoneLivreur { get; set; }
    }
}
