using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.Reserve.MajDetailPaletteResponse
{
 public class AuthentificationMajDetailPaletteResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextMajDetailPaletteResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersMajDetailPaletteResponse
    {
        [JsonProperty("@xmlns")]
        public string xmlns { get; set; }
        public AuthentificationMajDetailPaletteResponse Authentification { get; set; }
        public ContextMajDetailPaletteResponse Context { get; set; }
    }

    public class ResponsePDARsvMajDetailPaletteMarjMajDetailPaletteResponse
    {
        public string CintPalette { get; set; }
    }

    public class MajDetailPaletteResponseMajDetailPaletteResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeMajDetailPaletteResponse SOAPENVEnvelope { get; set; }
    }

    public class SOAPENVBodyMajDetailPaletteResponse
    {
        public ResponsePDARsvMajDetailPaletteMarjMajDetailPaletteResponse Response_PDARsvMajDetailPaletteMarj { get; set; }
    }

    public class SOAPENVEnvelopeMajDetailPaletteResponse
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
        public SOAPENVHeaderMajDetailPaletteResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyMajDetailPaletteResponse SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderMajDetailPaletteResponse
    {
        public ParametersMajDetailPaletteResponse Parameters { get; set; }
    }

}
