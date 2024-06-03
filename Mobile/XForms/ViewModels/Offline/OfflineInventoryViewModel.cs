using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation;
using Rg.Plugins.Popup.Services;
using Shared.Models.IN;
using Xamarin.Forms;
using XForms.Data_Sql_Light;
using XForms.Enums;
using XForms.Interfaces;
using XForms.Models;
using XForms.Views.Offline;

namespace XForms.ViewModels.Offline
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class OfflineInventoryViewModel : BaseViewModel
    {
        public string PIN { get; set; } = "InnovTouchOFF";
        public string SelectedStoreCode { get; set; } // = "25";
        public string SelectedInventaryCode { get; set; } // = "204297";
        public List<int> RowsList { get; set; }
        public int SelectedRow { get; set; } = -1;
        public string SelectedZone { get; set; }
        public string SelectedRowString => SelectedRow == -1  ? "Séléctionner un rayon" : SelectedRow.ToString();

        #region Inventories
        public List<InventoryModel> InventoriesList { get; set; }
        public InventoryModel SelectedInventory { get; set; }
        #endregion

        #region Inventory Detail
        public List<string> EmplacementsList { get; set; }

        public InventoryZoneModel SelectedInventoryZone { get; set; }
        public string SelectedInventoryEmplacement { get; set; }
        #endregion

        #region Scan
        public string ProductBarCode { get; set; } //= "5000289020701";
        public bool ProductBarCodePlaceholderVisibility => string.IsNullOrEmpty(ProductBarCode);
        public string ProductQuantity { get; set; }
        public string ProductWeight { get; set; }

        private string ApsolutePath = "FichierInv";
        private string InFolderName => SelectedStoreCode + "_" + SelectedInventaryCode;
        private string InFileName => SelectedRow + "_" + SelectedInventaryCode;
        public ProductModel CurrentProductInfos { get; set; }
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
            ? new Thickness(20, 180, 20, 20)
            : new Thickness(20, 130, 20, 20);

        private List<string> AllProductsInFileList;

        private int SavedProductsCount = 0;
        #endregion

        public OfflineInventoryViewModel(INavigation navigation, ILogger logger = null, IValidator validator = null)
        : base(navigation, logger, validator)
        {
            CanRefresh = true;

            this.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(ProductBarCode))
                {
                    ClearProductInfoData(false);
                }
            };
        }
        public override void OnAppearing()
        {
            base.OnAppearing();

            try
            {

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Data Fonctions
        public async Task<IEnumerable<string>> GetAllProductsInFileList()
        {
            try
            {
                var status = await AppHelpers.CheckAndRequestStorageReadPermission();

                if (status == Xamarin.Essentials.PermissionStatus.Granted)
                {
                    var publicExternalFolder = Xamarin.Forms.DependencyService.Get<IPathService>().PublicExternalFolder;
                    var filePath = Path.Combine(publicExternalFolder, ApsolutePath, InFolderName, $"{InFileName}.txt");

                    if (File.Exists(filePath))
                    {
                        var productsListString = await Xamarin.Forms.DependencyService.Get<IFileService>().GetLocalFile(filePath);

                        var allProductsList = productsListString.Split(Environment.NewLine);

                        return allProductsList;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var answer = await AppHelpers.AcceptAlert(Localizable.ALERT, Localizable.ENABLE_STORAGE_READ, Localizable.OK, Localizable.CANCEL);

                    if (answer)
                    {
                        Xamarin.Essentials.AppInfo.ShowSettingsUI();
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
        public async Task BackFunction()
        {
            try
            {
                LogoutCommand.Execute(null);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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

                ProductQuantity = ProductWeight = "";

                CurrentProductInfos = new ProductModel();

                HasProductInfosVisibility = false;

                ProductQuantityEnabled = false;
                ProductWeightEnabled = false;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        #endregion

        #region Commands

        private bool CanOpenInventoryFieldsPage = true;
        public ICommand OpenInventoryFieldsPageCommand => new Command(async () =>
        {
            try
            {
                CanOpenInventoryFieldsPage = false;

                SelectedStoreCode = SelectedInventaryCode = "";
                await Navigation.PushSingleAsync(new OfflineFieldsPage() { BindingContext = this }, false);
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanOpenInventoryFieldsPage = true;
            }
        }, () => CanOpenInventoryFieldsPage);

        private bool CanVerifyInventaryFolder = true;
        public ICommand VerifyInventaryFolderCommand => new Command(async () =>
        {
            try
            {
                CanVerifyInventaryFolder = false;

                var status = await AppHelpers.CheckAndRequestStorageReadPermission();

                if (status == Xamarin.Essentials.PermissionStatus.Granted)
                {
                    var publicExternalFolder = Xamarin.Forms.DependencyService.Get<IPathService>().PublicExternalFolder;
                    var filePath = Path.Combine(publicExternalFolder, ApsolutePath, InFolderName);

                    if (Directory.Exists(filePath))
                    {
                        var filePaths = Directory.GetFiles(filePath).Select(x => Path.GetFileName(x));

                        var rowsList = filePaths.Select(x => int.Parse(x.Split("_").FirstOrDefault())).OrderBy(o => o);

                        RowsList = rowsList
                        .ToList();

                        await Navigation.PushSingleAsync(new OfflineInventoryRowsPage() { BindingContext = this }, false);
                    }
                    else
                    {
                        AppHelpers.Alert("Pas d'inventaire");
                    }
                }
                else
                {
                    var answer = await AppHelpers.AcceptAlert(Localizable.ALERT, Localizable.ENABLE_STORAGE_READ, Localizable.OK, Localizable.CANCEL);

                    if (answer)
                    {
                        Xamarin.Essentials.AppInfo.ShowSettingsUI();
                    }

                    //Xamarin.Forms.DependencyService.Get<IFileService>().CheckStoragePer();
                }
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanVerifyInventaryFolder = true;
            }
        }, () => CanVerifyInventaryFolder);

        private bool CanSelectedRow = true;
        public ICommand SelectedRowCommand => new Command(async () =>
        {
            try
            {
                CanSelectedRow = false;

                if (SelectedRow == -1)
                {
                    AppHelpers.Alert("Veuillez sélectionner un rayon");
                    return;
                }
                await Navigation.PushSingleAsync(new OfflineChooseZoneTypePage() { BindingContext = this }, false);
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanSelectedRow = true;
            }
        }, () => CanSelectedRow);

        private bool CanSelectZone = true;
        public ICommand SelectedZoneCommand => new Command<int>(async (value) =>
        {
            try
            {
                CanSelectZone = false;

                var emplacementsList = new List<string>();

                if (value == 1)
                {
                    SelectedZone = "MAGASIN";

                    for (int i = 1; i <= 420; i++)
                    {
                        emplacementsList.Add($"LOT {i}");
                    }
                }
                else
                {
                    SelectedZone = "RESERVE";

                    for (int i = 1; i <= 420; i++)
                    {
                        emplacementsList.Add($"LOT {i}");
                    }
                }

                EmplacementsList = emplacementsList;

                await Navigation.PushSingleAsync(new OfflineInventoryEmplacementsPage() { BindingContext = this }, false);
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

        #region Inventories
        private bool CanSelectInventory = true;
        public ICommand SelectInventoryCommand => new Command<InventoryModel>(async (model) =>
        {
            try
            {
                CanSelectInventory = false;

                if (model == null)
                    return;

                SelectedInventory = model;

                if (EmplacementsList != null)
                {
                    await Navigation.PushSingleAsync(new OfflineInventoryDetailPage() { BindingContext = this }, false);
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

                if (model == null)
                    return;

                SelectedInventoryZone = model;

                await Navigation.PushAsync(new OfflineInventoryEmplacementsPage() { BindingContext = this }, false);
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
        public ICommand SelectInventoryEmplacementCommand => new Command<string>(async (value) =>
        {
            try
            {
                CanSelectInventoryEmplacement = false;

                if (string.IsNullOrEmpty(value))
                    return;

                SelectedInventoryEmplacement = value;

                //Set Default Values
                ClearProductInfoData();
                SavedProductsCount = 0;

                await Navigation.PushSingleAsync(new OfflineScanInventoryPage() { BindingContext = this });
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanSelectInventoryEmplacement = true;
            }
        }, (_) => CanSelectInventoryEmplacement);
        #endregion

        private bool CanScanBarCode = true;
        public ICommand ScanBarCodeCommand => new Command<string>(async (barCode) =>
        {
            try
            {
                CanScanBarCode = false;

                if (string.IsNullOrEmpty(barCode))
                    return;

                //if (AllProductsInFileList == null || AllProductsInFileList?.Any(x => !string.IsNullOrEmpty(x)) == true)
                if (AllProductsInFileList == null)
                {
                    var allProductsInFileList = await GetAllProductsInFileList();

                    if (allProductsInFileList == null)
                    {
                        AppHelpers.Alert("Article Inconnu");
                        return;
                    }

                    AllProductsInFileList = allProductsInFileList.ToList();
                }

                var flag = false;

                if (AllProductsInFileList != null)
                {
                    for (int i = 0; i < AllProductsInFileList.Count(); i++)
                    {
                        var item = AllProductsInFileList[i];

                        if (!string.IsNullOrEmpty(item) && (item.Substring(0, 13).TrimStart().Equals(barCode)))
                        {
                            var currentProductBarCode = item.Substring(0, 13);
                            var currentProductDescription = item.Substring(13, 15);
                            var currentStockUnitType = item.Substring(41, item.Length - 41);

                            var productInfos = new ProductModel()
                            {
                                LIBELLE = currentProductDescription,
                                CODE_CAISSE = currentProductBarCode,
                                CODE_GRP = currentStockUnitType
                            };

                            if (item != null)
                            {
                                CurrentProductInfos = productInfos;

                                HasProductInfosVisibility = true;

                                if (currentStockUnitType == "QTE")
                                {
                                    ProductQuantityEnabled = true;
                                    ProductWeightEnabled = false;
                                    MessagingCenter.Send<OfflineInventoryViewModel>(this, AppConstants.FocusProductQuantityEntry);
                                }
                                else
                                {
                                    ProductQuantityEnabled = false;
                                    ProductWeightEnabled = true;
                                    MessagingCenter.Send<OfflineInventoryViewModel>(this, AppConstants.FocusProductWeigthEntry);
                                }
                            }
                            else
                            { }

                            flag = true;
                            break;
                        }
                    }
                }

                if (!flag)
                {
                    AppHelpers.Alert("Article Inconnu");

                    ClearProductInfoData();

                    MessagingCenter.Send<OfflineInventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
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


                if (string.IsNullOrEmpty(ProductBarCode) ||
                               (string.IsNullOrEmpty(ProductQuantity) && string.IsNullOrEmpty(ProductWeight))
                               )
                {
                    AppHelpers.Alert("Champs obligatoires");
                    return;
                }


                if (long.TryParse(ProductBarCode, out long barCode))
                {
                    if (barCode < 0)
                    {
                        AppHelpers.Alert("Le code barre doit être supérieure ou égal à 0");
                        return;
                    }
                }
                else
                {
                    AppHelpers.Alert("Le code barre doit être numérique");
                    return;
                }

                if (CurrentProductInfos.CODE_GRP == "QTE")
                {
                    if (ProductQuantity.Length > 6)
                    {
                        AppHelpers.Alert("Format Incorrect");
                        ProductQuantity = "";
                        MessagingCenter.Send<OfflineInventoryViewModel>(this, AppConstants.FocusProductQuantityEntry);
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
                    if (ProductWeight.Length > 6)
                    {
                        AppHelpers.Alert("Format Incorrect");
                        ProductWeight = "";
                        MessagingCenter.Send<OfflineInventoryViewModel>(this, AppConstants.FocusProductWeigthEntry);
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

                var status = await AppHelpers.CheckAndRequestStorageWritePermission();

                if (status == Xamarin.Essentials.PermissionStatus.Granted)
                {
                    var publicExternalFolder = Xamarin.Forms.DependencyService.Get<IPathService>().PublicExternalFolder;

                    var outFile = SelectedInventaryCode + "_" + SelectedRow + "_" + SelectedInventoryEmplacement;

                    var folderPath = Path.Combine(publicExternalFolder, ApsolutePath, InFolderName, "travail");
                    var filePath = Path.Combine(folderPath, outFile);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    var addedProduct = "";
                    var addedProductLenght = 40;

                    for (int i = 0; i < addedProductLenght; i++)
                    {
                        if (i >= 28)
                        {
                            addedProduct += "0";
                        }
                        else
                        {
                            addedProduct += " ";
                        }
                    }

                    var aStringBuilder = new StringBuilder(addedProduct);

                    //QTE Or POIDS
                    aStringBuilder.Insert(addedProductLenght, "  " + CurrentProductInfos.CODE_GRP);

                    //Product Quantity OR Weight
                    if (CurrentProductInfos.CODE_GRP == "QTE")
                    {
                        //Product Quantity
                        aStringBuilder.Remove(addedProductLenght - ProductQuantity.Length, ProductQuantity.Length);
                        aStringBuilder.Insert(addedProductLenght - ProductQuantity.Length, ProductQuantity);
                    }
                    else
                    {
                        //Product Weight
                        aStringBuilder.Remove(addedProductLenght - ProductWeight.Length, ProductWeight.Length);
                        aStringBuilder.Insert(addedProductLenght - ProductWeight.Length, ProductWeight.Replace(",", "."));
                    }

                    //Products List Counter
                    if (SavedProductsCount == 0)
                    {
                        if (File.Exists(filePath))
                        {
                            var productsListString = await Xamarin.Forms.DependencyService.Get<IFileService>().GetLocalFile(filePath);

                            var allProductsList = productsListString.Split(Environment.NewLine)?.Where(x => !string.IsNullOrEmpty(x));

                            if (allProductsList?.Any() == true)
                            {
                                SavedProductsCount = allProductsList.Count();
                            }
                        }
                    }

                    SavedProductsCount++;

                    var productsCount = SavedProductsCount.ToString();

                    if (productsCount.Length > 6)
                    {
                        AppHelpers.Alert("Impossible de scanner d'autres articles");
                        return;
                    }

                    aStringBuilder.Remove(34 - productsCount.Length, productsCount.Length);
                    aStringBuilder.Insert(34 - productsCount.Length, productsCount);

                    //Product description
                    var description = CurrentProductInfos.LIBELLE;

                    if (description.Length > 15)
                    {
                        description = description.Substring(0, 15);
                    }

                    aStringBuilder.Remove(13, description.Length);
                    aStringBuilder.Insert(13, description);

                    //ProductBarCode
                    aStringBuilder.Remove(13 - ProductBarCode.Length, ProductBarCode.Length);
                    aStringBuilder.Insert(13 - ProductBarCode.Length, ProductBarCode);

                    var theString = aStringBuilder.ToString();

                    addedProduct = theString;

                    ListeArticlesInventaireModelSqlLight PostSqlLightModel = new ListeArticlesInventaireModelSqlLight();

                    PostSqlLightModel.username = "";
                    PostSqlLightModel.password = "";
                    PostSqlLightModel.site = SelectedStoreCode;
                    PostSqlLightModel.quantity = ProductQuantity;
                    PostSqlLightModel.weight = ProductWeight;
                    PostSqlLightModel.inventaire = SelectedInventaryCode;
                    PostSqlLightModel.zone = SelectedRow.ToString();
                    PostSqlLightModel.emplacement = SelectedInventoryEmplacement;
                    PostSqlLightModel.type = "82";
                    PostSqlLightModel.barcode = ProductBarCode;
                    PostSqlLightModel.description = CurrentProductInfos.LIBELLE;
                    PostSqlLightModel.salePrice = "0";
                    PostSqlLightModel.externalVariantCode = "0";
                    PostSqlLightModel.status = "0";
                    PostSqlLightModel.internalLogisticCode = "0";
                    PostSqlLightModel.intMerchStrucNode = "0";
                    PostSqlLightModel.extMerchStrucNode = "1";
                    PostSqlLightModel.merchStructureID = "1";
                    PostSqlLightModel.invoicingUnit = "1";
                    PostSqlLightModel.stockUnit = "1";
                    PostSqlLightModel.averageWeight = "-10";
                    PostSqlLightModel.seqvl = "0";


                    InventaireItemDatabase databaseConcurrent = await InventaireItemDatabase.Instance;

                    if (!AppHelpers.IsConnected())
                    {

                        await databaseConcurrent.SaveItemAsync(PostSqlLightModel);

                        // ** Insert  into  File ** //
                        if (!File.Exists(filePath))
                        {
                            using (StreamWriter sw = File.CreateText(filePath))
                            {
                                sw.WriteLine(addedProduct);
                            }
                        }
                        else
                        {
                            StreamWriter sw = File.AppendText(filePath);
                            sw.WriteLine(addedProduct);
                            sw.Close();
                        }

                        ClearProductInfoData();
                        MessagingCenter.Send<OfflineInventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
                    }
                    else
                    {

                        var digitalPrintCancelPopup = new Popups.FeedBackPopup(
                            headerGlyph: Resources.FontAwesomeFonts.Check,
                            headerGlyphBackground: AppHelpers.LookupColor("Success"),
                            title: $"la connexion a été établie",
                            description: "",
                            confirmActionText: "Oui",
                            cancelActionText: "No",
                            hasCancelAction: true,
                            primaryColor: AppHelpers.LookupColor("DarkAction"),
                            secondaryColor: AppHelpers.LookupColor("Primary"));

                        digitalPrintCancelPopup.OnEventAcquired += async (object sender, bool e) =>
                        {
                            if (e)
                            {
                                await BackFunction();
                            }
                            else
                            {
                                await databaseConcurrent.SaveItemAsync(PostSqlLightModel);
                                ClearProductInfoData();
                                MessagingCenter.Send<OfflineInventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
                            }
                        };
                        await PopupNavigation.Instance.PushSingleAsync(digitalPrintCancelPopup);
                    }
                }
                else
                {
                    var answer = await AppHelpers.AcceptAlert(Localizable.ALERT, Localizable.ENABLE_STORAGE_WRITE, Localizable.OK, Localizable.CANCEL);

                    if (answer)
                    {
                        Xamarin.Essentials.AppInfo.ShowSettingsUI();
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

                CanSaveInventaryProduct = true;
            }
        }, () => CanSaveInventaryProduct);

        private bool CanConfirmCreateInventary = true;
        public ICommand ConfirmCreateInventaryCommand => new Command(async () =>
        {
            try
            {
                CanConfirmCreateInventary = false;

                if (!string.IsNullOrEmpty(ProductBarCode))
                {
                    var answer = await AppHelpers.AcceptAlert("Alert", "Voulez vous vraiment terminer cette opération ?", "Oui", "Non");

                    if (answer)
                    {
                        AppHelpers.SetInitialView();
                    }
                }
                else
                {
                    var digitalPrintCancelPopup = new Popups.FeedBackPopup(
                    headerGlyph: Resources.FontAwesomeFonts.Check,
                    headerGlyphBackground: AppHelpers.LookupColor("Success"),
                    title: "Validation effectuée avec succès",
                    description: "",
                    confirmActionText: "OK",
                    primaryColor: AppHelpers.LookupColor("Primary"),
                    canReturnEvent: true
                    );

                    digitalPrintCancelPopup.OnEventAcquired += async (object sender, bool e) =>
                    {
                        await PopupNavigation.Instance.PopSafeAsync();

                        AppHelpers.SetInitialView();
                    };

                    await PopupNavigation.Instance.PushSingleAsync(digitalPrintCancelPopup);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                CanConfirmCreateInventary = true;
            }
        }, () => CanConfirmCreateInventary);
        #endregion
    }
}