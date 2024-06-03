using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XForms.Models
{
    public partial class DemarqueProductModel
    {
        [JsonProperty("ean")]
        public string Ean { get; set; }

        [JsonProperty("codeint")]
        public long Codeint { get; set; }

        [JsonProperty("departement")]
        public string Departement { get; set; }

        [JsonProperty("rayon")]
        public string Rayon { get; set; }

        [JsonProperty("famille")]
        public string Famille { get; set; }

        [JsonProperty("sousfamille")]
        public string Sousfamille { get; set; }

        [JsonProperty("libelle")]
        public string Libelle { get; set; }
    }

    public partial class DemarqueProductModel
    {
        public string QteOrWeight { get; set; }
    }


    public class CreateDemarqueModel
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Site")]
        public string Site { get; set; }

        [JsonProperty("TypeDemarque")]
        public string TypeDemarque { get; set; }

        [JsonProperty("ListArticles")]
        public List<ArticlesDemarqueModel> ListArticles { get; set; }
    }

    public partial class ArticlesDemarqueModel
    {
        [JsonProperty("Ean")]
        public string Ean { get; set; }

        [JsonProperty("Conde_int")]
        public string CondeInt { get; set; }

        [JsonProperty("Famille")]
        public string Famille { get; set; }

        [JsonProperty("Sfamille")]
        public string Sfamille { get; set; }

        [JsonProperty("Rayon")]
        public string Rayon { get; set; }

        [JsonProperty("Departement")]
        public string Departement { get; set; }

        [JsonProperty("Qte")]
        public string Qte { get; set; }

        [JsonProperty("Libelle")]
        public string Libelle { get; set; }
    }

    public partial class ArticlesDemarqueModel
    {
        public string QteOrWeightText { get; set; }
    }


    //public partial class Default
    //{
    //    [JsonProperty("formatCode")]
    //    public string FormatCode { get; set; }

    //    [JsonProperty("formatDesc")]
    //    public string FormatDesc { get; set; }

    //    [JsonProperty("text")]
    //    public string Text { get; set; }
    //}

    //public partial class EtiquetteFormatModel
    //{
    //    [JsonProperty("formatID")]
    //    public SectionModel FormatId { get; set; }

    //    [JsonProperty("formatDescription")]
    //    public SectionModel FormatDescription { get; set; }
    //}

    //public class CreateEtiquetteModel
    //{
    //    public string username { get; set; }

    //    public string password { get; set; }
    //    public string site { get; set; }

    //    public List<ArticlesEtiquetteModel> listeArticles { get; set; }
    //}

    //public class ArticlesEtiquetteModel
    //{
    //    [JsonProperty("barCode")]
    //    public string BarCode { get; set; }

    //    [JsonProperty("imageUrl")]
    //    public string ImageUrl { get; set; }

    //    [JsonProperty("articleCinr")]
    //    public string ArticleCinr { get; set; }

    //    [JsonProperty("articleCinv")]
    //    public string ArticleCinv { get; set; }

    //    [JsonProperty("formatOfEtiquettes")]
    //    public string FormatOfEtiquettes { get; set; }

    //    [JsonProperty("numberOfEtiquettes")]
    //    public string NumberOfEtiquettes { get; set; }

    //    [JsonProperty("codeEtiquette")]
    //    public string CodeEtiquette { get; set; }
    //}
}