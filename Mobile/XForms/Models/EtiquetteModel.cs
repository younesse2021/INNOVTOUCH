using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XForms.Models
{
    public partial class EtiquetteProductModel
    {
        [JsonProperty("barCode")]
        public string BarCode { get; set; }

        [JsonProperty("articleLabel")]
        public string ArticleLabel { get; set; }

        [JsonProperty("articleCinr")]
        public string ArticleCinr { get; set; }

        [JsonProperty("articleCinv")]
        public string ArticleCinv { get; set; }

        [JsonProperty("salesPrice")]
        public string SalesPrice { get; set; }

        [JsonProperty("default")]
        public DefaultModel Default { get; set; }

        [JsonProperty("max")]
        public string Max { get; set; }
    }

    public partial class EtiquetteProductModel
    {
        public int NbrOfEtiquettes { get; set; }
    }

    public partial class EtiquetteFormatModel
    {
        [JsonProperty("formatID")]
        public SectionModel FormatId { get; set; }

        [JsonProperty("formatDescription")]
        public SectionModel FormatDescription { get; set; }
    }

    public class CreateEtiquetteModel
    {
        public string username { get; set; }

        public string password { get; set; }
        public string site { get; set; }

        public List<ArticlesEtiquetteModel> listeArticles { get; set; }
    }

    public class ArticlesEtiquetteModel
    {
        [JsonProperty("barCode")]
        public string BarCode { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("articleCinr")]
        public string ArticleCinr { get; set; }

        [JsonProperty("articleCinv")]
        public string ArticleCinv { get; set; }

        [JsonProperty("formatOfEtiquettes")]
        public string FormatOfEtiquettes { get; set; }

        [JsonProperty("numberOfEtiquettes")]
        public string NumberOfEtiquettes { get; set; }

        [JsonProperty("codeEtiquette")]
        public string CodeEtiquette { get; set; }
    }

    public class ImprimerEtiquetteModel
    {
        public string lot { get; set; }
        public string site { get; set; }
        public string format_type { get; set; }
    }
}