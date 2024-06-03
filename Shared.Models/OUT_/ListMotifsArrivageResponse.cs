using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT.ListMotifsArrivageResponse
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

    public class Parpost
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Tparlibl
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Tparlibc
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Parvan1
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Ligne
    {
        public Parpost parpost { get; set; }
        public Tparlibl tparlibl { get; set; }
        public Tparlibc tparlibc { get; set; }
        public string parvac1 { get; set; }
        public Parvan1 parvan1 { get; set; }
    }

    public class Detail
    {
        public List<Ligne> Ligne { get; set; }
    }

    public class ResponsePDAGetListMotifsArrivage
    {
        public Detail Detail { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponsePDAGetListMotifsArrivage Response_PDAGetListMotifsArrivage { get; set; }
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


    public class ListMotifsArrivageResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
