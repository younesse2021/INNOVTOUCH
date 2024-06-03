using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.GetInfoArticleRsvResponse
{
    public class AuthentificationGetInfoArticleRsvResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextGetInfoArticleRsvResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersGetInfoArticleRsvResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public Authentification Authentification { get; set; }
        public Context Context { get; set; }
    }
    public class SOAPENVHeaderGetInfoArticleRsvResponse
    {
        public Parameters Parameters { get; set; }
    }
    public class DATAGetInfoArticleRsvResponse
    {
        public List <PaletteModel> Palettes { get; set; }
    }
    public class ArticlesGetInfoArticleRsvResponse
    {
        public string CodeArticle { get; set; }
        public string LiblCaisseC { get; set; }
        public string LiblCaisseL { get; set; }
        public string Cinv { get; set; }
        public string Cinr { get; set; }
        public string Ustk { get; set; }
        public string PdsMoyen { get; set; }
        public string QteStock { get; set; }
        public string PdsStock { get; set; }
        public string CinlPCB { get; set; }
        public string NbrUVCparPCB { get; set; }
        public DATAGetInfoArticleRsvResponse DATA  { get; set; } 
    }
    public class PaletteModel
    {
        public string Palette { get; set; }
    }

    public class ArticleInfoRsvResponse
    {
        public ArticlesGetInfoArticleRsvResponse Article { get; set; }
    }
    public class SOAPENVBodyGetInfoArticleRsvResponse
    {
        public ArticleInfoRsvResponse Response_PDARsvGetInfoArticleReserveMarj { get; set; }
    }
    public class SOAPENVEnvelopeGetInfoArticleRsvResponse
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
        public SOAPENVHeaderGetInfoArticleRsvResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetInfoArticleRsvResponse SOAPENVBody { get; set; }
    }
    public class GetInfoArticleRsvResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetInfoArticleRsvResponse SOAPENVEnvelope { get; set; }
    }
}