using System;

namespace XForms
{
    public class AppUrls
    {
        #region Dev
         //public const string BaseUrl = "http://192.168.1.170:83/api/";
         public const string BaseUrl = "http://localhost:44394/api/";
        //public const string BaseUrl = "http://192.168.137.51:83/api/";
        #endregion

        #region Prod
        //public const string BaseUrl = "https://192.168.99.112/api/";
        #endregion

        public const string POSTLogin = BaseUrl + "auth";

        #region Inventory
        public const string PostGetServices = BaseUrl + "user/models";
        public const string PostGetInventories = BaseUrl + "inventaire/GetAllEmplacement";
        public const string PostGetCodeIn = BaseUrl + "inventaire/GetCodeIn";
        public const string ValidationLot = BaseUrl + "inventaire/ValidationLot";
        public const string PostGetEmplacements = BaseUrl + "zones/emplacements";
        public const string GetProductInfos = BaseUrl + "article";
        public const string GetProductInfosByBarCode = BaseUrl + "articlebyean";
        public const string PostCreateInventaryProduct = BaseUrl + "inventaire/create";
        #endregion

        #region EtiquetteRequest
        public const string GetEtiquetteProductInfos = BaseUrl + "eti/article";
        public const string GetEtiquetteFormats = BaseUrl + "eti/formats";
        public const string PostCreateEtiquette = BaseUrl + "eti/create";
        public const string PostPrintEtiquette = BaseUrl + "eti/imprimer";
        #endregion

        #region - Demarque
        public const string GetDemarqueProductInfos = BaseUrl + "demarque/article";
        public const string PostCreateDemarque = BaseUrl + "demarque/create";
        #endregion

        #region - CasseFrais
        public const string GetCasseFraisProductInfos = BaseUrl + "cassefrais/article";
        public const string PostCreateCasseFrais = BaseUrl + "cassefrais/create";
        public const string GetCasseFraisFiles = BaseUrl + "cassefrais/files";
        public const string PostDownloadCasseFraisFile = BaseUrl + "cassefrais/download";
        public const string PostPrintCasseFrais = BaseUrl + "cassefrais/imprimer";
        #endregion
         
        #region - PriceControl
        public const string PostGetPriceControls = BaseUrl + "controleprix/list";
        public const string GetPriceControlInfos = BaseUrl + "controleprix/getinfosOrgenerate";
        public const string GetPriceControlProductInfos = BaseUrl + "controleprix/article";
        public const string PostPrintPriceControl = BaseUrl + "controleprix/etiquette";
        public const string PostToEnclosePriceControl = BaseUrl + "controleprix/close";
        public const string PostCreatePriceControl = BaseUrl + "controleprix/addorupdate";
        public const string GetDefaultNumberEtiquette = BaseUrl + "controleprix/defaultnumberetiquette";
        #endregion

        #region - Arrivage     
        public const string GenererNumeroArrivage = BaseUrl + "arrivagemagasin/generernumeroarrivage";
        public const string CheckExistingPalette = BaseUrl + "arrivagemagasin/checkpalette";
        public const string GetInfosArticleArrivage = BaseUrl + "facing/getinfosarticle";
        public const string GetArticleArrivage = BaseUrl + "arrivagemagasin/getaticle";
        public const string GetArrivage = BaseUrl + "arrivagemagasin/get";
        public const string GetMotifArrivage = BaseUrl + "arrivagemagasin/motifs";
        public const string PostUpdateArrivage = BaseUrl + "arrivagemagasin/update";
        public const string PostPaletteComplete = BaseUrl + "arrivagemagasin/insertpalettecomplete"; 
        public const string PostInsertArrivage = BaseUrl + "arrivagemagasin/insert";
        public const string PostValiderArrivage = BaseUrl + "arrivagemagasin/insert/valider"; 
        #endregion

        #region - CessionInterRayon
        public const string GetCessionInterRayonInitialisationInfos = BaseUrl + "cessioninterrayons/init";

        public const string GetCessionInterRayonOriginProductInfos = BaseUrl + "cessioninterrayons/getinfosarticleoriginal";
        public const string GetCessionInterRayonDestProductInfos = BaseUrl + "cessioninterrayons/getinfosarticledestinataire";
        public const string PostValidateCessionInterRayonCart = BaseUrl + "cessioninterrayons/valider";
        #endregion

        #region - Facing

        public const string GetInfosArticleFacing = BaseUrl + "facing/getinfosarticle";
        public const string UpdateInfosArticleFacing = BaseUrl + "facing/updateinfosarticle";

        #endregion

        #region - Reserve

        public const string GenerateNewNumPalette = BaseUrl + "reserve/generernumeropalette";
        public const string GetArticleInfoReserve = BaseUrl + "reserve/getarticleinforsv";
        public const string MajDetailPalette = BaseUrl + "reserve/majdetailpalette";
        public const string GetArticlePalette = BaseUrl + "reserve/getarticlepalette";
        public const string CloturerPalette = BaseUrl + "reserve/cloturerpalette";
        public const string CheckPaletteExist = BaseUrl + "reserve/checkpalette";
        public const string StockerPalette = BaseUrl + "reserve/stockerpalette";
        public const string DescendrePalette = BaseUrl + "reserve/descendrepaletteracks";
        public const string GenerateNewNumLot = BaseUrl + "reserve/generatenewnumlot";
        public const string ViderPalette = BaseUrl + "reserve/viderPalette"; 
        public const string CreerLotRsv = BaseUrl + "reserve/creerlotpreparation";
        public const string CheckNumLotExist = BaseUrl + "reserve/checknumlotexist";
        public const string GetBorneZoneEmpl = BaseUrl + "reserve/getborneszoneempl";
        public const string GetContenuPalette = BaseUrl + "reserve/getcontenupalette";
        #endregion

        #region - CommandeSpecifique
        public const string GetLotsPda = BaseUrl + "commandespecifique/getlotspda";
        public const string InfoPda = BaseUrl + "commandespecifique/infocmdpda";
        public const string SavePda = BaseUrl + "commandespecifique/savecmdpda";
        public const string ValiderArticlePda = BaseUrl + "commandespecifique/validerarticlepda";
        #endregion

        #region - ControleRemplissage
        public const string GeneralParametre = BaseUrl + "controleremplissage/generalparam";
        public const string CheckHeureScanningMarj = BaseUrl + "controleremplissage/checkheurescanning";
        public const string GetInfoStockMarj = BaseUrl + "controleremplissage/getinfostock";
        public const string UpdateMobCtrlVisuListeMarj = BaseUrl + "controleremplissage/updateCtrl";
        #endregion

        #region - Check Version Apk
        public const string CheckVersionApk = BaseUrl + "mobile/checkversionvalide/";
        public const string CheckEmplacement = BaseUrl + "zones/emplacements/utilisation";
        public const string GetPortables = BaseUrl + "demarque/telephones";
        public const string DeleteOrUpdateOrIntergateOrValideDemarque = BaseUrl + "demarque/update";
        public const string IntgrerDemarquePortables = BaseUrl + "demarque/integrer";
        public const string PostAllInv = BaseUrl + "inventaire/create/multiple";
        #endregion

        #region - Apis Services InnovTouch
        public const string GetAllAlerts = BaseUrl + "InnovTouchproduits/filtre";
        public const string FamilleProduits = BaseUrl + "familleproduits/libelle";
        public const string CreateOrUpdateInnovTouch = BaseUrl + "InnovTouchproduits/update";
        public const string AppliqueRemise = BaseUrl + "InnovTouchproduits/update";
        public const string GetInfoProduitByCode = BaseUrl + "Produits/search";
        public const string CreateInnovTouch = BaseUrl + "InnovTouchproduits/create";
        public const string CreateOrUpdateDemarque = BaseUrl + "demarque/CreateOrUpdate";
        public const string GetHostriqueInnovTouch = BaseUrl + "InnovTouchproduits/produit";
        public const string InnovTouchCasseFrais = BaseUrl + "InnovTouchproduits/cassefrais";

        #endregion
    }
}