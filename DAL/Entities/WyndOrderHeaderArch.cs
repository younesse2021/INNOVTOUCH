using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class WyndOrderHeaderArch
    {
        public long? ChannelId { get; set; }
        public string ChannelUuid { get; set; }
        public string ChannelCode { get; set; }
        public string Uuid { get; set; }
        public long Id { get; set; }
        public string Reference { get; set; }
        public int? Code { get; set; }
        public DateTime? DueDateStart { get; set; }
        public DateTime? DatePreparationFinish { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public double? TotalVatExcluded { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public int Entityid { get; set; }
        public string EntityUuid { get; set; }
        public string EntityLabel { get; set; }
        public int ErpStoreId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerUuid { get; set; }
        public string CustomerFullName { get; set; }
        public string DestinationCode { get; set; }
        public string StatusCode { get; set; }
        public string DeliveryLat { get; set; }
        public string DeliveryLon { get; set; }
        public DateTime DateUpdateJob { get; set; }
        public DateTime? ShipDateTimeWhenInTransport { get; set; }
        public DateTime? ShipDateTimeWhenDelivrered { get; set; }
        public DateTime? ShipDateTimeLastUpdate { get; set; }
        public DateTime? ShipJobUpdateDate { get; set; }
    }
}
