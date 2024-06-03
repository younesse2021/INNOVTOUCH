using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XForms.Models
{
    public partial class CasseFraisProductModel
    {
        [JsonProperty("code")]
        public SectionModel Code { get; set; }

        [JsonProperty("typeCode")]
        public SectionModel TypeCode { get; set; }

        [JsonProperty("liblCaisseC")]
        public SectionModel LiblCaisseC { get; set; }

        [JsonProperty("liblCaisseL")]
        public SectionModel LiblCaisseL { get; set; }

        [JsonProperty("cinv")]
        public SectionModel Cinv { get; set; }

        [JsonProperty("cinr")]
        public SectionModel Cinr { get; set; }

        [JsonProperty("source")]
        public SectionModel Source { get; set; }

        [JsonProperty("prixVente")]
        public SectionModel PrixVente { get; set; }

        [JsonProperty("sitgbal")]
        public SectionModel Sitgbal { get; set; }

        [JsonProperty("grat")]
        public SectionModel Grat { get; set; }

        [JsonProperty("weightOpFrais")]
        public SectionModel WeightOpFrais { get; set; }

        [JsonProperty("etiFormatCode")]
        public string EtiFormatCode { get; set; }

        [JsonProperty("etiFormatDesc")]
        public string EtiFormatDesc { get; set; }

        [JsonProperty("etiFormatNbr")]
        public long? EtiFormatNbr { get; set; }
    }

    public partial class CasseFraisProductModel
    {
        public string Remise { get; set; }
        public string NewPrice { get; set; }
        public int NbrOfCasseFrais { get; set; }
    }

    public partial class DefaultModel
    {
        [JsonProperty("formatCode")]
        public string FormatCode { get; set; }

        [JsonProperty("formatDesc")]
        public string FormatDesc { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }



    public class CreateCasseFraisModel
    {
        public string username { get; set; }

        public string password { get; set; }
        public string site { get; set; }

        public List<ArticlesCasseFraisModel> listeArticles { get; set; }
    }

    public class CreateCasseFraisResultModel
    {
        [JsonProperty("operationNo")]
        public string OperationNo { get; set; }

        [JsonProperty("lotNo")]
        public string LotNo { get; set; }
    }

    public class ArticlesCasseFraisModel
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("TypeCode")]
        public string TypeCode { get; set; }

        [JsonProperty("LiblCaisseC")]
        public string LiblCaisseC { get; set; }

        [JsonProperty("LiblCaisseL")]
        public string LiblCaisseL { get; set; }

        [JsonProperty("Cinv")]
        public string Cinv { get; set; }

        [JsonProperty("Cinr")]
        public string Cinr { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("PrixVente")]
        public string PrixVente { get; set; }

        [JsonProperty("sitgbal")]
        public string Sitgbal { get; set; }

        [JsonProperty("Grat")]
        public string Grat { get; set; }

        [JsonProperty("WeightOpFrais")]
        public string WeightOpFrais { get; set; }

        [JsonProperty("EtiFormatCode")]
        public string EtiFormatCode { get; set; }

        [JsonProperty("EtiFormatDesc")]
        public string EtiFormatDesc { get; set; }

        [JsonProperty("EtiFormatNbr")]
        public string EtiFormatNbr { get; set; }

        [JsonProperty("Remise")]
        public string Remise { get; set; }

        [JsonProperty("PrixCasseFrais")]
        public string PrixCasseFrais { get; set; }
    }

    public class ImprimerCasseFraisModel
    {
        public string lot { get; set; }
        public string site { get; set; }
        public string format_type { get; set; }
    }

    public class GetCasseFraisFileModel
    {
        public string filename { get; set; }
        public int nbr_etq { get; set; }
    }
}