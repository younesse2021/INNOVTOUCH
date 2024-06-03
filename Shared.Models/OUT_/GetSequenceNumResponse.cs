using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT.GetSequenceNumResponse
{
    public class AuthentificationGetSequenceNumResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextGetSequenceNumResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersGetSequenceNumResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationGetSequenceNumResponse Authentification { get; set; }
        public ContextGetSequenceNumResponse Context { get; set; }
    }

    public class ResponsePDAGetSequenceGetSequenceNumResponse
    {
        public string sequence { get; set; }
    }

    public class GetSequenceNumResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetSequenceNumResponse SOAPENVEnvelope { get; set; }
    }

    public class SOAPENVBodyGetSequenceNumResponse
    {
        public ResponsePDAGetSequenceGetSequenceNumResponse Response_PDAGetSequence { get; set; }
    }

    public class SOAPENVEnvelopeGetSequenceNumResponse
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
        public SOAPENVHeaderGetSequenceNumResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetSequenceNumResponse SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderGetSequenceNumResponse
    {
        public ParametersGetSequenceNumResponse Parameters { get; set; }
    }


}
