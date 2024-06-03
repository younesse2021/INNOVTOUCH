using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.Reserve.GetArticlePaletteResponse
{
    public class ArticleeGetArticlePaletteResponse
    {
        public string CodeArticle { get; set; }
        public string LiblCaisseC { get; set; }
        public string LiblCaisseL { get; set; }
        public string Cinv { get; set; }
        public string Cinr { get; set; }
        public string Ustk { get; set; }
        public string PdsMoyen { get; set; }
        public string QteStock { get; set; }
        public string PdsStock { get; set; }
        public string QtePalette { get; set; }
        public string PdsPalette { get; set; }
    }

    public class AuthentificationGetArticlePaletteResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextGetArticlePaletteResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersGetArticlePaletteResponse
    {
        [JsonProperty("@xmlns")]
        public string xmlns { get; set; }
        public AuthentificationGetArticlePaletteResponse Authentification { get; set; }
        public ContextGetArticlePaletteResponse Context { get; set; }
    }

    public class ResponsePDARsvGetArticlePaletteMarjGetArticlePaletteResponse
    {
        public ArticleeGetArticlePaletteResponse Article { get; set; }
    }

    public class GetArticlePaletteResponseGetArticlePaletteResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetArticlePaletteResponse SOAPENVEnvelope { get; set; }
    }

    public class SOAPENVBodyGetArticlePaletteResponse
    {
        public ResponsePDARsvGetArticlePaletteMarjGetArticlePaletteResponse Response_PDARsvGetArticlePaletteMarj { get; set; }
    }

    public class SOAPENVEnvelopeGetArticlePaletteResponse
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
        public SOAPENVHeaderGetArticlePaletteResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetArticlePaletteResponse SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderGetArticlePaletteResponse
    {
        public ParametersGetArticlePaletteResponse Parameters { get; set; }
    }


}
