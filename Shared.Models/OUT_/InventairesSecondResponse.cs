using Newtonsoft.Json;
using Shared.Models.OUT.Inventaires;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.InventairesSecondResponse
{
    public class AuthentificationSecond
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextSecond
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersSecond
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationSecond Authentification { get; set; }
        public ContextSecond Context { get; set; }
    }

    public class SOAPENVHeaderSecond
    {
        public ParametersSecond Parameters { get; set; }
    }

    public class NumberSecond
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class DescriptionSecond
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class StockPositionSecond
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ValorisationDateSecond
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ModeSaisiPdsQteSecond
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class InventoriesSecond
    {
        public Inventory inventory { get; set; }
    }

    public class ResponsePDAInvGetListeInventairesMarjSecond
    {
        public InventoriesSecond inventories { get; set; }
    }
    public class SOAPENVBodySecond
    {
        public ResponsePDAInvGetListeInventairesMarjSecond Response_PDAInvGetListeInventairesMarj { get; set; }
    }

    public class SOAPENVEnvelopeSecond
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
        public SOAPENVHeaderSecond SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodySecond SOAPENVBody { get; set; }
    }

    public class InventairesSecondResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeSecond SOAPENVEnvelope { get; set; }
    }

}
