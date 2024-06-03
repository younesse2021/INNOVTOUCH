using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.ValiderCessionInterRayonsResponse
{
    public class CessionValiderCessionInterRayonsResponse
    {
        public CodeValiderCessionInterRayonsResponse Code { get; set; }
        public ReportValiderCessionInterRayonsResponse Report { get; set; }
    }

    public class CessionsValiderCessionInterRayonsResponse
    {
        public CessionValiderCessionInterRayonsResponse Cession { get; set; }
    }

    public class CodeValiderCessionInterRayonsResponse
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class AuthentificationValiderCessionInterRayonsResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextValiderCessionInterRayonsResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersValiderCessionInterRayonsResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationValiderCessionInterRayonsResponse Authentification { get; set; }
        public ContextValiderCessionInterRayonsResponse Context { get; set; }
    }

    public class ReportValiderCessionInterRayonsResponse
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ResponseGWSCessIntRayValidateValiderCessionInterRayonsResponse
    {
        public CessionsValiderCessionInterRayonsResponse Cessions { get; set; }
    }

    public class ValiderCessionInterRayonsResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeValiderCessionInterRayonsResponse SOAPENVEnvelope { get; set; }
    }

    public class SOAPENVBodyValiderCessionInterRayonsResponse
    {
        public ResponseGWSCessIntRayValidateValiderCessionInterRayonsResponse Response_GWSCessIntRayValidate { get; set; }
    }

    public class SOAPENVEnvelopeValiderCessionInterRayonsResponse
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
        public SOAPENVHeaderValiderCessionInterRayonsResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyValiderCessionInterRayonsResponse SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderValiderCessionInterRayonsResponse
    {
        public ParametersValiderCessionInterRayonsResponse Parameters { get; set; }
    }


}
