using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using FluentValidation;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Shared.Models.IN;
using Shared.Models.OUT.ZonesEmplacements;
using Shared.Models.OUT_.CommandeSpecifique;
using Xamarin.Forms;
using XForms.Data_Sql_Light;
using XForms.Interfaces;
using XForms.Models;
using XForms.Views.Inventory;
using XForms.Views.SharedViews;

namespace XForms.ViewModels.Inventory
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class InventoryViewModel : BaseViewModel
    {
        public string MotifTitle { get; set; } = "Motif";
        public List<ListeArticlesInventaireModelSqlLight> ListOfInv { get; set; }
        public List<ListeArticlesInventaireModelSqlLight> ListOfArticles { get; set; }
        public int Count { get; set; }

        private List<REFItem> MotifListData;
        public string NomEmplacement => Settings.Emplacement == null || string.IsNullOrEmpty(Settings.Emplacement) ? "" : Settings.Emplacement;

        #region Inventories
        public List<Emplacement> InventoriesList { get; set; }
        public Emplacement SelectedInventory { get; set; }

        private Emplacement _SelectedInventoryDto;
        public Emplacement SelectedInventoryDto
        {
            get { return _SelectedInventoryDto; }
            set
            {
                _SelectedInventoryDto = value;
                OnPropertyChanged(nameof(SelectedInventoryDto));
            }
        }

        public bool IsInventoriesLoading { get; set; }

        public bool ISVisibleCount { get; set; }

        public int InventoriesListPosition { get; set; }

        public string PaginationIndex => $"{InventoriesListPosition + 1}/{InventoriesList?.Count() ?? 0}";
        #endregion

        #region Inventory Detail

        private List<InventoryZoneModel> AllEmplacementsList;
        public List<InventoryZoneModel> EmplacementsList { get; set; }
        public List<string> EmplacementsListZone { get; set; }

        public InventoryZoneModel SelectedInventoryZone { get; set; }
        public string SelectedInventoryEmplacement { get; set; }
        #endregion

        #region Scan
        public string ProductBarCode { get; set; } // = "6111018401421";
        public bool ProductBarCodePlaceholderVisibility => string.IsNullOrEmpty(ProductBarCode);
        public string ProductQuantity { get; set; }
        public string ProductWeight { get; set; }

        public bool ProductQuantityEnabled { get; set; }
        public Color ProductQuantityBackgroundColor =>
            ProductQuantityEnabled
            ? AppHelpers.LookupColor("White")
             : AppHelpers.LookupColor("DisabledBackgroundColor");

        public bool ProductWeightEnabled { get; set; }
        public Color ProductWeightBackgroundColor =>
         ProductWeightEnabled
         ? AppHelpers.LookupColor("White")
          : AppHelpers.LookupColor("DisabledBackgroundColor");

        public bool HasProductInfosVisibility { get; set; }
        public Thickness ProductInfosPadding
            => HasProductInfosVisibility
            ? new Thickness(20, 130, 20, 20)
            : new Thickness(20, 130, 20, 20);

        public ProductModel CurrentProductInfos { get; set; }

        public ImageSource ProductImage { get; set; }
        #endregion

        bool CanRefreshBarCode = true;

        public InventoryViewModel(INavigation navigation, ILogger logger = null, IValidator validator = null)
        : base(navigation, logger, validator)
        {
            CanRefresh = true;
            ListOfInv = new List<ListeArticlesInventaireModelSqlLight>();
            ListOfArticles = new List<ListeArticlesInventaireModelSqlLight>();
            GetCountSqlLight();

            this.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(ProductBarCode))
                {
                    ClearProductInfoData(false);
                }
            };
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();
            GetCountSqlLight();

            if (InventoriesList == null || CanRefresh)
            {
                await GetInventoriesData();
            }
        }

        public async void GetCountSqlLight()
        {
            try
            {
                InventaireItemDatabase databaseConcurrent = await InventaireItemDatabase.Instance;
                var Counte = await databaseConcurrent.GetAllInv();
                if (Counte.Count != 0)
                {
                    Count = Counte.Count;
                    ISVisibleCount = true;
                }
                else
                    ISVisibleCount = false;
            }
            catch (Exception)
            {
                Count = 0;
                ISVisibleCount = false;
            }
        }

        #region Data Fonctions
        public async Task GetInventoriesData()
        {
            try
            {
                await SetBusyAsync(async () =>
                {

                    IsInventoriesLoading = true;

                    var postParams = new InventairesModel()
                    {
                        site = Settings.CurrentSiteId,
                        username = Settings.UserName,
                        password = Settings.HashPass,
                    };

                    var result = await App.AppServices.GetInventories(postParams);

                    if (result?.succeeded == true && result?.data != null)
                    {
                        InventoriesList = result.data;
                        CanRefresh = false;
                    }
                    else
                    {
                        AppHelpers.Alert(result.message);
                        InventoriesList = new List<Emplacement>();
                    }
                });
            }
            catch (Exception ex)
            {
                InventoriesList = new List<Emplacement>();
                Logger.LogError(ex);
            }
            finally
            {
                IsInventoriesLoading = false;
            }
        }
        public async Task<IEnumerable<InventoryZoneModel>> GetInventoryEmplacementsData(string inventoryId)
        {
            try
            {
                if (!AppHelpers.IsConnected())
                {
                    AppHelpers.Alert(Localizable.NO_CONNEXION);
                    return null;
                }

                IsInventoriesLoading = true;
                var Resulte = InventoriesList.Where(x => x.Inventory.number == inventoryId).ToList();
                List<InventoryZoneModel> Rayone = new List<InventoryZoneModel>();

                foreach (var item in Resulte)
                {
                    Rayone.Add(new InventoryZoneModel()
                    {
                        CodeExt = item.TypeInventaire == 0 ? "res" : "mag",
                        Code = item.Rayone.Id.ToString(),
                        Desc = item.Rayone.Name,
                        Icon = item.TypeInventaire == 0 ? Resources.FontAwesomeFonts.Boxes.ToString() : Resources.FontAwesomeFonts.Store.ToString(),
                        NumberEmplacement = item.NumberEmplacement
                    });
                }

                if (Rayone.Any())
                {
                    return Rayone;
                }
                else
                {
                    AppHelpers.Alert("Résultats non trouvées");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);

                return null;
            }
            finally
            {
                AppHelpers.LoadingHide();
                IsInventoriesLoading = false;
            }
        }
        public async Task<ProductModel> GetProductInfosData(string inventoryId, string barCode, string stockPosition)
        {
            try
            {

                IsInventoriesLoading = true;

                if (!AppHelpers.IsConnected())
                {
                    AppHelpers.Alert(Localizable.NO_CONNEXION);
                    return null;
                }

                var postParams = new ArticleModel()
                {
                    username = Settings.UserName,
                    password = Settings.HashPass,
                    site = Settings.CurrentSiteId,
                    inventaire = inventoryId,
                    ean = barCode,
                    type = "string"
                };

                var result = await App.AppServices.GetProductInfos(postParams);

                if (result?.succeeded == true && result?.data != null)
                {
                    return result.data;
                }
                else
                {
                    AppHelpers.Alert(result.message);
                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);

                return null;
            }
            finally
            {
                AppHelpers.LoadingHide();
                IsInventoriesLoading = false;
            }
        }
        #endregion

        #region Logic Fonctions

        private void ClearProductInfoData(bool flag = true)
        {
            try
            {
                if (flag)
                {
                    ProductBarCode = "";
                }

                MotifTitle = "Motif";

                ProductQuantity = ProductWeight = "";

                CurrentProductInfos = new ProductModel();

                ProductImage = null;

                HasProductInfosVisibility = false;

                ProductQuantityEnabled = false;
                ProductWeightEnabled = false;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        public async Task<List<REFItem>> GetMotifArrivageData()
        {
            try
            {
                var Items = new List<REFItem>()
                {
                    new REFItem()  { Id = "1" , Name = "Normal" },
                    new REFItem()  { Id = "2" , Name = "Endommagé" },
                    new REFItem()  { Id = "3" , Name = "Inconnu" },
                };

                return Items;
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);

                return null;
            }
            finally
            {
                AppHelpers.LoadingHide();
            }
        }
        #endregion

        #region Commands

        #region Inventories
        private bool CanSelectInventory = true;
        public ICommand SelectInventoryCommand => new Command<Emplacement>(async (model) =>
        {
            try
            {
                CanSelectInventory = false;

                if (model == null)
                    return;

                SelectedInventory = model;
                SelectedInventoryDto = model;


                #region Call Invetaire
                Settings.IdInventaire = model.Inventory.Id;
                Settings.IdRayone = model.Rayone.Id;
                Settings.NumAnvontair = model.Inventory.number;
                #endregion

                var allemplacementsList = await GetInventoryEmplacementsData(Settings.NumAnvontair);

                if (allemplacementsList != null)
                {
                    AllEmplacementsList = allemplacementsList.ToList();

                    SelectedZoneCommand.Execute(1);

                    await Navigation.PushAsync(new InventoryDetailPage() { BindingContext = this }, false);
                }
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanSelectInventory = true;
            }
        }, (_) => CanSelectInventory);
        #endregion

        #region Inventory Detail
        private bool CanSelectInventoryZone = true;
        public ICommand SelectInventoryZoneCommand => new Command<InventoryZoneModel>(async (model) =>
        {
            try
            {
                CanSelectInventoryZone = false;

                AppHelpers.LoadingShow();

                if (model == null)
                    return;

                var allemplacementsList = await GetInventoryEmplacementsData(Settings.NumAnvontair);

                SelectedInventoryZone = model;

                Settings.Rayone = $"{model.Code}-{model.Desc}";

                EmplacementsListZone = new List<string>();

                for (int i = 1; i <= Settings.NumberEmplacement; i++)
                {
                    EmplacementsListZone.Add($"LOT {i}");
                }

                await Navigation.PushAsync(new InventoryEmplacementsPage() { BindingContext = this }, false);
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanSelectInventoryZone = true;
            }
        }, (_) => CanSelectInventoryZone);
        #endregion

        #region Inventory Emplacement Detail
        private bool CanSelectInventoryEmplacement = true;
        public ICommand SelectInventoryEmplacementCommand => new Command<string>(async (model) =>
        {
            try
            {
                CanSelectInventoryEmplacement = false;

                if (model == null)
                    return;

                await Task.Delay(1000);

                await SetBusyAsync(async () =>
                {
                    Settings.Emplacement = model;
                    #region Exits Code In

                    var Postman = new InventairesModel()
                    {
                        site = "",
                        password = "",
                        username = "",
                        IdInventaire = Settings.IdInventaire,
                        IdRayone = Settings.IdRayone,
                        NomEmplacement = model,
                        TypeInventaire = Settings.TypeInventaire
                    };

                    var responce = await App.AppServices.GetCodeIn(Postman);

                    if (responce.succeeded == true && responce.data != null)
                    {
                        Settings.CodeIn = responce.data.CodeIn;
                        Settings.CodeOut = responce.data.CodeOut;
                    }
                    else
                    {
                        AppHelpers.Alert($"acune code in / out exits  avec cette codebarre  : {model}");
                        return;
                    }

                    var popup = new CodeIn();

                    popup.OnEventAcquired += async (object sender, string args) =>
                    {
                        if (args.Equals(Settings.CodeIn))
                        {
                            await PopupNavigation.Instance.PopSafeAsync();
                            await Navigation.PushAsync(new ScanInventoryPage() { BindingContext = this });
                        }
                        else
                        {
                            AppHelpers.Alert($"acune lot barre code in.");
                        }
                    };

                    await PopupNavigation.Instance.PushSingleAsync(popup);

                    #endregion
                });
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanSelectInventoryEmplacement = true;
                AppHelpers.LoadingHide();
            }
        }, (_) => CanSelectInventoryEmplacement);
        #endregion

        private bool CanSelectZone = true;
        public ICommand SelectedZoneCommand => new Command<int>(async (value) =>
        {
            try
            {
                CanSelectZone = false;

                await SetBusyAsync(async () =>
                {
                    var emplacementsList = new List<InventoryZoneModel>();
                    EmplacementsListZone = new List<string>();

                    if (value == 1)
                    {
                        emplacementsList = AllEmplacementsList
                         .Where(x => x.CodeExt.ToLower()
                         .Contains("mag"))
                         .ToList();
                        Settings.TypeInventaire = 1;
                        Settings.NumberEmplacement = emplacementsList.First().NumberEmplacement;
                    }
                    else
                    {
                        emplacementsList = AllEmplacementsList
                          .Where(x => x.CodeExt.ToLower()
                          .Contains("res"))
                          .ToList();
                        Settings.TypeInventaire = 0;
                        Settings.NumberEmplacement = emplacementsList.First().NumberEmplacement;
                    }
                    EmplacementsList = emplacementsList;
                });
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanSelectZone = true;
            }
        }, (_) => CanSelectZone);

        private bool CanScanBarCode = true;
        public ICommand ScanBarCodeCommand => new Command<string>(async (barCode) =>
        {
            try
            {
                CanScanBarCode = false;

                if (!await AppHelpers.CheckSession())
                {
                    return;
                }

                if (string.IsNullOrEmpty(barCode))
                {
                    AppHelpers.Alert("Veuillez scanner le code barre");
                    return;
                }

                if (long.TryParse(barCode, out long _barCode))
                {
                    if (_barCode <= 0)
                    {
                        AppHelpers.Alert("Le code barre doit être supérieure à 0");
                        return;
                    }
                }
                else
                {
                    AppHelpers.Alert("Le code barre doit être numérique");
                    return;
                }

                ProductQuantity = ProductWeight = "";

                var productInfos = await GetProductInfosData(Settings.NumAnvontair, barCode,"");

                if (productInfos != null)
                {
                    CurrentProductInfos = productInfos;

                    HasProductInfosVisibility = true;

                    ProductImage = ImageSource.FromResource("XForms.Resources.Images." + "DefaultImage.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);

                    if (CurrentProductInfos.CODE_GRP == "1")
                    {
                        ProductQuantityEnabled = true;
                        ProductWeightEnabled = false;
                        MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductQuantityEntry);
                    }
                    else
                    {
                        ProductQuantityEnabled = false;
                        ProductWeightEnabled = true;
                        MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductWeigthEntry);
                    }
                }
                else
                {
                    var digitalPrintCancelPopup = new Popups.FeedBackPopup(
                           headerGlyph: Resources.FontAwesomeFonts.Check,
                           headerGlyphBackground: AppHelpers.LookupColor("Success"),
                           title: "Ce produit n'a pas été trouvé.",
                           description: "",
                           confirmActionText: "Ok",
                           hasCancelAction: true,
                           primaryColor: AppHelpers.LookupColor("DarkAction"),
                           secondaryColor: AppHelpers.LookupColor("Primary"),
                           canReturnEvent: true
                           );

                    digitalPrintCancelPopup.OnEventAcquired += async (object sender, bool e) =>
                    {
                            ClearProductInfoData();
                            MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
                            await PopupNavigation.Instance.PopSafeAsync();
                    };
                    await PopupNavigation.Instance.PushSingleAsync(digitalPrintCancelPopup);
                }
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanScanBarCode = true;
            }
        }, (_) => CanScanBarCode);

        private bool CanSaveInventaryProduct = true;
        public ICommand SaveInventaryProductCommand => new Command(async () =>
        {
            try
            {
                CanSaveInventaryProduct = false;
                await SetBusyAsync(async () =>
                {
                    if (!await AppHelpers.CheckSession())
                    {
                        return;
                    }

                    if (string.IsNullOrEmpty(ProductBarCode) ||
                       (string.IsNullOrEmpty(ProductQuantity)
                       && string.IsNullOrEmpty(ProductWeight)))
                    {
                        AppHelpers.Alert("Champs obligatoires");
                        return;
                    }

                    if (long.TryParse(ProductBarCode, out long barCode))
                    {
                        if (barCode < 0)
                        {
                            AppHelpers.Alert("Le code barre doit être supérieur ou égal à 0");
                            return;
                        }
                    }
                    else
                    {
                        AppHelpers.Alert("Le code barre doit être numérique");
                        return;
                    }

                    if (CurrentProductInfos.CODE_GRP == "1")
                    {
                        if (ProductQuantity.Length > 6)
                        {
                            AppHelpers.Alert("Format Incorrect");
                            ProductQuantity = "";
                            MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductQuantityEntry);
                            return;
                        }
                        if (long.TryParse(ProductQuantity, out long productQuantity))
                        {
                            if (productQuantity < 0)
                            {
                                AppHelpers.Alert("La quantité doit être supérieure ou égal à 0");
                                return;
                            }
                        }
                        else
                        {
                            AppHelpers.Alert("La quantité doit être numérique");
                            return;
                        }
                    }
                    else
                    {
                        if (ProductWeight.Length > 7)
                        {
                            AppHelpers.Alert("Format Incorrect");
                            ProductWeight = "";
                            MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductWeigthEntry);
                            return;
                        }
                        if (double.TryParse(ProductWeight, out double productWeight))
                        {
                            if (productWeight < 0)
                            {
                                AppHelpers.Alert("Le poids doit être supérieure ou égal à 0");
                                return;
                            }
                        }
                        else
                        {
                            AppHelpers.Alert("Le poids doit être décimal");
                            return;
                        }
                    }

                    var quantity = "";

                    //Set Quantity
                    if (CurrentProductInfos.CODE_GRP == "1")
                    {
                        quantity = ProductQuantity;
                    }
                    else if (CurrentProductInfos.CODE_GRP == "3"
                    || CurrentProductInfos.CODE_GRP == "4"
                    || CurrentProductInfos.CODE_GRP == "5")
                    {
                        quantity = "1";
                    }

                    var weight = (ProductWeight ?? "").Replace(',', '.');
                    // Add items to  model 

                    // check motif 
                    if (string.IsNullOrEmpty(MotifTitle))
                    {
                        AppHelpers.Alert("Merci de Siser le  Motif.");
                        return;
                    }


                    if (!AppHelpers.IsConnected())
                    {
                        var digitalPrintCancelPopup = new Popups.FeedBackPopup(
                            headerGlyph: Resources.FontAwesomeFonts.Check,
                            headerGlyphBackground: AppHelpers.LookupColor("Success"),
                            title: "La Connexion a échoué",
                            description: "",
                            confirmActionText: "Réessayer",
                            cancelActionText: "Quitter",
                            hasCancelAction: true,
                            primaryColor: AppHelpers.LookupColor("DarkAction"),
                            secondaryColor: AppHelpers.LookupColor("Primary"),
                            canReturnEvent: true
                            );

                        digitalPrintCancelPopup.OnEventAcquired += async (object sender, bool e) =>
                        {
                            if (e)
                            {
                                ClearProductInfoData();
                                await PopupNavigation.Instance.PopSafeAsync();
                                MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
                            }
                            else
                            {
                                await PopupNavigation.Instance.PopSafeAsync();
                            }
                        };
                        await PopupNavigation.Instance.PushSingleAsync(digitalPrintCancelPopup);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ProductBarCode) &&
                          !string.IsNullOrEmpty(Settings.Rayone) &&
                          !string.IsNullOrEmpty(Settings.NumAnvontair) &&
                          !string.IsNullOrWhiteSpace(Settings.Emplacement))
                        {
                            InventaireItemDatabase databaseConcurrent = await InventaireItemDatabase.Instance;

                            List<ListeArticlesInventaireModel> ListHL = new List<ListeArticlesInventaireModel>();

                            List<ListeArticlesInventaireModelSqlLight> OfflineArticles = await databaseConcurrent.GetAllInv();

                            if (OfflineArticles.Count != 0)
                            {
                                foreach (var item in OfflineArticles)
                                {
                                    #region Inventaire Read
                                    ListeArticlesInventaireModel InvenOff = new ListeArticlesInventaireModel();
                                    InvenOff.id = "null";
                                    InvenOff.barcode = item.barcode;
                                    InvenOff.description = item.description;
                                    InvenOff.quantity = item.quantity;
                                    InvenOff.weight = item.weight;
                                    InvenOff.salePrice = "";
                                    InvenOff.externalVariantCode = "";
                                    InvenOff.status = item.status;
                                    InvenOff.internalLogisticCode = "";
                                    InvenOff.intMerchStrucNode = "";
                                    InvenOff.extMerchStrucNode = "";
                                    InvenOff.merchStructureID = "";
                                    InvenOff.invoicingUnit = "";
                                    InvenOff.stockUnit = "";
                                    InvenOff.averageWeight = "";
                                    InvenOff.InventaireId = "null";
                                    InvenOff.seqvl = $"Motif Offline";
                                    ListHL.Add(InvenOff);
                                    #endregion
                                }

                                var ObjectOffline = new CreateInventaireModel()
                                {
                                    username = Settings.UserName,
                                    password = Settings.HashPass,
                                    site = Settings.CurrentSiteId,
                                    inventaire = Settings.NumAnvontair,
                                    type = $"null",
                                    zone = Settings.Rayone,
                                    emplacement = Settings.Emplacement,
                                    ListeArticles = ListHL
                                };


                                var resultOffLigne = await App.AppServices.PostCreateInventaryProduct(ObjectOffline);

                                if (resultOffLigne?.succeeded == true)
                                {
                                    databaseConcurrent.DeleteAllProduit();
                                }
                                else
                                {
                                    AppHelpers.Alert("Résultats non trouvées");
                                }
                            }

                            var storedInventoryProductsList = new List<ListeArticlesInventaireModel>
                            {
                            new ListeArticlesInventaireModel
                            {
                                id = "null",
                                barcode = ProductBarCode,
                                description = CurrentProductInfos.LIBELLE,
                                quantity = quantity,
                                weight = weight,
                                salePrice = "",
                                externalVariantCode = "",
                                status = CurrentProductInfos.LIB_ETAT_ARTICLE,
                                internalLogisticCode = "",
                                intMerchStrucNode = "",
                                extMerchStrucNode = "",
                                merchStructureID = "",
                                invoicingUnit = "",
                                stockUnit = "",
                                averageWeight = "",
                                InventaireId = "null",
                                seqvl = $"{MotifTitle}",
                            }
                        };
                            var postParams = new CreateInventaireModel()
                            {
                                username = Settings.UserName,
                                password = Settings.HashPass,
                                site = Settings.CurrentSiteId,
                                inventaire = Settings.NumAnvontair,
                                type = "string",
                                zone = Settings.Rayone,
                                emplacement = Settings.Emplacement,
                                ListeArticles = storedInventoryProductsList
                            };
                            var result = await App.AppServices.PostCreateInventaryProduct(postParams);
                            if (result?.succeeded == true)
                            {
                                ClearProductInfoData();
                                MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
                            }
                            else
                            {
                                AppHelpers.Alert("Résultats non trouvées");
                            }
                        }
                    }

                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                AppHelpers.LoadingHide();
                GetCountSqlLight();
                CanSaveInventaryProduct = true;
            }
        }, () => CanSaveInventaryProduct);

        private bool CanConfirmCreateInventary = true;
        public ICommand ConfirmCreateInventaryCommand => new Command(async () =>
        {
            try
            {
                CanConfirmCreateInventary = false;

                if (!await AppHelpers.CheckSession())
                {
                    return;
                }

                await Task.Delay(1000);

                #region Code Out

                var popup = new CodeOut();

                popup.OnEventAcquired += async (object sender, string args) =>
                {
                    if (args.Equals(Settings.CodeOut))
                    {
                        await PopupNavigation.Instance.PopSafeAsync();

                        var postman = new InventairesModel()
                        {
                            site = "",
                            password = "",
                            username = "",
                            IdInventaire = Settings.IdInventaire,
                            IdRayone = Settings.IdRayone,
                            NomEmplacement = Settings.Emplacement,
                            TypeInventaire = Settings.TypeInventaire
                        };

                        var result = await App.AppServices.ValidationLot(postman);

                        await Navigation.PushAsync(new InventoriesPage() { BindingContext = this });
                    }
                    else
                    {
                        AppHelpers.Alert($"acune lot barre code in.");
                    }
                };

                await PopupNavigation.Instance.PushSingleAsync(popup);

                #endregion
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                AppHelpers.LoadingHide();
                CanConfirmCreateInventary = true;
            }
        }, () => CanConfirmCreateInventary);

        private bool CanSendAllArticlesTo = true;
        public ICommand CanSendAllArticlesToCommand => new Command(async () =>
        {
            try
            {
                CanSendAllArticlesTo = false;

                InventaireItemDatabase databaseConcurrent = await InventaireItemDatabase.Instance;
                List<CreateInventaireModel> ListOfInvSql = new List<CreateInventaireModel>();

                AppHelpers.LoadingShow();

                if (!await AppHelpers.CheckSession())
                {
                    return;
                }

                if (!AppHelpers.IsConnected())
                {
                    #region Connextion echoue 

                    var digitalPrintCancelPopup = new Popups.FeedBackPopup(
                        headerGlyph: Resources.FontAwesomeFonts.Check,
                        headerGlyphBackground: AppHelpers.LookupColor("Success"),
                        title: "La Connexion a échoué",
                        description: "",
                        confirmActionText: "OK",
                        primaryColor: AppHelpers.LookupColor("Primary"),
                        canReturnEvent: true);

                    digitalPrintCancelPopup.OnEventAcquired += async (object sender, bool e) =>
                    {
                        GetCountSqlLight();
                        await PopupNavigation.Instance.PopSafeAsync();
                    };
                    await PopupNavigation.Instance.PushSingleAsync(digitalPrintCancelPopup);
                    #endregion
                }
                else
                {
                    ListOfArticles = await databaseConcurrent.GetAllInv();

                    var ListOfItem = ListOfInv.Where(x => x.site == Settings.CurrentSiteId).ToList();

                    if (ListOfItem.Count != 0)
                    {
                        foreach (var item in ListOfItem)
                        {
                            #region  Read From Sql Light
                            CreateInventaireModel model = new CreateInventaireModel();

                            model.username = item.username == null || item.username == "" ? Settings.UserName : item.username;
                            model.password = item.password == null || item.password == "" ? Settings.HashPass : item.password;
                            model.site = item.site == null || item.site == "" ? Settings.CurrentSiteId : item.site;

                            model.inventaire = item.inventaire;
                            model.type = item.type;
                            model.zone = item.zone;
                            model.emplacement = item.emplacement;

                            model.ListeArticles = new List<ListeArticlesInventaireModel>()
                            {
                                new ListeArticlesInventaireModel()
                                {

                                    barcode = item.barcode == null ? "" : item.barcode,
                                    description = item.description == null ? "" : item.description,
                                    quantity = item.quantity == null ? "" : item.quantity,
                                    weight = item.weight == null ? "" : item.weight,
                                    salePrice = item.salePrice == null ? "" : item.salePrice,
                                    externalVariantCode =  item.externalVariantCode == null ? "" : item.externalVariantCode,
                                    status = item.status == null ? "" : item.status,
                                    internalLogisticCode =  item.internalLogisticCode == null ? "" : item.internalLogisticCode,
                                    intMerchStrucNode =  item.intMerchStrucNode == null ? "" : item.intMerchStrucNode,
                                    extMerchStrucNode = item.extMerchStrucNode == null ? "" : item.extMerchStrucNode,
                                    merchStructureID = item.merchStructureID == null ? "" : item.merchStructureID,
                                    invoicingUnit =  item.invoicingUnit == null ? "" : item.invoicingUnit,
                                    stockUnit = item.stockUnit == null ? "" : item.stockUnit,
                                    averageWeight =  item.averageWeight == null ? "" : item.averageWeight,
                                    seqvl =  item.seqvl == null ? "" : item.seqvl,

                                }
                            };

                            ListOfInvSql.Add(model);
                            #endregion
                        }

                        var ResulteOfSendInv = await App.AppServices.CreateInventaryProductsIn(ListOfInvSql);

                        if (ResulteOfSendInv?.succeeded == true && ResulteOfSendInv.data == true)
                        {
                            #region Add all Sql light item to   

                            Count = 0;

                            databaseConcurrent.DeleteAllProduit();

                            ListOfInv.Clear();

                            ClearProductInfoData();

                            var digitalPrintCancelPopup = new Popups.FeedBackPopup(
                                headerGlyph: Resources.FontAwesomeFonts.Check,
                                headerGlyphBackground: AppHelpers.LookupColor("Success"),
                                title: "les Articles à envoyer avec succès",
                                description: "",
                                confirmActionText: "OK",
                                primaryColor: AppHelpers.LookupColor("Primary"),
                                canReturnEvent: true);
                            digitalPrintCancelPopup.OnEventAcquired += async (object sender, bool e) =>
                            {
                                await PopupNavigation.Instance.PopSafeAsync();
                            };
                            await PopupNavigation.Instance.PushSingleAsync(digitalPrintCancelPopup);

                            MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
                            #endregion
                        }
                        else
                        {
                            AppHelpers.Alert("Résultats non trouvées");
                        }
                    }
                    else
                    {
                        ClearProductInfoData();
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                AppHelpers.LoadingHide();
                CanSendAllArticlesTo = true;
            }
        }, () => CanSendAllArticlesTo);
        public async Task SetBusyAsync(Func<Task> func, string loadingMessage = null)
        {
            if (loadingMessage == null)
            {
                loadingMessage = "Chargement ...";
            }

            UserDialogs.Instance.ShowLoading(loadingMessage, MaskType.Black);

            try
            {
                await func();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
        private bool CanGoBackAsyncPage = true;
        public ICommand CanNvigationPage => new Command(async () =>
        {
            try
            {
                CanGoBackAsyncPage = false;

                var popup = new CodeOut();

                popup.OnEventAcquired += async (object sender, string args) =>
                {
                    if (args.Equals(Settings.CodeOut))
                    {
                        await PopupNavigation.Instance.PopSafeAsync();

                        var Object = new InventairesModel()
                        {
                            site = "",
                            password = "",
                            username = "",
                            IdInventaire = Settings.IdInventaire,
                            IdRayone = Settings.IdRayone,
                            NomEmplacement = Settings.Emplacement,
                            TypeInventaire = Settings.TypeInventaire
                        };
                        var result = await App.AppServices.ValidationLot(Object);
                        await Navigation.PushAsync(new InventoriesPage() { BindingContext = this });
                    }
                    else
                    {
                        AppHelpers.Alert($"Acune lot barre code in.");
                    }
                };

                await PopupNavigation.Instance.PushSingleAsync(popup);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                AppHelpers.LoadingHide();
                CanGoBackAsyncPage = true;
            }
        }, () => CanGoBackAsyncPage);

        private bool CanSendOfflineProduit = true;
        public ICommand CanSendOfflineProduitCommand => new Command(async () =>
        {
            try
            {
                CanSendOfflineProduit = false;

                if (!await AppHelpers.CheckSession())
                {
                    return;
                }

                await SetBusyAsync(async () =>
                {
                    if (!AppHelpers.IsConnected())
                    {
                        var digitalPrintCancelPopup = new Popups.FeedBackPopup(
                            headerGlyph: Resources.FontAwesomeFonts.Check,
                            headerGlyphBackground: AppHelpers.LookupColor("Success"),
                            title: "La Connexion a échoué",
                            description: "",
                            confirmActionText: "Réessayer",
                            cancelActionText: "Quitter",
                            hasCancelAction: true,
                            primaryColor: AppHelpers.LookupColor("DarkAction"),
                            secondaryColor: AppHelpers.LookupColor("Primary"),
                            canReturnEvent: true
                            );

                        digitalPrintCancelPopup.OnEventAcquired += async (object sender, bool e) =>
                        {
                            if (e)
                            {
                                ClearProductInfoData();
                                await PopupNavigation.Instance.PopSafeAsync();
                                MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
                            }
                            else
                            {
                                await PopupNavigation.Instance.PopSafeAsync();
                            }
                        };
                        await PopupNavigation.Instance.PushSingleAsync(digitalPrintCancelPopup);
                    }
                    else
                    {
                        InventaireItemDatabase databaseConcurrent = await InventaireItemDatabase.Instance;

                        List<ListeArticlesInventaireModel> ListHL = new List<ListeArticlesInventaireModel>();

                        List<ListeArticlesInventaireModelSqlLight> OfflineArticles = await databaseConcurrent.GetAllInv();

                        if (OfflineArticles.Count != 0)
                        {
                            foreach (var item in OfflineArticles)
                            {
                                #region Inventaire Read
                                ListeArticlesInventaireModel InvenOff = new ListeArticlesInventaireModel();
                                InvenOff.id = "null";
                                InvenOff.barcode = item.barcode;
                                InvenOff.description = item.description;
                                InvenOff.quantity = item.quantity;
                                InvenOff.weight = item.weight;
                                InvenOff.salePrice = "";
                                InvenOff.externalVariantCode = "";
                                InvenOff.status = item.status;
                                InvenOff.internalLogisticCode = "";
                                InvenOff.intMerchStrucNode = "";
                                InvenOff.extMerchStrucNode = "";
                                InvenOff.merchStructureID = "";
                                InvenOff.invoicingUnit = "";
                                InvenOff.stockUnit = "";
                                InvenOff.averageWeight = "";
                                InvenOff.InventaireId = "null";
                                InvenOff.seqvl = "";
                                ListHL.Add(InvenOff);
                                #endregion
                            }

                            var ObjectOffline = new CreateInventaireModel()
                            {
                                username = Settings.UserName,
                                password = Settings.HashPass,
                                site = Settings.CurrentSiteId,
                                inventaire = Settings.NumAnvontair,
                                type = "string",
                                zone = Settings.Rayone,
                                emplacement = Settings.Emplacement,
                                ListeArticles = ListHL
                            };

                            var resultOffLigne = await App.AppServices.PostCreateInventaryProduct(ObjectOffline);

                            if (resultOffLigne?.succeeded == true)
                            {
                                databaseConcurrent.DeleteAllProduit();
                                ClearProductInfoData();
                                MessagingCenter.Send<InventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
                            }
                            else
                            {
                                AppHelpers.Alert("Résultats non trouvées");
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                GetCountSqlLight();
                CanSendOfflineProduit = true;
            }
        }, () => CanSendOfflineProduit);

        private bool BackToHomePage = true;
        public ICommand BackToHomePageCommand => new Command(async () =>
        {
            try
            {
                BackToHomePage = false;
                Application.Current.MainPage = new NavigationPage(new Views.Home.HomePage());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                BackToHomePage = true;
            }
        }, () => BackToHomePage);


        private bool CanOpenArticlePopup = true;
        public ICommand OpenArticlePopupCommand => new Command(async () =>
        {
            try
            {
                CanOpenArticlePopup = false;

                if (MotifListData == null)
                {
                    MotifListData = await GetMotifArrivageData();
                }

                var poopup = new PickerChoosePopup(title: "Selectionnez le motif", chooselist: MotifListData);

                poopup.OnEventAcquired += async (object sender, REFItem args) =>
                {
                    MotifTitle = args.Name;
                    await PopupNavigation.Instance.PopSafeAsync();
                };

                await PopupNavigation.Instance.PushSingleAsync(poopup);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                CanOpenArticlePopup = true;
            }
        }, () => CanOpenArticlePopup);

        #endregion

    }
}