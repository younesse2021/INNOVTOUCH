using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.StockerPaletteResponse
{
    public class AuthentificationStockerPaletteResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextStockerPaletteResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersStockerPaletteResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationStockerPaletteResponse Authentification { get; set; }
        public ContextStockerPaletteResponse Context { get; set; }
    }
    public class SOAPENVHeaderStockerPaletteResponse
    {
        public ParametersStockerPaletteResponse Parameters { get; set; }
    }
    public class StockerPaletteResultStockerPaletteResponse
    {
        public string CintPalette { get; set; }
    }

    public class SOAPENVBodyStockerPaletteResponse
    {
        public StockerPaletteResultStockerPaletteResponse Response_PDARsvStockerPaletteRacksMarj { get; set; }
    }
    public class SOAPENVEnvelopeStockerPaletteResponse
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
        public SOAPENVHeaderStockerPaletteResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyStockerPaletteResponse SOAPENVBody { get; set; }
    }
    public class GetStockerPaletteResponseStockerPaletteResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeStockerPaletteResponse SOAPENVEnvelope { get; set; }
    }
}