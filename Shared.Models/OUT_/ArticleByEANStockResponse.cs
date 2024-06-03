using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.Stock
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
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public Authentification Authentification { get; set; }
        public Context Context { get; set; }
    }

    public class SOAPENVHeader
    {
        public Parameters Parameters { get; set; }
    }

    public class InfoStock
    {
        public string barCode { get; set; }
        public string cinv { get; set; }
        public string articleLabel { get; set; }
        public string qteDisponible { get; set; }
        public string uniteQte { get; set; }
        public string nbJr { get; set; }
        public object qteLivrasion { get; set; }
        public object dateLivrasion { get; set; }
        public object cinCde { get; set; }
        public object numLignePrix { get; set; }
        public object noCommande { get; set; }
        public object lineCommande { get; set; }
        public string qteCommande { get; set; }
        public object qteCommandeCumul { get; set; }
        public string dateCommande { get; set; }
        public string qteEngage { get; set; }
        public string qteRAL { get; set; }
        public string qteMovementStock { get; set; }
        public string dateMovementStock { get; set; }
        public string descMovementStock { get; set; }
    }

    public class ResponseGWSGetInfoStock
    {
        public InfoStock infoStock { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponseGWSGetInfoStock Response_GWSGetInfoStock { get; set; }
    }

    public class SOAPENVEnvelope
    {
        [JsonProperty("@xmlns:soapenv")]
        public string XmlnsSoapenv { get; set; }

        [JsonProperty("@xmlns:xsd")]
        public string XmlnsXsd { get; set; }

        [JsonProperty("@xmlns:xsi")]
        public string XmlnsXsi { get; set; }

        [JsonProperty("@xmlns:SOAP-ENV")]
        public string XmlnsSOAPENV { get; set; }

        [JsonProperty("SOAP-ENV:Header")]
        public SOAPENVHeader SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBody SOAPENVBody { get; set; }
    }

    public class ArticleByEANStockResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
