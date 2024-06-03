using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_
{
    public class AuthentificationFacingUpdateInfosArticleResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextFacingUpdateInfosArticleResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersFacingUpdateInfosArticleResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationFacingUpdateInfosArticleResponse Authentification { get; set; }
        public ContextFacingUpdateInfosArticleResponse Context { get; set; }
    }

    public class Ns1GWSUpdateContenanceFacingUpdateInfosArticleResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }

        [JsonProperty("@xmlns:ns1")]
        public string XmlnsNs1 { get; set; }

        [JsonProperty("ns1:Facing")]
        public string Ns1Facing { get; set; }

        [JsonProperty("ns1:Contenance")]
        public string Ns1Contenance { get; set; }

        [JsonProperty("ns1:CINV")]
        public string Ns1CINV { get; set; }
    }

    public class ResponseGWSUpdateContenanceFacingUpdateInfosArticleResponse
    {
        [JsonProperty("ns1:GWSUpdateContenance")]
        public Ns1GWSUpdateContenanceFacingUpdateInfosArticleResponse Ns1GWSUpdateContenance { get; set; }
    }

    public class FacingUpdateInfosArticleResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeFacingUpdateInfosArticleResponse SOAPENVEnvelope { get; set; }
    }

    public class SOAPENVBodyFacingUpdateInfosArticleResponse
    {
        public ResponseGWSUpdateContenanceFacingUpdateInfosArticleResponse Response_GWSUpdateContenance { get; set; }
    }

    public class SOAPENVEnvelopeFacingUpdateInfosArticleResponse
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
        public SOAPENVHeaderFacingUpdateInfosArticleResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyFacingUpdateInfosArticleResponse SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderFacingUpdateInfosArticleResponse
    {
        public ParametersFacingUpdateInfosArticleResponse Parameters { get; set; }
    }



}
