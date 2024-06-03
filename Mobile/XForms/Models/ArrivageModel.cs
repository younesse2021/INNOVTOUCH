using Newtonsoft.Json;
using Shared.Models.IN;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XForms.Models;

namespace XForms.Models
{
    
    public partial class ArrivageResponses
    {
        [JsonProperty("barCode")]
        public string BarCode { get; set; }

        [JsonProperty("articleLabel")]
        public string ArticleLabel { get; set; }

        [JsonProperty("logisticUnitTypeDescription")]
        public string LogisticUnitTypeDescription { get; set; }


        [JsonProperty("uvcUa")]
        public string UvcUa { get; set; }
        [JsonProperty("logisticUnitType")]
        public string LogisticUnitType { get; set; }

    }
}


public partial class ArrivageDataModel
    {
        [JsonProperty("data")]
        public ArrivageModel Data { get; set; }
     
    }


public partial class MotifArrivage
{
    [JsonProperty("parpost")]
    public SectionModel Parpost { get; set; }
    [JsonProperty("tparlibl")]
    public SectionModel Tparlibl { get; set; }

    [JsonProperty("tparlibc")]
    public SectionModel Tparlibc { get; set; }

    [JsonProperty("parvac1")]
    public string Parvac1 { get; set; }

    [JsonProperty("parvan1")]
    public SectionModel Parvan1 { get; set; }
}


public class ArrivageModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("numeroArrivage")]
        public string NumeroArrivage { get; set; }

    [JsonProperty("numArrivage")]
    public string NumArrivage { get; set; }

    [JsonProperty("codeean")]
        public string CodeEan { get; set; }

        [JsonProperty("numeroImmatr")]
        public string NumeroImmatr { get; set; }

    [JsonProperty("numeroPalette")]
        public string NumPalette { get; set; }
        [JsonProperty("nombrePalettes")]
        public string NombrePalettes { get; set; }
        [JsonProperty("nombreArticles")]
        public string NombreArticles { get; set; }
        [JsonProperty("nombrePalettesRejetees")]
        public string NombrePalettesRejetees { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("nombreModification")]
        public string NombreModification { get; set; }
        [JsonProperty("code")]
        public string code { get; set; }
    [JsonProperty("palettecode")]
    public string PaletteCode { get; set; }


}


public partial class PaletteCompletedResponse
{
    [JsonProperty("arrivageNumber")]
    public long ArrivageNumber { get; set; }

    [JsonProperty("numeroImmatr")]
    public long NumeroImmatr { get; set; }
}



//public class 
//{
//    public string arrivageNumber { get; set; }
//    public string numeroImmatr { get; set; }
//    public string nombrePalettes { get; set; }
//    public string nombrePalettesRejetees { get; set; }
//    public string nombreArticles { get; set; }
//    public string date { get; set; }
//    public string nombreModification { get; set; }
//}
