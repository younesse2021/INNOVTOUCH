using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.CreerLotPreparationResponse
{
    public class AuthentificationCreerLotPreparationResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextCreerLotPreparationResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersCreerLotPreparationResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationCreerLotPreparationResponse Authentification { get; set; }
        public ContextCreerLotPreparationResponse Context { get; set; }
    }
    public class SOAPENVHeaderCreerLotPreparationResponse
    {
        public ParametersCreerLotPreparationResponse Parameters { get; set; }
    }
    public class CreerLotPrepResultCreerLotPreparationResponse
    {
        public string NumLot { get; set; }

    }
    public class SOAPENVBodyCreerLotPreparationResponse
    {
        public CreerLotPrepResultCreerLotPreparationResponse Response_PDARsvCreerLotPreparationMarj { get; set; }
    }
    public class SOAPENVEnvelopeCreerLotPreparationResponse
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
        public SOAPENVHeaderCreerLotPreparationResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyCreerLotPreparationResponse SOAPENVBody { get; set; }
    }
    public class CreerLotPrepResponseCreerLotPreparationResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeCreerLotPreparationResponse SOAPENVEnvelope { get; set; }
    }
}