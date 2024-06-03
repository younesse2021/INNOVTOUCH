using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.CloturerPaletteResponse
{
    public class AuthentificationCloturerPaletteResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextCloturerPaletteResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersCloturerPaletteResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationCloturerPaletteResponse Authentification { get; set; }
        public ContextCloturerPaletteResponse Context { get; set; }
    }

    public class SOAPENVHeaderCloturerPaletteResponse
    {
        public ParametersCloturerPaletteResponse Parameters { get; set; }
    }
    public class CloturerPaletteCloturerPaletteResponse
    {
        public string CintPalette { get; set; }
    }
    //public class ResponseGWSCloturerPaletteCloturerPaletteResponse
    //{
    //    public CloturerPaletteCloturerPaletteResponse Result { get; set; }
    //}
    public class SOAPENVBodyCloturerPaletteResponse
    {
        public CloturerPaletteCloturerPaletteResponse Response_PDARsvCloturerPaletteMarj { get; set; }
    }

    public class SOAPENVEnvelopeCloturerPaletteResponse
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
        public SOAPENVHeaderCloturerPaletteResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyCloturerPaletteResponse SOAPENVBody { get; set; }
    }
    public class GetCloturerPaletteResponseCloturerPaletteResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeCloturerPaletteResponse SOAPENVEnvelope { get; set; }
    }
}