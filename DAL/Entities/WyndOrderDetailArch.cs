using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class WyndOrderDetailArch
    {
        public string WyndOrderDetailUuid { get; set; }
        public string WyndOrderHeaderUuid { get; set; }
        public long WyndOrderHeaderId { get; set; }
        public string WyndOrderHeaderReference { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double OriginalQuantity { get; set; }
        public double UnitPriceVatExcluded { get; set; }
        public double OriginalPrice { get; set; }
        public double Vat { get; set; }
        public double TotalVatExcluded { get; set; }
        public double TotalVatIncluded { get; set; }
        public string VatRate { get; set; }
        public double TotalVat { get; set; }
        public int? LineIndex { get; set; }
        public bool IsPayable { get; set; }
        public bool IsDiscount { get; set; }
        public bool ForcedPrice { get; set; }
        public string PreparationState { get; set; }
        public int ProductWyndId { get; set; }
        public string ProductWyndUuid { get; set; }
        public int ProductExternalId { get; set; }
        public string ProductWyndDefaultLabel { get; set; }
        public double? StockDispo { get; set; }
        public double? StockDatePreparation { get; set; }
        public double? QteVendu { get; set; }
        public double? QteRecu { get; set; }
        public DateTime? DtderniereVente { get; set; }
        public DateTime? DtderniereReception { get; set; }
        public DateTime? DtderniereCommande { get; set; }
    }
}
