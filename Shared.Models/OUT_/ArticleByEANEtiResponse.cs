using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.ArticleByEANEti
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

    public class Default
    {
        [JsonProperty("@FormatCode")]
        public string FormatCode { get; set; }

        [JsonProperty("@FormatDesc")]
        public string FormatDesc { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class ArticleEti
    {
        public string imageUrl { get; set; }
        public string barCode { get; set; }
        public string articleLabel { get; set; }
        public string articleCinr { get; set; }
        public string articleCinv { get; set; }
        public string salesPrice { get; set; }
        public Default Default { get; set; }
        public string Max { get; set; }
    }

    public class DATA
    {
        public ArticleEti articleEti { get; set; }
    }

    public class ResponseGWSGetArticleEtiData
    {
        public DATA DATA { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponseGWSGetArticleEtiData Response_GWSGetArticleEtiData { get; set; }
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

    public class ArticleByEANEtiResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
