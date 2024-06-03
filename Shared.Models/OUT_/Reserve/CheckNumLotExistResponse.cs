using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.Reserve
{
    public class AuthentificationCheckNumLotExistResponse
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextCheckNumLotExistResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersCheckNumLotExistResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationCheckNumLotExistResponse Authentification { get; set; }
        public ContextCheckNumLotExistResponse Context { get; set; }
    }
    public class SOAPENVHeaderCheckNumLotExistResponse
    {
        public ParametersCheckNumLotExistResponse Parameters { get; set; }
    }
    public class ResponseCheckNumLotExist
    {
        public string NumLot { get; set; }
    }
    public class SOAPENVBodyCheckNumLotExistResponse
    {
        public ResponseCheckNumLotExist Response_PDARsvCheckNumLotExistMarj { get; set; }
    }
    public class SOAPENVEnvelopeCheckNumLotExistResponse
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
        public SOAPENVHeaderCheckNumLotExistResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyCheckNumLotExistResponse SOAPENVBody { get; set; }
    }
    public class CheckNumLotExistResponseCheckNumLotExistResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeCheckNumLotExistResponse SOAPENVEnvelope { get; set; }
    }
}

