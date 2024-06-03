using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.CasseFrais
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

    public class Code
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class TypeCode
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class LiblCaisseC
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class LiblCaisseL
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Cinv
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Cinr
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Source
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class PrixVente
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Sitgbal
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Grat
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class WeightOpFrais
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Article
    {
        public Code Code { get; set; }
        public TypeCode TypeCode { get; set; }
        public LiblCaisseC LiblCaisseC { get; set; }
        public LiblCaisseL LiblCaisseL { get; set; }
        public Cinv Cinv { get; set; }
        public Cinr Cinr { get; set; }
        public Source Source { get; set; }
        public PrixVente PrixVente { get; set; }
        public Sitgbal sitgbal { get; set; }
        public Grat Grat { get; set; }
        public WeightOpFrais WeightOpFrais { get; set; }
        public string EtiFormatCode { get; set; }
        public string EtiFormatDesc { get; set; }
        public object EtiFormatNbr { get; set; }
    }

    public class ResponseGWSGetArticleCasseFrais
    {
        public Article Article { get; set; }
    }

    public class SOAPENVBody
    {
        public ResponseGWSGetArticleCasseFrais Response_GWSGetArticleCasseFrais { get; set; }
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
    public class InfosArticleCasseFraisResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelope SOAPENVEnvelope { get; set; }
    }
}
