using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT.ModelsUser
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
        [JsonProperty("-xmlns")]
        public string Xmlns { get; set; }
        public Authentification Authentification { get; set; }
        public Context Context { get; set; }
    }

    public class SOAPENVHeader
    {
        public Parameters Parameters { get; set; }
    }

    public class LABEL
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ITEM
    {
        public LABEL LABEL { get; set; }
        public object FUNCTION { get; set; }
        public string IDENT { get; set; }
        public string PARENT { get; set; }
    }

    public class MENU
    {
        public List<ITEM> ITEM { get; set; }
    }

    public class PDA
    {
        public MENU MENU { get; set; }
    }

    public class ResponsePDAGetInitData
    {
        public PDA PDA { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponsePDAGetInitData Response_PDAGetInitData { get; set; }
    }

    public class SOAPENVEnvelope
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
        public SOAPENVHeader SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBody SOAPENVBody { get; set; }
    }

    public class ModelsUserResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }

        [JsonProperty("#omit-xml-declaration")]
        public string OmitXmlDeclaration { get; set; }
    }
}
