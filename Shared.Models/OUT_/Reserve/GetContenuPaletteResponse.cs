using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.GetContenuPaletteResponse
{
    public class AuthentificationGetContenuPaletteResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextGetContenuPaletteResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersGetContenuPaletteResponse
    {
    [JsonProperty("@xmlns")]
    public string Xmlns { get; set; }
    public AuthentificationGetContenuPaletteResponse Authentification { get; set; }
    public ContextGetContenuPaletteResponse Context { get; set; }
    }
    public class SOAPENVHeaderGetContenuPaletteResponse
    {
        public ParametersGetContenuPaletteResponse Parameters { get; set; }
    }
    public class listArticlesGetContenuPaletteResponse
    {
        public string Article { get; set; }
    }

    public class DATAGetContenuPaletteResponse
    {
        public List<listArticlesGetContenuPaletteResponse> Articles { get; set; }
    }

    public class DATAGetContenuPaletteResponse2
    {
        public listArticlesGetContenuPaletteResponse Articles { get; set; }
    }

    public class ResponseGetContenuPaletteGetContenuPaletteResponse
    { 
        public DATAGetContenuPaletteResponse DATA { get; set; }
    }

    public class ResponseGetContenuPaletteGetContenuPaletteResponse2
    {
        public DATAGetContenuPaletteResponse2 DATA { get; set; }
    }

    public class SOAPENVBodyGetContenuPaletteResponse
    {
        public ResponseGetContenuPaletteGetContenuPaletteResponse Response_PDARsvGetContenuPaletteMarj { get; set; }
    }

    public class SOAPENVBodyGetContenuPaletteResponse2
    {
        public ResponseGetContenuPaletteGetContenuPaletteResponse2 Response_PDARsvGetContenuPaletteMarj { get; set; }
    }

    public class SOAPENVEnvelopeGetContenuPaletteResponse
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
        public SOAPENVHeaderGetContenuPaletteResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetContenuPaletteResponse SOAPENVBody { get; set; }
    }

    public class SOAPENVEnvelopeGetContenuPaletteResponse2
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
        public SOAPENVHeaderGetContenuPaletteResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetContenuPaletteResponse2 SOAPENVBody { get; set; }
    }
   
    public class GetContenuPaletteResponseGetContenuPaletteResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetContenuPaletteResponse SOAPENVEnvelope { get; set; }
    }

    public class GetContenuPaletteResponseGetContenuPaletteResponse2
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetContenuPaletteResponse2 SOAPENVEnvelope { get; set; }
    }
}