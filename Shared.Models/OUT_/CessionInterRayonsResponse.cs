using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.CessionInterRayonsResponse
{
    public class DroitsPrixCession
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class AuthentificationCessionInterRayons
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextCessionInterRayons
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersCessionInterRayons
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationCessionInterRayons Authentification { get; set; }
        public ContextCessionInterRayons Context { get; set; }
    }

    public class Header
    {
        public SiteGereEnStock SiteGereEnStock { get; set; }
        public DroitsPrixCession DroitsPrixCession { get; set; }
        public StockExceededManagement StockExceededManagement { get; set; }
        public ModeSaisiPdsQte ModeSaisiPdsQte { get; set; }
    }

    public class ModeSaisiPdsQte
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ResponseGWSCessIntRayInit
    {
        public Header Header { get; set; }
    }

    public class CessionInterRayonsResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeCessionInterRayons SOAPENVEnvelope { get; set; }
    }

    public class SiteGereEnStock
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class SOAPENVBodyCessionInterRayons
    {
        public ResponseGWSCessIntRayInit Response_GWSCessIntRayInit { get; set; }
    }

    public class SOAPENVEnvelopeCessionInterRayons
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
        public SOAPENVHeaderCessionInterRayons SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyCessionInterRayons SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderCessionInterRayons
    {
        public ParametersCessionInterRayons Parameters { get; set; }
    }

    public class StockExceededManagement
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

}
