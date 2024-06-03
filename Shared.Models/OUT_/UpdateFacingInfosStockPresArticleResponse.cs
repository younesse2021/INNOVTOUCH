using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_
{
    public class AuthentificationUpdateFacingInfosStockPresArticleResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextUpdateFacingInfosStockPresArticleResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersUpdateFacingInfosStockPresArticleResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationUpdateFacingInfosStockPresArticleResponse Authentification { get; set; }
        public ContextUpdateFacingInfosStockPresArticleResponse Context { get; set; }
    }

    public class Ns1GWSUpdateStockPresentationUpdateFacingInfosStockPresArticleResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }

        [JsonProperty("@xmlns:ns1")]
        public string XmlnsNs1 { get; set; }

        [JsonProperty("ns1:Stock")]
        public string Ns1Stock { get; set; }

        [JsonProperty("ns1:CINV")]
        public string Ns1CINV { get; set; }

        [JsonProperty("ns1:NivDef")]
        public string Ns1NivDef { get; set; }
    }

    public class ResponseGWSUpdateStockPresentationUpdateFacingInfosStockPresArticleResponse
    {
        [JsonProperty("ns1:GWSUpdateStockPresentation")]
        public Ns1GWSUpdateStockPresentationUpdateFacingInfosStockPresArticleResponse Ns1GWSUpdateStockPresentation { get; set; }
    }

    public class UpdateFacingInfosStockPresArticleResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeUpdateFacingInfosStockPresArticleResponse SOAPENVEnvelope { get; set; }
    }

    public class SOAPENVBodyUpdateFacingInfosStockPresArticleResponse
    {
        public ResponseGWSUpdateStockPresentationUpdateFacingInfosStockPresArticleResponse Response_GWSUpdateStockPresentation { get; set; }
    }

    public class SOAPENVEnvelopeUpdateFacingInfosStockPresArticleResponse
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
        public SOAPENVHeaderUpdateFacingInfosStockPresArticleResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyUpdateFacingInfosStockPresArticleResponse SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderUpdateFacingInfosStockPresArticleResponse
    {
        public ParametersUpdateFacingInfosStockPresArticleResponse Parameters { get; set; }
    }
}
