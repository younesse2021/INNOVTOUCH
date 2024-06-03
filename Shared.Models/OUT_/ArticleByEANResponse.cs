using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace Shared.Models.OUT.ArticleByEAN
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

    public class ArticleByEAN
    {
        public string imageUrl { get; set; }
        public string cinr { get; set; }
        public string orderable { get; set; }
        public string orderableFrom { get; set; }
        public string orderableTo { get; set; }
        public string orderableUnit { get; set; }
        public string orderableUnitLabel { get; set; }
        public string UAUVC { get; set; }
        public string prixPermanent { get; set; }
        public string prixPromo { get; set; }
        public string OSCode { get; set; }
        public string OSDesc { get; set; }
        public string OSFrom { get; set; }
        public string OSTo { get; set; }
        public string label { get; set; }
        public string contenanceRayon { get; set; }
        public string stockPresentation { get; set; }
        public string facing { get; set; }
        public string cinv { get; set; }
        public string etat { get; set; }
        public string etatlibl { get; set; }
        public string EAN { get; set; }
        public string refreshFunction { get; set; }
    }

    public class ResponseGWSGetArticleInfo
    {
        public ArticleByEAN article { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponseGWSGetArticleInfo Response_GWSGetArticleInfo { get; set; }
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

    public class ArticleByEANResponse
	{
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
