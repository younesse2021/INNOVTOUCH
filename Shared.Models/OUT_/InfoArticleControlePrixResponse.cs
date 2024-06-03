﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT.InfoArticleControlePrixResponse
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

    public class TillCode
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class CaisseCode
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class TillDesc
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class VentePrice
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class CaissePrice
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class IntCodeArticleSale
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Cinr
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ArticleInfo
    {
        public TillCode TillCode { get; set; }
        public CaisseCode CaisseCode { get; set; }
        public TillDesc TillDesc { get; set; }
        public VentePrice VentePrice { get; set; }
        public CaissePrice CaissePrice { get; set; }
        public IntCodeArticleSale intCodeArticleSale { get; set; }
        public Cinr cinr { get; set; }
    }

    public class Detail
    {
        public ArticleInfo article { get; set; }
    }

    public class ResponsePDAControlePrixGetArticle
    {
        public Detail Detail { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponsePDAControlePrixGetArticle Response_PDAControlePrixGetArticle { get; set; }
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

    public class InfoArticleControlePrixResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
