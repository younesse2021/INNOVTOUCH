using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Shared.Models.OUT_.GetLotsCmdPdaResponse
{
    public class AuthentificationGetLotsCmdPdaResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextGetLotsCmdPdaResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }

    }
    public class ParametersGetLotsCmdPdaResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationGetLotsCmdPdaResponse Authentification { get; set; }
        public ContextGetLotsCmdPdaResponse Context { get; set; }
    }
    public class SOAPENVHeaderGetLotsCmdPdaResponse
    {
        public ParametersGetLotsCmdPdaResponse Parameters { get; set; }
    }
    public class GetLotsResponseGetLotsCmdPdaResponse
    {
        public string nolot { get; set; }
        public string liblot { get; set; }
    }
    public class GetLotsCmdPdaResponse
    {
        public DATAGetLotsCmdPdaResponse DATA { get; set; }
    }
    public class GetLotsCmdPdaResponse2
    {
        public DATAGetLotsCmdPdaResponse2 DATA { get; set; }
    }
    public class SOAPENVBodyGetLotsCmdPdaResponse
    {
        public GetLotsCmdPdaResponse Response_mjGWSgetLotsCmdPda { get; set; }
    }
    public class SOAPENVBodyGetLotsCmdPdaResponse2
    {
        public GetLotsCmdPdaResponse2 Response_mjGWSgetLotsCmdPda { get; set; }
    }
    public class DATAGetLotsCmdPdaResponse2
    {
        public GetLotsResponseGetLotsCmdPdaResponse lot { get; set; }
    }
    public class DATAGetLotsCmdPdaResponse
    {
        public List<GetLotsResponseGetLotsCmdPdaResponse> lot { get; set; }
    }

    public class SOAPENVEnvelopeGetLotsCmdPdaResponse
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
        public SOAPENVHeaderGetLotsCmdPdaResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetLotsCmdPdaResponse SOAPENVBody { get; set; }
    }
    public class SOAPENVEnvelopeGetLotsCmdPdaResponse2
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
        public SOAPENVHeaderGetLotsCmdPdaResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetLotsCmdPdaResponse2 SOAPENVBody { get; set; }
    }
    public class GetCmdLotsResponseGetLotsCmdPdaResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetLotsCmdPdaResponse SOAPENVEnvelope { get; set; }
    }
    public class GetCmdLotsResponseGetLotsCmdPdaResponse2
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetLotsCmdPdaResponse2 SOAPENVEnvelope { get; set; }
    }
}
