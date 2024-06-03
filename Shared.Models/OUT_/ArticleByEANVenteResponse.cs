using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.Vente
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

    public class InfoVente
    {
        public string barCodeIV { get; set; }
        public string articleLabel { get; set; }
        public List<string> ventesJ { get; set; }
        public string MoyVentesJours { get; set; }
        public string VarVentesJours { get; set; }
        public List<string> ventesS { get; set; }
        public string MoyVentesSemaines { get; set; }
        public string VarVentesSemaines { get; set; }
        public List<string> ventesM { get; set; }
        public string MoyVentesMois { get; set; }
        public string VarVentesMois { get; set; }
    }

    public class ResponseGWSGetInfoVente
    {
        public InfoVente infoVente { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponseGWSGetInfoVente Response_GWSGetInfoVente { get; set; }
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


    public class ArticleByEANVenteResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
