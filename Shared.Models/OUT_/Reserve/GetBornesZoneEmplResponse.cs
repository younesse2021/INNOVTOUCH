using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.GetBornesZoneEmplResponse
{
    public class AuthentificationGetBornesZoneEmplResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextGetBornesZoneEmplResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersGetBornesZoneEmplResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationGetBornesZoneEmplResponse Authentification { get; set; }
        public ContextGetBornesZoneEmplResponse Context { get; set; }
    }
    public class SOAPENVHeaderGetBornesZoneEmplResponse
    {
        public ParametersGetBornesZoneEmplResponse Parameters { get; set; }
    }
    public class InfoZoneEmplGetBornesZoneEmplResponse
    {
        public string BorneMinZone { get; set; }
        public object BorneMaxZone { get; set; }
        public object BorneMinEmpl { get; set; }
        public object BorneMaxEmpl { get; set; }
    }
    public class InfoZoneEmplResponseData
    {
        public InfoZoneEmplGetBornesZoneEmplResponse InfoZoneEmpl { get; set; }
    }

    public class SOAPENVBodyGetBornesZoneEmplResponse
    {
        public InfoZoneEmplResponseData Response_PDARsvGetBornesZoneEmplMarj { get; set; }
    }
    public class SOAPENVEnvelopeGetBornesZoneEmplResponse
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
        public SOAPENVHeaderGetBornesZoneEmplResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetBornesZoneEmplResponse SOAPENVBody { get; set; }
    }
    public class GetBornesZoneEmplResponseGetBornesZoneEmplResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetBornesZoneEmplResponse SOAPENVEnvelope { get; set; }
    }
}