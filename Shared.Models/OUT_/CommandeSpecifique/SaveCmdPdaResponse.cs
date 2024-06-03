using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_
{
    public class AuthentificationSaveCmdPdaResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextSaveCmdPdaResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersSaveCmdPdaResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationSaveCmdPdaResponse Authentification { get; set; }
        public ContextSaveCmdPdaResponse Context { get; set; }
    }
    public class SOAPENVHeaderSaveCmdPdaResponse
    {
        public ParametersSaveCmdPdaResponse Parameters { get; set; }
    }
    public class SaveCmdPdaResponseSaveCmdPdaResponse
    {
        public object DATA { get; set; }
    }


    public class SOAPENVBodySaveCmdPdaResponse
    {
        public SaveCmdPdaResponseSaveCmdPdaResponse Response_mjGWSsaveCmdPda { get; set; }
    }
    public class SOAPENVEnvelopeSaveCmdPdaResponse
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
        public SOAPENVHeaderSaveCmdPdaResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodySaveCmdPdaResponse SOAPENVBody { get; set; }
    }
    public class SaveCmdPdaResponseResponseSaveCmdPda
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeSaveCmdPdaResponse SOAPENVEnvelope { get; set; }
    }
}