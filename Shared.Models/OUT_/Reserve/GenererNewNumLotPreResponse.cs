using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.GenererNewNumLotPreResponse
{
    public class AuthentificationGenererNewNumLotPreResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextGenererNewNumLotPreResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersGenererNewNumLotPreResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationGenererNewNumLotPreResponse Authentification { get; set; }
        public ContextGenererNewNumLotPreResponse Context { get; set; }
    }

    public class SOAPENVHeaderGenererNewNumLotPreResponse
    {
        public ParametersGenererNewNumLotPreResponse Parameters { get; set; }
    }

    public class GenererNewNumLotPreResultGenererNewNumLotPreResponse
    {
        public string NumLot { get; set; }
    }


    public class SOAPENVBodyGenererNewNumLotPreResponse
    {
        public GenererNewNumLotPreResultGenererNewNumLotPreResponse Response_PDARsvGenererNewNumLotPrepaMarj { get; set; }
    }

    public class SOAPENVEnvelopeGenererNewNumLotPreResponse
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
        public SOAPENVHeaderGenererNewNumLotPreResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGenererNewNumLotPreResponse SOAPENVBody { get; set; }
    }

    public class ResponseGenererNewNumLotPreResponseGenererNewNumLotPreResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGenererNewNumLotPreResponse SOAPENVEnvelope { get; set; }
    }
}