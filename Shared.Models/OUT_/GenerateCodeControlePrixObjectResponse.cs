using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.Models.OUT.GenerateCodeControlePrixResponse;

namespace Shared.Models.OUT.GenerateCodeControlePrixObjectResponse
{

    public class ArticlesOject
    {
        public ArticlePrixInfo article { get; set; }
    }

    public class ControlPrixInfoOject
    {
        public ControlNoPrixInfo controlNo { get; set; }
        public ArticlesOject articles { get; set; }
    }

    public class ResponsePDAControlePrixPreparerOject
    {
        public ControlPrixInfoOject control { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponsePDAControlePrixPreparerOject Response_PDAControlePrixPreparer { get; set; }
    }

    public class SOAPENVEnvelopeOject
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

    public class GenerateCodeControlePrixObjectResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeOject SOAPENVEnvelope { get; set; }
    }
}
