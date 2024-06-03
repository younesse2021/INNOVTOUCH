using Newtonsoft.Json;
using Shared.Models.OUT.Inventaires;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT.Article
{
    public class Authentification
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class Context
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class Parameters
    {
        [JsonProperty("-xmlns")]
        public string Xmlns { get; set; }
        public Authentification Authentification { get; set; }
        public Context Context { get; set; }
    }

    public class SOAPENVHeader
    {
        public Parameters Parameters { get; set; }
    }

    public class Barcode
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Status
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Description
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ExternalVariantCode
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class InternalLogisticCode
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class StockUnit
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class LibStockUnit
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class InvoicingUnit
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class LibInvoicingUnit
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class AverageWeight
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class IntMerchStrucNode
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ExtMerchStrucNode
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class MerchStructureID
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class SalePrice
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Behaviour
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class StockMovementAllowed
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Seqvl
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Article
    {
        public string imageUrl { get; set; }
        public string barcode { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string externalVariantCode { get; set; }
        public string internalLogisticCode { get; set; }
        public string stockUnit { get; set; }
        public string libStockUnit { get; set; }
        public string invoicingUnit { get; set; }
        public string libInvoicingUnit { get; set; }
        public string averageWeight { get; set; }
        public string intMerchStrucNode { get; set; }
        public string extMerchStrucNode { get; set; }
        public string merchStructureID { get; set; }
        public string salePrice { get; set; }
        public string behaviour { get; set; }
        public string stockMovementAllowed { get; set; }
        public string seqvl { get; set; }
        public Inventory Inventories { get; set; }
    }

    public class Articles
    {
        public Article article { get; set; }
    }

    public class ResponsePDAInvGetArticleSaisiMarj
    {
        public Articles articles { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponsePDAInvGetArticleSaisiMarj Response_PDAInvGetArticleSaisiMarj { get; set; }
    }

    public class SOAPENVEnvelope
    {
        [JsonProperty("-xmlns:soapenv")]
        public string XmlnsSoapenv { get; set; }

        [JsonProperty("-xmlns:xsd")]
        public string XmlnsXsd { get; set; }

        [JsonProperty("-xmlns:xsi")]
        public string XmlnsXsi { get; set; }

        [JsonProperty("-xmlns:SOAP-ENV")]
        public string XmlnsSOAPENV { get; set; }

        [JsonProperty("SOAP-ENV:Header")]
        public SOAPENVHeader SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBody SOAPENVBody { get; set; }
    }


    public class ArticleResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }

        [JsonProperty("#omit-xml-declaration")]
        public string OmitXmlDeclaration { get; set; }
    }
}
