using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.CommandeSpecifique
{
    public class AuthentificationValiderArticlePdaResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextGValiderArticlePdaResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersValiderArticlePdaResponse
    {
        [JsonProperty("-xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationValiderArticlePdaResponse Authentification { get; set; }
        public ContextGValiderArticlePdaResponse Context { get; set; }
    }

    public class SOAPENVHeaderValiderArticlePdaResponse
    {
        public ParametersValiderArticlePdaResponse Parameters { get; set; }
    }
    public class ArticleValiderArticlePdaResponse
    {
        public string? MSG1 { get; set; }
        public string? MSG2 { get; set; }

    }
    public class ResponsePDAValiderArticlePdaResponse
    {
        public ArticleValiderArticlePdaResponse DATA { get; set; }
    }


    public class SOAPENVBodyValiderArticlePdaResponse
    {
        public ResponsePDAValiderArticlePdaResponse Response_mjGWSvaliderArticleCmd { get; set; }

    }
    public class SOAPENVEnvelopeValiderArticlePdaResponse
    {
        [JsonProperty("-xmlns:soapenv")]
        public string XmlnsSoapenv { get; set; }

        [JsonProperty("-xmlns:xsd")]
        public string XmlnsXsd { get; set; }

        [JsonProperty("-xmlns:xsi")]
        public string XmlnsXsi { get; set; }

        [JsonProperty("-xmlns:SOAP-ENV")]
        public string XmlnsSOAPENV { get; set; }

        [JsonProperty("SOAP-ENV:Header")]
        public SOAPENVHeaderValiderArticlePdaResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyValiderArticlePdaResponse SOAPENVBody { get; set; }
    }
    public class ArticleResponseValiderArticlePdaResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeValiderArticlePdaResponse SOAPENVEnvelope { get; set; }
    }
}
