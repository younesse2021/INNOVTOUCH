using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.Models.OUT.ListControlePrixResponse;

namespace Shared.Models.OUT
{
    public class ControlsObject
    {
        public Control control { get; set; }
    }

    public class ResponsePDAgetInfoControlePrixObject
    {
        public ControlsObject controls { get; set; }
    }

    public class SOAPENVBodyObject
    {
        public ResponsePDAgetInfoControlePrixObject Response_PDAgetInfoControlePrix { get; set; }
    }

    public class SOAPENVEnvelopeObject
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
        public SOAPENVBodyObject SOAPENVBody { get; set; }
    }

    public class ListControlePrixObjectResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeObject SOAPENVEnvelope { get; set; }
    }
}
