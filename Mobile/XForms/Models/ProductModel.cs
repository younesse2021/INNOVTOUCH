using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XForms.Models
{
    public partial class ProductModel
    {
        public string CODE_INT { get; set; }
        public DateTime DATE_CREATION { get; set; }
        public string ETAT { get; set; }
        public string LIB_ETAT_ARTICLE { get; set; }
        public string LIBELLE { get; set; }
        public string CODE_GRP { get; set; }
        public string GRP { get; set; }
        public string CODE_DEP { get; set; }
        public string DEP { get; set; }
        public string CODE_RAY { get; set; }
        public string RAY { get; set; }
        public string CODE_FAM { get; set; }
        public string FAM { get; set; }
        public string CODE_SFAM { get; set; }
        public string SFAM { get; set; }
        public string CODE_SSFAM { get; set; }
        public string SSFAM { get; set; }
        public string CODE_CAISSE { get; set; }
    }

    public class ProductInfosByEanModel
    {
        [JsonProperty("infoArticle")]
        public InfoArticleModel InfoArticle { get; set; }

        [JsonProperty("infoStock")]
        public InfoStockModel InfoStock { get; set; }

        [JsonProperty("infoVente")]
        public InfoVenteModel InfoVente { get; set; }
    }

    public partial class InfoArticleModel
    {
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("cinr")]
        public string Cinr { get; set; }

        [JsonProperty("orderable")]
        public string Orderable { get; set; }

        [JsonProperty("orderableFrom")]
        public string OrderableFrom { get; set; }

        [JsonProperty("orderableTo")]
        public string OrderableTo { get; set; }

        [JsonProperty("orderableUnit")]
        public string OrderableUnit { get; set; }

        [JsonProperty("orderableUnitLabel")]
        public string OrderableUnitLabel { get; set; }

        [JsonProperty("uauvc")]
        public string Uauvc { get; set; }

        [JsonProperty("prixPermanent")]
        public string PrixPermanent { get; set; }

        [JsonProperty("prixPromo")]
        public string PrixPromo { get; set; }

        [JsonProperty("osCode")]
        public string OsCode { get; set; }

        [JsonProperty("osDesc")]
        public string OsDesc { get; set; }

        [JsonProperty("osFrom")]
        public string OsFrom { get; set; }

        [JsonProperty("osTo")]
        public string OsTo { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("contenanceRayon")]
        public string ContenanceRayon { get; set; }

        [JsonProperty("stockPresentation")]
        public string StockPresentation { get; set; }

        [JsonProperty("facing")]
        public string Facing { get; set; }

        [JsonProperty("cinv")]
        public string Cinv { get; set; }

        [JsonProperty("etat")]
        public string Etat { get; set; }

        [JsonProperty("etatlibl")]
        public string Etatlibl { get; set; }

        [JsonProperty("ean")]
        public string Ean { get; set; }

        [JsonProperty("refreshFunction")]
        public string RefreshFunction { get; set; }
    }

    public partial class InfoStockModel
    {
        [JsonProperty("barCode")]
        public string BarCode { get; set; }

        [JsonProperty("cinv")]
        public string Cinv { get; set; }

        [JsonProperty("articleLabel")]
        public string ArticleLabel { get; set; }

        [JsonProperty("qteDisponible")]
        public string QteDisponible { get; set; }

        [JsonProperty("uniteQte")]
        public string UniteQte { get; set; }

        [JsonProperty("nbJr")]
        public string NbJr { get; set; }

        [JsonProperty("qteLivrasion")]
        public string QteLivrasion { get; set; }

        [JsonProperty("dateLivrasion")]
        public string DateLivrasion { get; set; }

        [JsonProperty("cinCde")]
        public string CinCde { get; set; }

        [JsonProperty("numLignePrix")]
        public string NumLignePrix { get; set; }

        [JsonProperty("noCommande")]
        public string NoCommande { get; set; }

        [JsonProperty("lineCommande")]
        public string LineCommande { get; set; }

        [JsonProperty("qteCommande")]
        public string QteCommande { get; set; }

        [JsonProperty("qteCommandeCumul")]
        public string QteCommandeCumul { get; set; }

        [JsonProperty("dateCommande")]
        public string DateCommande { get; set; }

        [JsonProperty("qteEngage")]
        public string QteEngage { get; set; }

        [JsonProperty("qteRAL")]
        public string QteRal { get; set; }

        [JsonProperty("qteMovementStock")]
        public string QteMovementStock { get; set; }

        [JsonProperty("dateMovementStock")]
        public string DateMovementStock { get; set; }

        [JsonProperty("descMovementStock")]
        public string DescMovementStock { get; set; }
    }

    public partial class InfoVenteModel
    {
        [JsonProperty("barCodeIV")]
        public string BarCodeIv { get; set; }

        [JsonProperty("articleLabel")]
        public string ArticleLabel { get; set; }

        [JsonProperty("ventesJ")]
        public List<string> VentesJ { get; set; }

        [JsonProperty("moyVentesJours")]
        public string MoyVentesJours { get; set; }

        [JsonProperty("varVentesJours")]
        public string VarVentesJours { get; set; }

        [JsonProperty("ventesS")]
        public List<string> VentesS { get; set; }

        [JsonProperty("moyVentesSemaines")]
        public string MoyVentesSemaines { get; set; }

        [JsonProperty("varVentesSemaines")]
        public string VarVentesSemaines { get; set; }

        [JsonProperty("ventesM")]
        public List<string> VentesM { get; set; }

        [JsonProperty("moyVentesMois")]
        public string MoyVentesMois { get; set; }

        [JsonProperty("varVentesMois")]
        public string VarVentesMois { get; set; }
    }
}
