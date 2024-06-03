using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT.GetAticleArrivageMagasinResponse
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

    public class GetAticleResult
    {
        public object Palette { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string USTK { get; set; }
        public string TypeUA { get; set; }
        public string UVCUA { get; set; }
        public string CINR { get; set; }
        public string SEQVL { get; set; }
        public string CEXR { get; set; }
        public string CINV { get; set; }
        public string CEXV { get; set; }
        public string QTEEXP { get; set; }
        public object Message { get; set; }
        public object Exception { get; set; }
    }

    public class ResponsePDAGetAticle
    {
        public GetAticleResult Result { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponsePDAGetAticle Response_PDAGetAticle { get; set; }
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

    public class GetAticleArrivageMagasinResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
