using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.ViderPaletteResponse
{
    public class AuthentificationViderPaletteResponse
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextViderPaletteResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersViderPaletteResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationViderPaletteResponse Authentification { get; set; }
        public ContextViderPaletteResponse Context { get; set; }
    }
    public class SOAPENVHeaderViderPaletteResponse
    {
        public ParametersViderPaletteResponse Parameters { get; set; }
    }
    public class ResponseViderPalette
    {
        public string NumPalette { get; set; }
    }

    public class SOAPENVBodyViderPaletteResponse
    {
        public ResponseViderPalette Response_PDARsvViderPaletteMarj { get; set; }
    }
    public class SOAPENVEnvelopeViderPaletteResponse
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
        public SOAPENVHeaderViderPaletteResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyViderPaletteResponse SOAPENVBody { get; set; }
    }
    public class ViderPaletteResponseViderPaletteResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeViderPaletteResponse SOAPENVEnvelope { get; set; }
    }
}