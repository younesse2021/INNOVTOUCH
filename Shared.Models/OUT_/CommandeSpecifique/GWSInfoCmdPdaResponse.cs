using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.CommandeSpecifique
{
    public class AuthentificationGWSInfoCmdPdaResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
        public ArticleGWSInfoCmdPdaResponse articlesinfocmd { get; set; }
        
    }

    public class ContextGWSInfoCmdPdaResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }

    public class ParametersGWSInfoCmdPdaResponse
    {
        [JsonProperty("-xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationGWSInfoCmdPdaResponse Authentification { get; set; }
        public ContextGWSInfoCmdPdaResponse Context { get; set; }
    }

    public class SOAPENVHeaderGWSInfoCmdPdaResponse
    {
        public ParametersGWSInfoCmdPdaResponse Parameters { get; set; }
    }
    public class ArticleGWSInfoCmdPdaResponse
    {
        public string nolot { get; set; }
        public string cinr { get; set; }
        public string cinl { get; set; }
        public string orderable { get; set; }
        public string label { get; set; }
        public string nCmd { get; set; }
        public string existCmd { get; set; }
        public string existInLot { get; set; }
        public string stockNormal { get; set; }
        public string stonbrjour { get; set; }
        public string encoursCmd { get; set; }
        public string encoursjour { get; set; }
        public string stockEntrepot { get; set; }
        public string moyhebvte { get; set; }
        public string vtedersem { get; set; }
        public string qteProposee { get; set; }
        public string cinv { get; set; }
        public string etat { get; set; }
        public string etatlibl { get; set; }
        public string orderableUnit { get; set; }
        public string orderableUnitLabel { get; set; }
        public string UAUVC { get; set; }
        public string SEQVL { get; set; }
        public string EAN { get; set; }
        public string refreshFunction { get; set; }
    }
    public class ResponsePDAGWSInfoCmdPdaResponse
    {
        public ArticleGWSInfoCmdPdaResponse article { get; set; }
    }


    public class SOAPENVBodyGWSInfoCmdPdaResponse
    {
        public ResponsePDAGWSInfoCmdPdaResponse Response_mjGWSInfoCmdPda { get; set; }
    }
    public class SOAPENVEnvelopeGWSInfoCmdPdaResponse
    {
        [JsonProperty("-xmlns:soapenv")]
        public string XmlnsSoapenv { get; set; }

        [JsonProperty("-xmlns:xsd")]
        public string XmlnsXsd { get; set; }

        [JsonProperty("-xmlns:xsi")]
        public string XmlnsXsi { get; set; }

        [JsonProperty("-xmlns:SOAP-ENV")]
        public string XmlnsSOAPENV { get; set; }

        [JsonProperty("SOAP-ENV:Header")]
        public SOAPENVHeaderGWSInfoCmdPdaResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyGWSInfoCmdPdaResponse SOAPENVBody { get; set; }
    }
    public class ArticleResponseGWSInfoCmdPdaResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeGWSInfoCmdPdaResponse SOAPENVEnvelope { get; set; }
    }
}
    