using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.GetInfosArticleDestinataireCassionInterRayonsResponse
{
    public class ArlpmoyGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ArtcompGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ArticleGetInfosArticleDestinataireCassionInterRayons
    {
        public string CodeOK { get; set; }
        public ListesGetInfosArticleDestinataireCassionInterRayons Listes { get; set; }
        public LibelleGetInfosArticleDestinataireCassionInterRayons Libelle { get; set; }
        public string ArticleCode { get; set; }
        public ArtustkGetInfosArticleDestinataireCassionInterRayons Artustk { get; set; }
        public ArlpmoyGetInfosArticleDestinataireCassionInterRayons Arlpmoy { get; set; }
        public ArtcompGetInfosArticleDestinataireCassionInterRayons Artcomp { get; set; }
        public CinlGetInfosArticleDestinataireCassionInterRayons Cinl { get; set; }
        public SeqvlGetInfosArticleDestinataireCassionInterRayons Seqvl { get; set; }
        public PrixVenteTVACodeGetInfosArticleDestinataireCassionInterRayons PrixVenteTVACode { get; set; }
        public PrixVenteTVALibelleGetInfosArticleDestinataireCassionInterRayons PrixVenteTVALibelle { get; set; }
        public PrixVenteTVARateGetInfosArticleDestinataireCassionInterRayons PrixVenteTVARate { get; set; }
        public string PrixVente { get; set; }
    }

    public class ArtustkGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class CinlGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class AuthentificationGetInfosArticleDestinataireCassionInterRayons
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextGetInfosArticleDestinataireCassionInterRayons
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationGetInfosArticleDestinataireCassionInterRayons Authentification { get; set; }
        public ContextGetInfosArticleDestinataireCassionInterRayons Context { get; set; }
    }

    public class LibelleGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ListesGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("@Count")]
        public string Count { get; set; }
    }

    public class PrixVenteTVACodeGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class PrixVenteTVALibelleGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class PrixVenteTVARateGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class ResponseGWSCessIntRayValCodeDGetInfosArticleDestinataireCassionInterRayons
    {
        public ArticleGetInfosArticleDestinataireCassionInterRayons Article { get; set; }
    }

    public class GetInfosArticleDestinataireCassionInterRayonsResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGetInfosArticleDestinataireCassionInterRayons SOAPENVEnvelope { get; set; }
    }

    public class SeqvlGetInfosArticleDestinataireCassionInterRayons
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class SOAPENVBodyGetInfosArticleDestinataireCassionInterRayons
    {
        public ResponseGWSCessIntRayValCodeDGetInfosArticleDestinataireCassionInterRayons Response_GWSCessIntRayValCodeD { get; set; }
    }

    public class SOAPENVEnvelopeGetInfosArticleDestinataireCassionInterRayons
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
        public SOAPENVHeaderGetInfosArticleDestinataireCassionInterRayons SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGetInfosArticleDestinataireCassionInterRayons SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderGetInfosArticleDestinataireCassionInterRayons
    {
        public ParametersGetInfosArticleDestinataireCassionInterRayons Parameters { get; set; }
    }



}
