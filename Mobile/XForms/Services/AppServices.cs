using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Shared.DTO.InnovTouch.DTO.Models.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;
using Shared.Models.IN;
using Shared.Models.OUT.ModelsUser;
using XForms.Enums;
using XForms.HttpREST;
using XForms.Models;

namespace XForms.Services
{
    public class AppServices : BaseService
    {
        #region Services
        public async Task<RESTServiceResponse<IEnumerable<ITEM>>> GetServices(ModelsUserModel postParams)
        {
            return await RESTHelper.GetRequest<IEnumerable<ITEM>>(url: AppUrls.PostGetServices, postObject: postParams, method: HttpVerbs.POST);
        }
        #endregion

        #region Inventory

        #region Inventories

        public async Task<RESTServiceResponse<bool>> ValidationLot(InventairesModel postParams)
        {
            return await RESTHelper.GetRequest<bool>(url: AppUrls.ValidationLot, postObject: postParams, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<DetailLot>> GetCodeIn(InventairesModel postParams)
        {
            return await RESTHelper.GetRequest<DetailLot>(url: AppUrls.PostGetCodeIn, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<List<Emplacement>>> GetInventories(InventairesModel postParams)
        {
            return await RESTHelper.GetRequest<List<Emplacement>>(url: AppUrls.PostGetInventories, postObject: null, method: HttpVerbs.GET);
        }
        #endregion

        #region Zone
        public async Task<RESTServiceResponse<IEnumerable<InventoryZoneModel>>> GetZones(ZonesEmplacementsModel postParams)
        {
            return await RESTHelper.GetRequest<IEnumerable<InventoryZoneModel>>(url: AppUrls.PostGetEmplacements, postObject: postParams, method: HttpVerbs.POST);
        }
        #endregion

        #region Scan
        public async Task<RESTServiceResponse<ProductModel>> GetProductInfos(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ProductModel>(url: AppUrls.GetProductInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ProductInfosByEanModel>> GetProductInfosByBarCode(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ProductInfosByEanModel>(url: AppUrls.GetProductInfosByBarCode, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<bool>> PostCreateInventaryProduct(CreateInventaireModel postParams)
        {
            return await RESTHelper.GetRequest<bool>(url: AppUrls.PostCreateInventaryProduct, postObject: postParams, method: HttpVerbs.POST);
        }
        #endregion

        #endregion

        #region EtiquetteRequest

        #region Scan
        public async Task<RESTServiceResponse<EtiquetteProductModel>> GetEtiquetteProductInfos(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<EtiquetteProductModel>(url: AppUrls.GetEtiquetteProductInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<IEnumerable<EtiquetteFormatModel>>> GetFormats(InventairesModel postParams)
        {
            return await RESTHelper.GetRequest<IEnumerable<EtiquetteFormatModel>>(url: AppUrls.GetEtiquetteFormats, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<string>> PostCreateEtiquette(Models.CreateEtiquetteModel postParams)
        {
            return await RESTHelper.GetRequest<string>(url: AppUrls.PostCreateEtiquette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<string>> PostPrintEtiquette(Models.ImprimerEtiquetteModel postParams)
        {
            return await RESTHelper.GetRequest<string>(url: AppUrls.PostPrintEtiquette, postObject: postParams, method: HttpVerbs.POST);
        }
        #endregion

        #endregion

        #region Demarque

        #region Scan
        public async Task<RESTServiceResponse<IEnumerable<DemarqueProductModel>>> GetDemarqueroductInfos(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<IEnumerable<DemarqueProductModel>>(url: AppUrls.GetDemarqueProductInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<string>> PostCreateDemarque(Models.CreateDemarqueModel postParams)
        {
            return await RESTHelper.GetRequest<string>(url: AppUrls.PostCreateDemarque, postObject: postParams, method: HttpVerbs.POST);
        }
        #endregion

        #endregion

        #region CasseFrais

        #region Scan
        public async Task<RESTServiceResponse<CasseFraisProductModel>> GetCasseFraisProductInfos(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<CasseFraisProductModel>(url: AppUrls.GetCasseFraisProductInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<CreateCasseFraisResultModel>> PostCreateCasseFrais(Models.CreateCasseFraisModel postParams)
        {
            return await RESTHelper.GetRequest<CreateCasseFraisResultModel>(url: AppUrls.PostCreateCasseFrais, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<IEnumerable<GetCasseFraisFileModel>>> GetCasseFraisFiles(string _url)
        {
            return await RESTHelper.GetRequest<IEnumerable<GetCasseFraisFileModel>>(url: _url, method: HttpVerbs.GET);
        }

        public async Task<RESTServiceResponse<string>> PostPrintCasseFrais(ImprimerCasseFraisModel postParams)
        {
            return await RESTHelper.GetRequest<string>(url: AppUrls.PostPrintCasseFrais, postObject: postParams, method: HttpVerbs.POST);
        }
        #endregion

        #endregion

        #region PriceControls
        public async Task<RESTServiceResponse<PriceControlDataModel>> GetPriceControls(InventairesModel postParams)
        {
            return await RESTHelper.GetRequest<PriceControlDataModel>(url: AppUrls.PostGetPriceControls, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<PriceControlInfosDataModel>> GetPriceControlInfos(PriceControlArticleModel postParams)
        {
            return await RESTHelper.GetRequest<PriceControlInfosDataModel>(url: AppUrls.GetPriceControlInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<PriceControlProductModel>> GetPriceControlProductInfos(PriceControlArticleModel postParams)
        {
            return await RESTHelper.GetRequest<PriceControlProductModel>(url: AppUrls.GetPriceControlProductInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<string>> PostPrintPriceControl(PriceControlArticleModel postParams)
        {
            return await RESTHelper.GetRequest<string>(url: AppUrls.PostPrintPriceControl, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<object>> PostToEnclosePriceControl(PriceControlArticleModel postParams)
        {
            return await RESTHelper.GetRequest<object>(url: AppUrls.PostToEnclosePriceControl, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<object>> PostCreatePriceControl(PriceControlArticleDataModel postParams)
        {
            return await RESTHelper.GetRequest<object>(url: AppUrls.PostCreatePriceControl, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<DefaultModel>> GetDefaultFormat(PriceControlArticleModel postParams)
        {
            return await RESTHelper.GetRequest<DefaultModel>(url: AppUrls.GetDefaultNumberEtiquette, postObject: postParams, method: HttpVerbs.POST);
        }
        #endregion

        #region Arrivage

        public async Task<RESTServiceResponse<ArrivageDataModel>> GetArrivage(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ArrivageDataModel>(url: AppUrls.GetArrivage, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<string>> GenererNumeroArrivage(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<string>(url: AppUrls.GenererNumeroArrivage, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ArrivageModel>> CheckExistingPalette(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ArrivageModel>(url: AppUrls.CheckExistingPalette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<List <MotifArrivage>>> GetMotifArrivage(ModelsUserModel postParams)
        {
            return await RESTHelper.GetRequest < List < MotifArrivage >> (url: AppUrls.GetMotifArrivage, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<GetAticleResult>> GetInfosArticleArrivage(Models.GetAticleArrivageMagasinModel postParams)
        {
            return await RESTHelper.GetRequest<GetAticleResult>(url: AppUrls.GetArticleArrivage, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ArrivageModel>> PostPaletteComplete(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ArrivageModel>(url: AppUrls.PostPaletteComplete, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ArrivageModel>> PostInsertArrivage(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ArrivageModel>(url: AppUrls.PostInsertArrivage, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ArrivageModel>> PostUpdateArrivage(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ArrivageModel>(url: AppUrls.PostUpdateArrivage, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ArrivageModel>> PostValiderArrivage(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ArrivageModel>(url: AppUrls.PostValiderArrivage, postObject: postParams, method: HttpVerbs.POST);
        }
        #endregion

        #region CessionInterRayon

        public async Task<RESTServiceResponse<CessionInterInitResponse>> PostInitCessionInter(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<CessionInterInitResponse>(url: AppUrls.GetCessionInterRayonInitialisationInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<CessionInterScanResponse>> GetInfoArticleOrigine(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<CessionInterScanResponse>(url: AppUrls.GetCessionInterRayonOriginProductInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<CessionInterScanCedeResponse>> GetInfoArticleDest(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<CessionInterScanCedeResponse>(url: AppUrls.GetCessionInterRayonDestProductInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ValidateCartResponseModel>> PostValidateCart(ValidateCartRequestModel postParams)
        {
            return await RESTHelper.GetRequest<ValidateCartResponseModel>(url: AppUrls.GetCessionInterRayonDestProductInfos, postObject: postParams, method: HttpVerbs.POST);
        }

        #endregion

        #region Facing

        public async Task<RESTServiceResponse<FacingResponse>> GetInfosArticleFacing(FacingRequest postParams)
        {
            return await RESTHelper.GetRequest<FacingResponse>(url: AppUrls.GetInfosArticleFacing, postObject: postParams, method: HttpVerbs.POST);
        }


        public async Task<RESTServiceResponse<string>> UpdateInfosArticleFacing(UpdateFacingRequest postParams)
        {
            return await RESTHelper.GetRequest<string>(url: AppUrls.UpdateInfosArticleFacing, postObject: postParams, method: HttpVerbs.POST);
        }

        #endregion

        #region Reserve

        public async Task<RESTServiceResponse<ReserveResponse>> GenerateNewNumPalette(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveResponse>(url: AppUrls.GenerateNewNumPalette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ReserveArticleResponse>> GetArticlePalette(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveArticleResponse>(url: AppUrls.GetArticlePalette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<MajDetailPaletteData>> MajDetailPalette(CreationArticleInPaletteModel postParams)
        {
            return await RESTHelper.GetRequest<MajDetailPaletteData>(url: AppUrls.MajDetailPalette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ReserveResponse>> EnclosePalette(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveResponse>(url: AppUrls.CloturerPalette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<CheckPaletteResponseData>> CheckPaletteExist(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<CheckPaletteResponseData>(url: AppUrls.CheckPaletteExist, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<InfoZoneEmplResponseData>> GetBorneZoneEmpl(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<InfoZoneEmplResponseData>(url: AppUrls.GetBorneZoneEmpl, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<DataGetContenuPaletteResponse>> GetContenuPalette(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<DataGetContenuPaletteResponse> (url: AppUrls.GetContenuPalette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ReserveStockResponseData>> StokcerPalette(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveStockResponseData>(url: AppUrls.StockerPalette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ReserveResponse>> DescendrePalette(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveResponse>(url: AppUrls.DescendrePalette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ReserveResponse>> GenerateNewNumLot(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveResponse>(url: AppUrls.GenerateNewNumLot, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ReserveArticleResponse>> GetInfoArticleReserve(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveArticleResponse>(url: AppUrls.GetArticleInfoReserve, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ReserveResponse>> ViderPaletteRsv(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveResponse>(url: AppUrls.ViderPalette, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<Models.ReserveArticleResponse>> CreerLotRsv(Models.CreerLotPreparationModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveArticleResponse>(url: AppUrls.CreerLotRsv, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ReserveResponse>> CheckNumLotExist(CreerLotPreparationModel postParams)
        {
            return await RESTHelper.GetRequest<ReserveResponse>(url: AppUrls.CheckNumLotExist, postObject: postParams, method: HttpVerbs.POST);
        }

        #endregion

        #region Commande Specifique

        public async Task<RESTServiceResponse<GeetLotData>> GetLotsCmd(ArticleModel postParams)
        {
            return await RESTHelper.GetRequest<GeetLotData>(url: AppUrls.GetLotsPda, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<CommandeSpecifiqueResponses>> InfoCmd(CommandeSpecifiqueModel postParams)
        {
            return await RESTHelper.GetRequest<CommandeSpecifiqueResponses>(url: AppUrls.InfoPda, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<SaveLotPdaResponseData>> SaveCmd(ArticleCommandeSpecifiqueResponse postParams)
        {
            return await RESTHelper.GetRequest<SaveLotPdaResponseData>(url: AppUrls.SavePda, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<CommandeSpecifiqueResponses>> ValiderArticleCmd(CommandeSpecifiqueModel postParams)
        {
            return await RESTHelper.GetRequest<CommandeSpecifiqueResponses>(url: AppUrls.ValiderArticlePda, postObject: postParams, method: HttpVerbs.POST);
        }

        #endregion

        #region Controle Remplissage

        public async Task<RESTServiceResponse<ControleRemplissageResponse>> GeneralParam(ControleRemplissageModel postParams)
        {
            return await RESTHelper.GetRequest<ControleRemplissageResponse>(url: AppUrls.GeneralParametre, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ResponseDataGWSCheckHeureScanningResponse>> CheckHeureScanning(ControleRemplissageModel postParams)
        {
            return await RESTHelper.GetRequest<ResponseDataGWSCheckHeureScanningResponse>(url: AppUrls.CheckHeureScanningMarj, postObject: postParams, method: HttpVerbs.POST);
        }

        public async Task<RESTServiceResponse<ArticleInfoCtrlRempResponse>> GetInfoStock(ControleRemplissageModel postParams)
        {
            return await RESTHelper.GetRequest<ArticleInfoCtrlRempResponse>(url: AppUrls.GetInfoStockMarj, postObject: postParams, method: HttpVerbs.POST);
        }


        //public async Task<RESTServiceResponse<CommandeSpecifiqueResponses>> updateCtrl(CommandeSpecifiqueModel postParams)
        //{
        //    return await RESTHelper.GetRequest<CommandeSpecifiqueResponses>(url: AppUrls.ValiderArticlePda, postObject: postParams, method: HttpVerbs.POST);
        //}

        #endregion


        public async Task<RESTServiceResponse<bool>> Check_Version_Mobilty(string version)
        {
            return await RESTHelper.GetRequest<bool>(url: AppUrls.CheckVersionApk + version, postObject: null, method: HttpVerbs.GET);
        }
        public async Task<RESTServiceResponse<bool>> Check_Emplacement(ZonesEmplacementsModel Zone)
        {
            return await RESTHelper.GetRequest<bool>(url: AppUrls.CheckEmplacement, postObject: Zone, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<ObservableCollection<ArticleDemarqueTelephoneModel>>> GetListOfPortables(Shared.Models.IN.CreateDemarqueModel demarque)
        {
            return await RESTHelper.GetRequest<ObservableCollection<ArticleDemarqueTelephoneModel>>(url: AppUrls.GetPortables, postObject: demarque, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<ArticleDemarqueTelephoneModel>> GetrticlesDemarqueByTelephone(Shared.Models.IN.CreateDemarqueModel demarque)
        {
            return await RESTHelper.GetRequest<ArticleDemarqueTelephoneModel>(url: AppUrls.GetPortables, postObject: demarque, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<bool>> DeleteOrUpdateOrIntergateOrValideDemarque(AuthDto<ArtcileDemarqueModel> demarque)
        {
            return await RESTHelper.GetRequest<bool>(url: AppUrls.DeleteOrUpdateOrIntergateOrValideDemarque, postObject: demarque, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<bool>> IntegrerListOFDemarquePortables(AuthDto<ObservableCollection<ArticleDemarqueTelephoneModel>> demarque)
        {
            return await RESTHelper.GetRequest<bool>(url: AppUrls.IntgrerDemarquePortables, postObject: demarque, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<bool>> CreateInventaryProductsIn(List<CreateInventaireModel> postParams)
        {
            return await RESTHelper.GetRequest<bool>(url: AppUrls.PostAllInv, postObject: postParams, method: HttpVerbs.POST);
        }

        #region InnovTouch
        public async Task<RESTServiceResponse<ObservableCollection<InnovTouchProduitDto>>> GetAlerts(FiltreInnovTouchDto filter)
        {
            return await RESTHelper.GetRequest<ObservableCollection<InnovTouchProduitDto>>(url: AppUrls.GetAllAlerts, postObject: filter, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<List<string>>> GetFamilleProduits(AuthDto<string> aut)
        {
            return await RESTHelper.GetRequest<List<string>>(url: AppUrls.FamilleProduits, postObject: aut, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<bool>> CreateOrUpdateInnovTouch(AuthDto<InnovTouchProduitDto> InnovTouchProduit)
        {
            return await RESTHelper.GetRequest<bool>(url: AppUrls.CreateOrUpdateInnovTouch, postObject: InnovTouchProduit, method: HttpVerbs.PUT);
        }
        public async Task<RESTServiceResponse<bool>> AppliqueRemise(AuthDto<InnovTouchProduitDto> InnovTouchProduit)
        {
            return await RESTHelper.GetRequest<bool>(url: AppUrls.AppliqueRemise, postObject: InnovTouchProduit, method: HttpVerbs.PUT);
        }
        public async Task<RESTServiceResponse<ProduitDto>> PostGetInfoProduit(AuthDto<string> auto)
        {
            return await RESTHelper.GetRequest<ProduitDto>(url: AppUrls.GetInfoProduitByCode, postObject: auto, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<int>> CreateInnovTouchProduit(AuthDto<InnovTouchProduitDto> auto)
        {
            return await RESTHelper.GetRequest<int>(url: AppUrls.CreateInnovTouch, postObject: auto, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<List<InnovTouchProduitDto>>> GetHestoriqueProduit(AuthDto<string> model)
        {
            return await RESTHelper.GetRequest<List<InnovTouchProduitDto>>(url: AppUrls.GetHostriqueInnovTouch, postObject: model, method: HttpVerbs.POST);
        }
        public async Task<RESTServiceResponse<List<InnovTouchProduitDto>>> GetAllInnovTouchCasseFrais(AuthDto<string> model)
        {
            return await RESTHelper.GetRequest<List<InnovTouchProduitDto>>(url: AppUrls.InnovTouchCasseFrais, postObject: model, method: HttpVerbs.POST);
        }
        #endregion
    }
}
