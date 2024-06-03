using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.FacingGetInfosArticle
{
    public class ArticleFacingGetInfosArticleResponse
    {
        public string barCode { get; set; }
        public string articleLabel { get; set; }
        public string linearFacing { get; set; }
        public string linearCapacity { get; set; }
        public string logisticUnitType { get; set; }
        public string logisticUnitTypeDescription { get; set; }
        public string uvcUa { get; set; }
        public string merchandiseMaintCapac { get; set; }
        public string merchandiseMaintFacing { get; set; }
        public string stockPresentation { get; set; }
        public string replenishmentMaintenanceMode { get; set; }
        public string replenishmentMaintenanceType { get; set; }
        public string classe { get; set; }
        public string replenishmentMode { get; set; }
        public string cinv { get; set; }
        public string etat { get; set; }
        public string descetat { get; set; }
        public string niveauDefinition { get; set; }
    }

    public class DATAFacingGetInfosArticleResponse
    {
        public ArticleFacingGetInfosArticleResponse article { get; set; }
    }

    public class AuthentificationFacingGetInfosArticleResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }

    public class ContextFacingGetInfosArticleResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersFacingGetInfosArticleResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationFacingGetInfosArticleResponse Authentification { get; set; }
        public ContextFacingGetInfosArticleResponse Context { get; set; }
    }

    public class ResponseGWSGetArticleParamFacingGetInfosArticleResponse
    {
        public DATAFacingGetInfosArticleResponse DATA { get; set; }
    }

    public class FacingGetInfosArticleResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeFacingGetInfosArticleResponse SOAPENVEnvelope { get; set; }
    }

    public class SOAPENVBodyFacingGetInfosArticleResponse
    {
        public ResponseGWSGetArticleParamFacingGetInfosArticleResponse Response_GWSGetArticleParam { get; set; }
    }

    public class SOAPENVEnvelopeFacingGetInfosArticleResponse
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
        public SOAPENVHeaderFacingGetInfosArticleResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyFacingGetInfosArticleResponse SOAPENVBody { get; set; }
    }

    public class SOAPENVHeaderFacingGetInfosArticleResponse
    {
        public ParametersFacingGetInfosArticleResponse Parameters { get; set; }
    }


}
