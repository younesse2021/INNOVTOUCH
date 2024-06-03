using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.Reserve
{
    public class AuthentificationGenerateNewNumPaletteResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextGenerateNewNumPaletteResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersGenerateNewNumPaletteResponse
    {
        [JsonProperty("@xmlns")]
        public string xmlns { get; set; }
        public AuthentificationGenerateNewNumPaletteResponse Authentification { get; set; }
        public ContextGenerateNewNumPaletteResponse Context { get; set; }
    }

    public class InfoPaletteGenerateNewNumPaletteResponse
    {
        public string NumPalette { get; set; }
        public string CintPalette { get; set; }
        public string Zone { get; set; }
        public string Emplacement { get; set; }
        public string EtatPalette { get; set; }
        public string NbArticles { get; set; }
    }

    public class ResponsePDARsvGenererNewNumPaletteMarjGenerateNewNumPaletteResponse
    {
        public InfoPaletteGenerateNewNumPaletteResponse InfoPalette { get; set; }
    }

    public class GenerateNewNumPaletteResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGenerateNewNumPaletteResponse SOAPENVEnvelope { get; set; }
    }

    public class SOAPENVBodyGenerateNewNumPaletteResponse
    {
        public ResponsePDARsvGenererNewNumPaletteMarjGenerateNewNumPaletteResponse Response_PDARsvGenererNewNumPaletteMarj { get; set; }
    }

    public class SOAPENVEnvelopeGenerateNewNumPaletteResponse
    {
        [JsonProperty("@xmlns:soapenv")]
        public string xmlnssoapenv { get; set; }

        [JsonProperty("@xmlns:xsd")]
        public string xmlnsxsd { get; set; }

        [JsonProperty("@xmlns:xsi")]
        public string xmlnsxsi { get; set; }

        [JsonProperty("@xmlns:SOAP-ENV")]
        public string xmlnsSOAPENV { get; set; }

        [JsonProperty("SOAP-ENV:Header")]
        public SOAPENVHeaderGenerateNewNumPaletteResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGenerateNewNumPaletteResponse SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderGenerateNewNumPaletteResponse
    {
        public ParametersGenerateNewNumPaletteResponse Parameters { get; set; }
    }

}
