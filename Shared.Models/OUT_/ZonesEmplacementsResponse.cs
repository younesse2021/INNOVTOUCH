using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT.ZonesEmplacements
{
    public class Authentification
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class Context
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class Parameters
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public Authentification Authentification { get; set; }
        public Context Context { get; set; }
    }

    public class SOAPENVHeader
    {
        public Parameters Parameters { get; set; }
    }

    public class CodeExt
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Desc
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Code
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Value
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class LocationNumber
    {
        public Value value { get; set; }
    }

    public class LocationsAvailable
    {
        public List<LocationNumber> locationNumber { get; set; }
    }

    public class Zone
    {
        public string  codeExt { get; set; }
        public string  desc { get; set; }
        public string  code { get; set; }
        public string  locationsAvailable { get; set; }
    }

    public class ZonesAvailable
    {
        public List<Zone> zone { get; set; }
    }

    public class ResponsePDAGetListeEmplacements
    {
        public ZonesAvailable zonesAvailable { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponsePDAGetListeEmplacements Response_PDAGetListeEmplacements { get; set; }
    }

    public class SOAPENVEnvelope
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
        public SOAPENVHeader SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBody SOAPENVBody { get; set; }
    }

    public class ZonesEmplacementsResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
