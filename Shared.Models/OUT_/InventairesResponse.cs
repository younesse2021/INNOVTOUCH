using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Shared.Models.OUT.Inventaires
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

    public class Number
    {
        public string CdataSection { get; set; }
    }

    public class Description
    {
        public string CdataSection { get; set; }
    }

    public class StockPosition
    {
        public string CdataSection { get; set; }
    }

    public class ValorisationDate
    {
        
        public string CdataSection { get; set; }
    }

    public class Inventory
    {
        public string  number { get; set; }
        public string  description { get; set; }
        public string   stockPosition { get; set; }
        public string  valorisationDate { get; set; }
    }

    public class ModeSaisiPdsQte
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Inventories
    {
        public List<Inventory> inventory { get; set; }
    }

    public class ResponsePDAInvGetListeInventairesMarj
    {
        public Inventories inventories { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponsePDAInvGetListeInventairesMarj Response_PDAInvGetListeInventairesMarj { get; set; }
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

    public class InventairesResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }

}
