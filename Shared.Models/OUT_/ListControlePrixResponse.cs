using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT.ListControlePrixResponse
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

    public class ControlNo
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ControlLabel
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class PreparationDate
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class PreparationDateTrt
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class StateCtl
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class StateCtlLabel
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class User
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Control
    {
        public ControlNo controlNo { get; set; }
        public ControlLabel controlLabel { get; set; }
        public PreparationDate preparationDate { get; set; }
        public PreparationDateTrt preparationDateTrt { get; set; }
        public StateCtl stateCtl { get; set; }
        public StateCtlLabel stateCtlLabel { get; set; }
        public User User { get; set; }
    }

    public class Controls
    {
        public List<Control> control { get; set; }
    }

    public class ResponsePDAgetInfoControlePrix
    {
        public Controls controls { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponsePDAgetInfoControlePrix Response_PDAgetInfoControlePrix { get; set; }
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

    public class ListControlePrixResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
