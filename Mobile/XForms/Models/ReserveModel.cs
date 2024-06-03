using Newtonsoft.Json;
using Shared.Models.IN;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XForms.Models
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ReserveResponse
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("site")]
        public string Site { get; set; }
        [JsonProperty("numPalette")]
        public string NumPalette { get; set; }
        [JsonProperty("cintPalette")]
        public string CintPalette { get; set; }
        [JsonProperty("zone")]
        public string Zone { get; set; }
        [JsonProperty("emplacement")]
        public string Emplacement { get; set; }
        [JsonProperty("etatPalette")]
        public string EtatPalette { get; set; }
        [JsonProperty("nbArticles")]
        public string NbArticles { get; set; }
        [JsonProperty("numLot")]
        public string numLot { get; set; }

    }
    public class ReserveStockResponseData
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("site")]
        public string Site { get; set; }
        [JsonProperty("numPalette")]
        public string NumPalette { get; set; }
        [JsonProperty("cintPalette")]
        public string CintPalette { get; set; }
        [JsonProperty("zone")]
        public string Zone { get; set; }
        [JsonProperty("emplacement")]
        public string Emplacement { get; set; }
        [JsonProperty("etatPalette")]
        public string EtatPalette { get; set; }
        [JsonProperty("nbArticles")]
        public string NbArticles { get; set; }
        [JsonProperty("numLot")]
        public string numLot { get; set; }
    }
    public partial class CheckPaletteResponseData : ArticleModel
    {
        public ReserveResponse InfoPalette { get; set; }
    }
    public partial class ValidateRsvCartRequestModel : ArticleModel
    {

        [JsonProperty("list_articles")]
        public List<CartRsvArticle> ListRsvArticles { get; set; }
    }
    public partial class ReserveArticleResponse : BindableObject
    {
        [JsonProperty("cintPalette")]
        public string CintPalette { get; set; }
        [JsonProperty("codeOK")]
        public string CodeOk { get; set; }
        [JsonProperty("codeArticle")]
        public string codeArticle { get; set; }

        [JsonProperty("liblCaisseC")]
        public string liblCaisseC { get; set; }

        [JsonProperty("liblCaisseL")]
        public string liblCaisseL { get; set; }

        [JsonProperty("cinv")]

        public string cinv { get; set; }

        [JsonProperty("cinr")]

        public string cinr { get; set; }

        [JsonProperty("ustk")]
        public string ustk { get; set; }

        [JsonProperty("pdsMoyen")]
        public string pdsMoyen { get; set; }

        [JsonProperty("qteStock")]
        public string qteStock { get; set; }

        [JsonProperty("pdsStock")]
        public string pdsStock { get; set; }

        [JsonProperty("qtePalette")]
        public string QtePalette { get; set; }

        [JsonProperty("pdsPalette")]
        public string PdsPalette { get; set; }
        [JsonProperty("nbrUVCparPCB")]
        public string nbrUVCparPCB { get; set; }
        [JsonProperty("cinlPCB")]
        public string cinlPCB { get; set; }
        public string NumLot { get; set; }
        public PaletteListCreationData DATA { get; set; }
        public string QteDemandeePCB { get; set; }
        public string QteDemandeeUVC { get; set; }
        

    }
    public partial class PaletteListCreationData : BindableObject
    {
        public List<PaletteListCreationLotModel> Palettes { get; set; }

    }
    public partial class ArticlesInfoRsvv : BindableObject
    {
        public ReserveArticleResponse article { get; set; }

    }
    public partial class ArticlesCreationPalModel : BindableObject
    {
        public ReserveArticleResponse Article { get; set; }

    }
    public partial class CartRsvArticle : BindableObject
    {
        [JsonProperty("liblCaisseC")]
        public string LiblCaisseC { get; set; }
        [JsonProperty("qteStock")]
        public string qteStock { get; set; }

        [JsonProperty("qteAjoute")]
        public string qteAjoute { get; set; }
        [JsonProperty("qteRetire")]
        public string qteRetire { get; set; }
        [JsonProperty("codeArticle")]
        public string CodeArticle { get; set; }
    }
    public partial class CartInfoArticle : BindableObject
    {
        [JsonProperty("liblCaisseC")]
        public string LiblCaisseC { get; set; }
        [JsonProperty("qteStock")]
        public string qteStock { get; set; }
        [JsonProperty("codeArticle")]
        public string CodeArticle { get; set; }
    }
    public partial class CartRsvPalette : BindableObject
    {
        [JsonProperty("cintPalette")]
        public string CintPalette { get; set; }
        [JsonProperty("zone")]
        public string Zone { get; set; }
        [JsonProperty("emplacement")]
        public string Epmlacement { get; set; }
        [JsonProperty("etatPalette")]
        public string EtatPalette { get; set; }
        [JsonProperty("nbArticles")]
        public string NbArticles { get; set; }

    }
    public partial class CartLot : BindableObject
    {
        [JsonProperty("cintPalette")]
        public string CintPalette { get; set; }
        [JsonProperty("zone")]
        public string Zone { get; set; }
        [JsonProperty("emplacement")]
        public string Epmlacement { get; set; }
        [JsonProperty("etatPalette")]
        public string EtatPalette { get; set; }
        [JsonProperty("nbArticles")]
        public string NbArticles { get; set; }
    }

    public class CreerLotPreparationModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("site")]
        public string Site { get; set; }
        public string NumLot { get; set; }

        public ReserveArticleResponse Article { get; set; }
    }

    public class ArticleListReserve
    {
        public PaletteListCreationData DATA { get; set; }

        public string CodeArticle { get; set; }
        public string LiblCaisseC { get; set; }
        public string LiblCaisseL { get; set; }
        public string Cinv { get; set; }
        public string Cinr { get; set; }
        public string Ustk { get; set; }
        public string PdsMoyen { get; set; }
        public string QteStock { get; set; }
        public string PdsStock { get; set; }
        public string CinlPCB { get; set; }
        public string NbrUVCparPCB { get; set; }
        public string QteDemandeePCB { get; set; }
        public string QteDemandeeUVC { get; set; }
    }

    public class ArticleResseve
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Site { get; set; }
        public string NumLot { get; set; }

        public string CodeArticle { get; set; }
        public string LiblCaisseC { get; set; }
        public string LiblCaisseL { get; set; }
        public string Cinv { get; set; }
        public string Cinr { get; set; }
        public string Ustk { get; set; }
        public string PdsMoyen { get; set; }
        public string QteStock { get; set; }
        public string PdsStock { get; set; }
        public string CinlPCB { get; set; }
        public string NbrUVCparPCB { get; set; }
        public string QteDemandeePCB { get; set; }
        public string QteDemandeeUVC { get; set; }
        public List<PaletteListCreationLotModel> ListPalette { get; set; }
    }

    public class PaletteListCreationLotModel
    {
        public string Palette { get; set; }
    }

    public class DATAGetContenuPaletteResponse
    {
        public List<listArticlesGetContenuPaletteResponse> Articles { get; set; }
    }

    public class listArticlesGetContenuPaletteResponse
    {
        public string Article { get; set; }
    }

    public class DataGetContenuPaletteResponse
    {

        public DATAGetContenuPaletteResponse DATA { get; set; }
    }

    public class GetBornZoneEmplResponseData
    {
        public string BorneMinZone { get; set; }
        public string BorneMaxZone { get; set; }
        public string BorneMinEmpl { get; set; }
        public string BorneMaxEmpl { get; set; }
    }


    public class InfoZoneEmplResponseData
    {
        public GetBornZoneEmplResponseData InfoZoneEmpl { get; set; }
    }

    public partial class ReserveArticleCreationResponse : BindableObject
    {
        [JsonProperty("codeOK")]
        public string CodeOk { get; set; }
        [JsonProperty("codeArticle")]
        public string codeArticle { get; set; }

        [JsonProperty("liblCaisseC")]
        public string liblCaisseC { get; set; }

        [JsonProperty("liblCaisseL")]
        public string liblCaisseL { get; set; }

        [JsonProperty("cinv")]

        public string cinv { get; set; }

        [JsonProperty("cinr")]

        public string cinr { get; set; }

        [JsonProperty("ustk")]
        public string ustk { get; set; }

        [JsonProperty("pdsMoyen")]
        public string pdsMoyen { get; set; }

        [JsonProperty("qteStock")]
        public string qteStock { get; set; }

        [JsonProperty("pdsStock")]
        public string pdsStock { get; set; }

        [JsonProperty("qtePalette")]
        public string QtePalette { get; set; }

        [JsonProperty("pdsPalette")]
        public string PdsPalette { get; set; }
        [JsonProperty("nbrUVCparPCB")]
        public string nbrUVCparPCB { get; set; }
        [JsonProperty("cinlPCB")]
        public string cinlPCB { get; set; }
        [JsonProperty("QteAjoute")]
        public string QteAjoute { get; set; }
        [JsonProperty("PdsAjoute")]
        public string PdsAjoute { get; set; }
        [JsonProperty("QteRetire")]
        public string QteRetire { get; set; }
        [JsonProperty("PdsRetire")]
        public string PdsRetire { get; set; }
        [JsonProperty("NewQtePalette")]
        public string NewQtePalette { get; set; }
        [JsonProperty("NewPdsPalette")]
        public string NewPdsPalette { get; set; }

    }

    public class CreationArticleInPaletteModel
    {
       public CreationArticleInPaletteModel InfoPalette { get; set; }
        public CreationArticleInPaletteModel Article { get; set; }
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("site")]
        public string Site { get; set; }
        public string NumPalette { get; set; }
        [JsonProperty("cintPalette")]
        public string CintPalette { get; set; }
        [JsonProperty("zone")]
        public string Zone { get; set; }
        [JsonProperty("emplacement")]
        public string Epmlacement { get; set; }
        [JsonProperty("etatPalette")]
        public string EtatPalette { get; set; }
        [JsonProperty("nbArticles")]
        public string NbArticles { get; set; }
        [JsonProperty("codeOK")]
        public string CodeOk { get; set; }
        [JsonProperty("codeArticle")]
        public string codeArticle { get; set; }

        [JsonProperty("liblCaisseC")]
        public string liblCaisseC { get; set; }

        [JsonProperty("liblCaisseL")]
        public string liblCaisseL { get; set; }

        [JsonProperty("cinv")]

        public string cinv { get; set; }

        [JsonProperty("cinr")]

        public string cinr { get; set; }

        [JsonProperty("ustk")]
        public string ustk { get; set; }

        [JsonProperty("pdsMoyen")]
        public string pdsMoyen { get; set; }

        [JsonProperty("qteStock")]
        public string qteStock { get; set; }

        [JsonProperty("pdsStock")]
        public string pdsStock { get; set; }

        [JsonProperty("qtePalette")]
        public string QtePalette { get; set; }

        [JsonProperty("pdsPalette")]
        public string PdsPalette { get; set; }
        [JsonProperty("nbrUVCparPCB")]
        public string nbrUVCparPCB { get; set; }
        [JsonProperty("cinlPCB")]
        public string cinlPCB { get; set; }
        [JsonProperty("QteAjoute")]
        public string QteAjoute { get; set; }
        [JsonProperty("PdsAjoute")]
        public string PdsAjoute { get; set; }
        [JsonProperty("QteRetire")]
        public string QteRetire { get; set; }
        [JsonProperty("PdsRetire")]
        public string PdsRetire { get; set; }
        [JsonProperty("NewQtePalette")]
        public string NewQtePalette { get; set; }
        [JsonProperty("NewPdsPalette")]
        public string NewPdsPalette { get; set; }
    }

    public class CreationArticleModel
    {
        public ReserveResponse InfoPalette { get; set; }
        public ReserveArticleCreationResponse Article { get; set; }
    }


    public class MajDetailPaletteData
    {
        public string Username { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public string NumPalette { get; set; }
        public string cintPalette { get; set; }
        public string zone { get; set; }
        public string emplacement { get; set; }
        public string etatPalette { get; set; }
        public string nbArticles { get; set; }
        public string codeOK { get; set; }
        public string codeArticle { get; set; }
        public string liblCaisseC { get; set; }
        public string liblCaisseL { get; set; }
        public string cinv { get; set; }
        public string cinr { get; set; }
        public string ustk { get; set; }
        public string pdsMoyen { get; set; }
        public string qteStock { get; set; }
        public string pdsStock { get; set; }
        public string qtePalette { get; set; }
        public string pdsPalette { get; set; }
        public string QteAjoute { get; set; }
        public string PdsAjoute { get; set; }
        public string QteRetire { get; set; }
        public string PdsRetire { get; set; }
        public string NewQtePalette { get; set; }
        public string NewPdsPalette { get; set; }
    }

}



