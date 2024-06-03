using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XForms.Models
{
    public class PriceControlDataModel
    {
        [JsonProperty("control")]
        public List<ControlModel> Control { get; set; }
    }

    public class ControlModel
    {
        [JsonProperty("controlNo")]
        public SectionModel ControlNo { get; set; }

        [JsonProperty("controlLabel")]
        public SectionModel ControlLabel { get; set; }

        [JsonProperty("preparationDate")]
        public SectionModel PreparationDate { get; set; }

        [JsonProperty("preparationDateTrt")]
        public SectionModel PreparationDateTrt { get; set; }

        [JsonProperty("stateCtl")]
        public SectionModel StateCtl { get; set; }

        [JsonProperty("stateCtlLabel")]
        public SectionModel StateCtlLabel { get; set; }

        [JsonProperty("user")]
        public SectionModel User { get; set; }
    }

    public class PriceControlProductModel
    {
        [JsonProperty("tillCode")]
        public SectionModel TillCode { get; set; }

        [JsonProperty("caisseCode")]
        public SectionModel CaisseCode { get; set; }

        [JsonProperty("tillDesc")]
        public SectionModel TillDesc { get; set; }

        [JsonProperty("ventePrice")]
        public SectionModel VentePrice { get; set; }

        [JsonProperty("caissePrice")]
        public SectionModel CaissePrice { get; set; }

        [JsonProperty("intCodeArticleSale")]
        public SectionModel IntCodeArticleSale { get; set; }

        [JsonProperty("cinr")]
        public SectionModel Cinr { get; set; }
    }

    public class PriceControlInfosDataModel
    {
        [JsonProperty("controlNo")]
        public ControlNoModel ControlNo { get; set; }

        [JsonProperty("articles")]
        public ControlArticleModel Articles { get; set; }
    }

    public class ControlArticleModel
    {
        [JsonProperty("article")]
        public List<ControlArticleListModel> Article { get; set; }
    }

    public class ControlNoModel
    {
        [JsonProperty("existintable")]
        public string Existintable { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class ControlArticleListModel
    {
        [JsonProperty("changed")]
        public string Changed { get; set; }

        [JsonProperty("existintable")]
        public string Existintable { get; set; }

        [JsonProperty("known")]
        public long Known { get; set; }

        [JsonProperty("tillCode")]
        public SectionModel TillCode { get; set; }

        [JsonProperty("caisseCode")]
        public SectionModel CaisseCode { get; set; }

        [JsonProperty("tillDesc")]
        public SectionModel TillDesc { get; set; }

        [JsonProperty("salePriceFile")]
        public SectionModel SalePriceFile { get; set; }

        [JsonProperty("salePriceInserted")]
        public SectionModel SalePriceInserted { get; set; }

        [JsonProperty("labelNumber")]
        public SectionModel LabelNumber { get; set; }

        [JsonProperty("seqNum")]
        public SectionModel SeqNum { get; set; }

        [JsonProperty("intCodeArticleSale")]
        public SectionModel IntCodeArticleSale { get; set; }

        [JsonProperty("cinr")]
        public SectionModel Cinr { get; set; }
    }

    public class PriceControlArticleDataModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("codeArticle")]
        public string CodeArticle { get; set; }

        [JsonProperty("existintable")]
        public string Existintable { get; set; }

        [JsonProperty("controlNo")]
        public string ControlNo { get; set; }

        [JsonProperty("listeArticles")]
        public List<PriceControlListArticleModel> ListeArticles { get; set; }
    }

    public class PriceControlListArticleModel
    {
        [JsonProperty("existintable")]
        public string Existintable { get; set; }

        [JsonProperty("changed")]
        public string Changed { get; set; }

        [JsonProperty("TillCode")]
        public string TillCode { get; set; }

        [JsonProperty("CaisseCode")]
        public string CaisseCode { get; set; }

        [JsonProperty("TillDesc")]
        public string TillDesc { get; set; }

        [JsonProperty("VentePrice")]
        public string VentePrice { get; set; }

        [JsonProperty("CaissePrice")]
        public string CaissePrice { get; set; }

        [JsonProperty("intCodeArticleSale")]
        public string IntCodeArticleSale { get; set; }

        [JsonProperty("cinr")]
        public string Cinr { get; set; }

        [JsonProperty("SeqNum")]
        public string SeqNum { get; set; }

        [JsonProperty("RayonPrice")]
        public string RayonPrice { get; set; }

        [JsonProperty("EtiqNumber")]
        public string EtiqNumber { get; set; }
    }

    public class PriceControlArticleModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("controlNo")]
        public string ControlNo { get; set; }

        [JsonProperty("codeArticle")]
        public string CodeArticle { get; set; }

        [JsonProperty("cinr")]
        public string Cinr { get; set; }
    }
}
