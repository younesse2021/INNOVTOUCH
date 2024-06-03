using Newtonsoft.Json;
using Shared.Models.IN;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XForms.Models;

namespace XForms.Models
{
    public class CessionInterModel
    {
        [JsonProperty("codearticle")]
        public string CodeArticle { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("prixcession")]
        public string PrixCession { get; set; }
        [JsonProperty("qtestock")]
        public string QteStock { get; set; }
        [JsonProperty("poids")]
        public string Poids { get; set; }
    }
}




public class CessionInterInitResponse
{

    [JsonProperty("siteGereEnStock")]
    public SectionModel SiteGereEnStock { get; set; }

    [JsonProperty("droitsPrixCession")]
    public SectionModel DroitsPrixCession { get; set; }

    [JsonProperty("stockExceededManagement")]
    public SectionModel StockExceededManagement { get; set; }

    [JsonProperty("modeSaisiPdsQte")]
    public SectionModel ModeSaisiPdsQte { get; set; }

}

public partial class CessionInterScanResponse
{
    [JsonProperty("codeOK")]
    public string CodeOk { get; set; }

    [JsonProperty("libelle")]
    public SectionModel Libelle { get; set; }

    [JsonProperty("articleCode")]
    public string ArticleCode { get; set; }

    [JsonProperty("artustk")]
    public SectionModel Artustk { get; set; }

    [JsonProperty("arlpmoy")]
    public SectionModel Arlpmoy { get; set; }

    [JsonProperty("artcomp")]
    public SectionModel Artcomp { get; set; }

    [JsonProperty("seqvl")]
    public SectionModel Seqvl { get; set; }

    [JsonProperty("cinl")]
    public SectionModel Cinl { get; set; }

    [JsonProperty("stockDispoQte")]
    public string StockDispoQte { get; set; }

    [JsonProperty("stockDispoPds")]
    public string StockDispoPds { get; set; }

    [JsonProperty("stockUnite")]
    public string StockUnite { get; set; }

    [JsonProperty("prixCession")]
    public SectionModel PrixCession { get; set; }

    [JsonProperty("prixVenteTVACode")]
    public SectionModel PrixVenteTvaCode { get; set; }

    [JsonProperty("prixVenteTVALibelle")]
    public SectionModel PrixVenteTvaLibelle { get; set; }

    [JsonProperty("prixVenteTVARate")]
    public SectionModel PrixVenteTvaRate { get; set; }

    [JsonProperty("prixVente")]
    public string PrixVente { get; set; }

    [JsonProperty("listes")]
    public SectionModel Listes { get; set; }

}


public partial class CessionInterScanResponse
{
    [JsonIgnore]
    public bool IsQuantity => (StockUnite ?? "").ToLower().Equals("piece");

    [JsonIgnore]
    public bool IsPoids => !(StockUnite ?? "").ToLower().Equals("piece");
}

public class CessionInterScanCedeResponse
{
    [JsonProperty("codeOK")]
    public string CodeOk { get; set; }

    [JsonProperty("libelle")]
    public SectionModel Libelle { get; set; }

    [JsonProperty("articleCode")]
    public string ArticleCode { get; set; }

    [JsonProperty("artustk")]
    public SectionModel Artustk { get; set; }

    [JsonProperty("arlpmoy")]
    public SectionModel Arlpmoy { get; set; }

    [JsonProperty("artcomp")]
    public SectionModel Artcomp { get; set; }

    [JsonProperty("seqvl")]
    public SectionModel Seqvl { get; set; }

    [JsonProperty("cinl")]
    public SectionModel Cinl { get; set; }

    [JsonProperty("stockDispoQte")]
    public string StockDispoQte { get; set; }

    [JsonProperty("stockDispoPds")]
    public string StockDispoPds { get; set; }

    [JsonProperty("stockUnite")]
    public string StockUnite { get; set; }

    [JsonProperty("prixCession")]
    public SectionModel PrixCession { get; set; }

    [JsonProperty("prixVenteTVACode")]
    public SectionModel PrixVenteTvaCode { get; set; }

    [JsonProperty("prixVenteTVALibelle")]
    public SectionModel PrixVenteTvaLibelle { get; set; }

    [JsonProperty("prixVenteTVARate")]
    public SectionModel PrixVenteTvaRate { get; set; }

    [JsonProperty("prixVente")]
    public string PrixVente { get; set; }

    [JsonProperty("listes")]
    public SectionModel Listes { get; set; }
}

public partial class ValidateCartRequestModel : ArticleModel
{
    [JsonProperty("prix_cession")]
    public string PrixCession { get; set; }

    [JsonProperty("list_articles")]
    public List<CarttArticle> ListArticles { get; set; }
}

public partial class ValidateCartResponseModel
{
    [JsonProperty("code")]
    public SectionModel Code { get; set; }

    [JsonProperty("report")]
    public SectionModel Report { get; set; }
}

public partial class CarttArticle : BindableObject
{

    [JsonProperty("prix_cession")]
    public string PrixCession { get; set; }

    [JsonProperty("orig")]
    public Dest Orig { get; set; }

    [JsonProperty("dest")]
    public Dest Dest { get; set; }
}

public partial class Dest 
{
    [JsonProperty("Code")]
    public string Code { get; set; }

    [JsonProperty("Libelle")]
    public string Libelle { get; set; }

    [JsonProperty("Cinl")]

    public string Cinl { get; set; }

    [JsonProperty("Seqvl")]

    public string Seqvl { get; set; }

    [JsonProperty("PrixVente")]
    public string PrixVente { get; set; }

    [JsonProperty("TVACode")]

    public string TvaCode { get; set; }

    [JsonProperty("TVADesc")]
    public string TvaDesc { get; set; }

    [JsonProperty("TVARate")]

    public string TvaRate { get; set; }

    [JsonProperty("Artustk")]

    public string Artustk { get; set; }

    [JsonProperty("Arlpmoy")]

    public string Arlpmoy { get; set; }

    [JsonProperty("Artcomp")]

    public string Artcomp { get; set; }

    [JsonProperty("Qte")]
    public string Qte { get; set; }

    [JsonProperty("Poids")]
    public string Poids { get; set; }

    [JsonProperty("CodeRegrpt")]

    public string CodeRegrpt { get; set; }

    [JsonProperty("StockDispoQte")]
    public string StockDispoQte { get; set; }

    [JsonProperty("StockDispoPds")]
    public string StockDispoPds { get; set; }

    [JsonProperty("StockUnite")]
    public string StockUnite { get; set; }
}

[PropertyChanged.AddINotifyPropertyChangedInterface]
public partial class Dest
{
    [JsonIgnore]
    public bool IsQuantity => StockUnite.ToLower().Equals("piece");

    [JsonIgnore]
    public string StockUniteTitle => IsQuantity ? "Quantité" : "Poids";

    [JsonIgnore]
    public string StockUniteValue => IsQuantity ? Qte : Poids;

    [JsonIgnore]
    public bool IsModify { get; set; }

    [JsonIgnore]
    public string GlyphCart => IsModify ? XForms.Resources.FontAwesomeFonts.Check : XForms.Resources.FontAwesomeFonts.Pen;

    public string NewStockUniteValue { get; set; }
}