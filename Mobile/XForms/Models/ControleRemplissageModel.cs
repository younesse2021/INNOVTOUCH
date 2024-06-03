using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XForms.Models
{
   public partial class ControleRemplissageModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }

        [JsonProperty("barCode")]
        public string barCode { get; set; }
        public string Table { get; set; }
        public string Poste { get; set; }

    }
    public partial class ControleRemplissageResponse
    {
        public parpost parpost { get; set; }
        public tparlibl tparlibl { get; set; }
        public tparlibc tparlibc { get; set; }
        public parvac1 parvac1 { get; set; }
        public parvac2 parvac2 { get; set; }
        public parvan1 parvan1 { get; set; }
        public parvan2 parvan2 { get; set; }
        public parvan3 parvan3 { get; set; }
        public parvan4 parvan4 { get; set; }
        public pardate pardate { get; set; }
        public tparcomm tparcomm { get; set; }
        public paraccess paraccess { get; set; }
    }

    public class parpost
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class tparlibl
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class paraccess
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class tparlibc
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class parvac1
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class parvac2
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class parvan1
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class parvan2
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class parvan3
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class parvan4
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class pardate
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class tparcomm
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class CheckHeureScanningResponse
    {
        public string valeur { get; set; }
    }

    public class ResponseDataGWSCheckHeureScanningResponse
    {
        public CheckHeureScanningResponse CheckHeureScan { get; set; }
    }

    public partial class ArticleInfoCtrlRempResponse
    {
        public string barCode { get; set; }
        public string cinv { get; set; }
        public string articleLabel { get; set; }
        public string qteDisponible { get; set; }
        public string uniteQte { get; set; }
        public string nbJr { get; set; }
        public string qteLivrasion { get; set; }
        public string dateLivrasion { get; set; }
        public string cinCde { get; set; }
        public string numLignePrix { get; set; }
        public string noCommande { get; set; }
        public string lineCommande { get; set; }
        public string qteCommande { get; set; }
        public string qteCommandeCumul { get; set; }
        public string dateCommande { get; set; }
        public string qteEngage { get; set; }
        public string qteRAL { get; set; }
        public string qteMovementStock { get; set; }
        public string dateMovementStock { get; set; }
        public string descMovementStock { get; set; }
    }
}

