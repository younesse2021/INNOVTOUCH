using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.GetInfosArticleCessionInterRayonsResponse
{
    public class ArlpmoyGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ArtcompGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ArticleGetInfosArticleCessionInterRayons
    {
        public string CodeOK { get; set; }
        public LibelleGetInfosArticleCessionInterRayons Libelle { get; set; }
        public string ArticleCode { get; set; }
        public ArtustkGetInfosArticleCessionInterRayons Artustk { get; set; }
        public ArlpmoyGetInfosArticleCessionInterRayons Arlpmoy { get; set; }
        public ArtcompGetInfosArticleCessionInterRayons Artcomp { get; set; }
        public SeqvlGetInfosArticleCessionInterRayons Seqvl { get; set; }
        public CinlGetInfosArticleCessionInterRayons Cinl { get; set; }
        public string StockDispoQte { get; set; }
        public string StockDispoPds { get; set; }
        public string StockUnite { get; set; }
        public PrixCessionGetInfosArticleCessionInterRayons PrixCession { get; set; }
        public PrixVenteTVACodeGetInfosArticleCessionInterRayons PrixVenteTVACode { get; set; }
        public PrixVenteTVALibelleGetInfosArticleCessionInterRayons PrixVenteTVALibelle { get; set; }
        public PrixVenteTVARateGetInfosArticleCessionInterRayons PrixVenteTVARate { get; set; }
        public string PrixVente { get; set; }
        public ListesGetInfosArticleCessionInterRayons Listes { get; set; }
    }

    public class ArtustkGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class CinlGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class AuthentificationGetInfosArticleCessionInterRayons
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextGetInfosArticleCessionInterRayons
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersGetInfosArticleCessionInterRayons
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationGetInfosArticleCessionInterRayons Authentification { get; set; }
        public ContextGetInfosArticleCessionInterRayons Context { get; set; }
    }

    public class LibelleGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ListesGetInfosArticleCessionInterRayons
    {
        [JsonProperty("@Count")]
        public string Count { get; set; }
    }

    public class PrixCessionGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class PrixVenteTVACodeGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class PrixVenteTVALibelleGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class PrixVenteTVARateGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ResponseGWSCessIntRayValCodeOGetInfosArticleCessionInterRayons
    {
        public ArticleGetInfosArticleCessionInterRayons Article { get; set; }
    }

    public class GetInfosArticleOriginalCessionInterRayonsResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetInfosArticleCessionInterRayons SOAPENVEnvelope { get; set; }
    }

    public class SeqvlGetInfosArticleCessionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class SOAPENVBodyGetInfosArticleCessionInterRayons
    {
        public ResponseGWSCessIntRayValCodeOGetInfosArticleCessionInterRayons Response_GWSCessIntRayValCodeO { get; set; }
    }

    public class SOAPENVEnvelopeGetInfosArticleCessionInterRayons
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
        public SOAPENVHeaderGetInfosArticleCessionInterRayons SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetInfosArticleCessionInterRayons SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderGetInfosArticleCessionInterRayons
    {
        public ParametersGetInfosArticleCessionInterRayons Parameters { get; set; }
    }


}
