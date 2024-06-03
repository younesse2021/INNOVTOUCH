using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using FFImageLoading.Svg.Forms;
using FluentValidation;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Shared.Models.IN;
using Shared.Models.OUT;
using Xamarin.Forms;
using XForms.Enums;
using XForms.Interfaces;
using XForms.Models;
using XForms.Views.Inventory;

using XForms.Views.SharedViews;

namespace XForms.ViewModels.Home
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class HomeViewModel : BaseViewModel
    {
        #region Home

        #region Stores

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged(nameof(UserName)); }
        }

        public bool IsStoresLoading { get; set; }

        public AuthResponse StoreSelectedItem { get; set; }

        public List<AuthResponse> StoresList { get; set; }
        #endregion

        #region Services
        public List<ServiceModel> ServicesList { get; set; }
        private IEnumerable<ServiceModel> ServicesListData;
        #endregion

        #endregion

        #region Menu Childrens
        private AppServices? SelectedParentService = null;

        public List<ServiceModel> ChildrensServicesList { get; set; }
        #endregion

        public HomeViewModel(INavigation navigation, ILogger logger = null, IValidator validator = null)
      : base(navigation, logger, validator)
        {
            CanRefresh = true;
            try
            {

                UserName = Settings.UserName;
                // var storesList = JsonConvert.DeserializeObject<IEnumerable<AuthResponse>>(Settings.StoredSitesData);
                // StoresList = storesList.ToList();

                this.PropertyChanged += async (s, e) =>
                {
                    if (e.PropertyName == nameof(StoreSelectedItem) && StoreSelectedItem != null)
                    {
                        try
                        {
                            // TODO
                            //if (StoreSelectedItem.s != Settings.CurrentSiteId)
                            //{
                            //    Settings.CurrentSiteId = StoreSelectedItem.code_site;

                            //    await GetParentsServisesList();
                            //}
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                if (CanRefresh)
                {
                    //StoreSelectedItem = StoresList.FirstOrDefault();
                    //await Task.Delay(500);
                    await GetParentsServisesList();
                    var servicesList = new List<ServiceModel>();
                    IsRefreshing = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        #region Data Fonctions

        public async Task GetParentsServisesList()
        {
            try
            {
                AppHelpers.LoadingShow();

                var postParams = new ModelsUserModel()
                {
                    site = Settings.CurrentSiteId,
                    username = Settings.UserName,
                    password = Settings.HashPass,
                };

                var result = await App.AppServices.GetServices(postParams);

                if (result?.succeeded == true && result?.data != null)
                {
                    var servicesList = new List<ServiceModel>();
                    var servicesDataList = new List<ServiceModel>();

                    foreach (var item in result.data)
                    {
                        if (int.TryParse(item.IDENT, out int @enum))
                        {
                            if (Enum.IsDefined(typeof(AppServices), @enum))
                            {
                                AppServices service = (AppServices)int.Parse(item.IDENT);

                                // services mobility 
                                var serviceItem = new ServiceModel
                                {
                                    Title = AppHelpers.GetServiceTitle(service),
                                    AppService = service,
                                    IconNonRead = AppHelpers.GetServiceIcon(service),
                                    IconSource = SvgImageSource.FromResource("XForms.Resources.Images." + AppHelpers.GetServiceIcon(service), typeof(ImageResourceExtension).GetTypeInfo().Assembly)
                                };

                                servicesDataList.Add(serviceItem);

                                if (service != AppServices.CTRLPRIX && service != AppServices.OPFRAIS)
                                {
                                    servicesList.Add(serviceItem);
                                }
                            }
                        }
                    }

                    ServicesList = servicesList;
                    ServicesListData = servicesDataList;
                    CanRefresh = false;
                }
                else
                {
                    AppHelpers.Alert(result.message);
                }
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                AppHelpers.LoadingHide();
            }
        }
        public void GetChildrensServisesList()
        {
            try
            {
                if (SelectedParentService == null || ServicesListData == null)
                    return;

                switch (SelectedParentService)
                {
                    case AppServices._Prix:

                        var servicesList = ServicesListData.Where(x => x.AppService == AppServices.CTRLPRIX || x.AppService == AppServices.OPFRAIS)?.ToList() ?? new List<ServiceModel>(); ;

                        ChildrensServicesList = servicesList.ToList();

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                AppHelpers.LoadingHide();
            }
        }
        #endregion

        #region Commands
        private bool CanSelectService = true;
        public ICommand SelectServiceCommand => new Command<ServiceModel>(async (model) =>
        {
           try
           {
               CanSelectService = false;

               if (model == null)
                   return;

               SelectedParentService = model.AppService;

               switch (model.AppService)
               {
                   case AppServices.InnovTouch:
                       await Navigation.PushSingleAsync(new InventoriesPage() { Title = "InnovTouchMune" });
                       break;
               }
           }
           catch (Exception ex)
           {
               Logger?.LogError(ex, showError: true);
           }
           finally
           {
               CanSelectService = true;
           }
       }, (_) => CanSelectService);

        private bool CanRefreshPage = true;
        public ICommand RefreshPageCommand => new Command(async () =>
        {
            try
            {
                CanRefreshPage = false;

                CanRefresh = true;

                await GetParentsServisesList();
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                IsRefreshing = false;

                CanRefreshPage = true;
            }
        }, () => CanRefreshPage);
        #endregion
    }
}