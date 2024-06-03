using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using FluentValidation;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using XForms.Interfaces;
using XForms.Services;
 using XForms.Views.Inventory;
 
using XForms.Views.SharedViews;

namespace XForms.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class BaseViewModel : BindableObject
    {
        protected INavigation Navigation;
        protected IValidator Validator;
        protected ILogger Logger;

        public string Title { get; set; }

        public bool IsRefreshing { get; set; }

        public bool CanShowPage { get; set; }

        public bool CanRefresh;

        public bool CanRefreshProductInfo = false;

        public string ShortUserName => $"{(Settings.UserName ?? "").Substring(0, 1)}.{(Settings.HashPass ?? "")}";

        public BaseViewModel(INavigation navigation, ILogger logger = null, IValidator validator = null)
        {
            Navigation = navigation;
            Validator = validator;
            Logger = logger ?? new AppCenterLogger();



            this.PropertyChanged += (s, e) =>
            {

            };
        }

        public virtual void OnAppearing()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger?.LogError(ex);
            }
            finally
            {

            }
        }

        public virtual void OnDisappearing() { }

        public virtual void OnBackButtonPressed() { }

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


        //private bool CanRefreshToken = true;
        //public ICommand RefreshTokenCommand => new Command(async () =>
        //{
        //    try
        //    {
        //        CanRefreshToken = false;

        //        AppHelpers.LoadingShow();

        //        var postRequest = new GraphQLRequest
        //        {
        //            Query = "mutation { refreshCustomerToken { token } }",
        //        };

        //        var result = await App.AppServices.PostRefreshToken(postRequest);

        //        if (result?.Data?.RefreshCustomerToken != null)
        //        {
        //            Settings.AccessToken = result.Data.RefreshCustomerToken.Token;
        //            Settings.IsVisitor = false;

        //            //CrossFirebasePushNotification.Current.Subscribe("general");

        //            //await App.AppServices.POSTSaveDeviceFirebaseToken(Plugin.FirebasePushNotification.CrossFirebasePushNotification.Current.Token);

        //            Settings.ValidSession = DateTime.UtcNow.AddSeconds(AppConstants.AppValidSession);
        //        }
        //        else
        //        {
        //            AppHelpers.Alert(result?.Errors.FirstOrDefault().Message);

        //            LogoutCommand.Execute(null);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger?.LogError(ex, showError: true);
        //    }
        //    finally
        //    {
        //        AppHelpers.LoadingHide();

        //        CanRefreshToken = true;
        //    }
        //}, () => CanRefreshToken);

        private bool CanDismissPage = true;
        public ICommand DismissPageCommand => new Command(async () =>
        {
            try
            {
                CanDismissPage = false;

                if (Navigation.NavigationStack.LastOrDefault().GetType() == typeof(ScanInventoryPage))
                {
                    Application.Current.MainPage = new NavigationPage(new Views.SignUp.SignupPage());
                }
                else
                {
                    await Navigation.PopSafeAsync();
                }
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanDismissPage = true;
            }
        }, () => CanDismissPage);

        private bool CanDismissModalPage = true;
        public ICommand DismissModalPageCommand => new Command(async () =>
        {
            try
            {
                CanDismissModalPage = false;

                await Navigation.PopModalSafeAsync();
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanDismissModalPage = true;
            }
        }, () => CanDismissModalPage);


        private bool CanDismissPopup = true;
        public ICommand DismissPopupCommand => new Command(async () =>
        {
            try
            {
                CanDismissPopup = false;
                await PopupNavigation.Instance.PopSafeAsync();
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanDismissPopup = true;
            }
        }, () => CanDismissPopup);

        private bool CanOpenUrl = true;
        public ICommand OpenUrlCommand => new Command<string>(async (model) =>
        {
            try
            {
                CanOpenUrl = false;

                await AppHelpers.OpenBrowserAsync(model);
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanOpenUrl = true;
            }
        }, (_) => CanOpenUrl);

        private bool CanCall = true;
        public ICommand CallCommand => new Command<string>(async (model) =>
        {
            try
            {
                CanCall = false;

                //AppHelpers.PlacePhoneCall(model);
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanCall = true;
            }
        }, (_) => CanCall);

        private bool CanSendMail = true;
        public ICommand SendMailCommand => new Command<string>(async (model) =>
        {
            try
            {
                CanSendMail = false;

                //await AppHelpers.SendEmail(subject: "", body: "", recipients: new List<string>() { model });
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanSendMail = true;
            }
        }, (_) => CanSendMail);

        private bool CanShareUrl = true;
        public ICommand ShareUrlCommand => new Command<(string title, string url)>(async (model) =>
         {
             try
             {
                 CanShareUrl = false;

                 await Share.RequestAsync(new ShareTextRequest
                 {
                     Title = model.title,
                     Uri = model.url
                 });
             }
             catch (Exception ex)
             {
                 Logger?.LogError(ex, showError: true);
             }
             finally
             {
                 CanShareUrl = true;
             }
         }, (_) => CanShareUrl);

        private bool CanShareText = true;
        public ICommand ShareTextCommand => new Command<(string title, string text)>(async (model) =>
        {
            try
            {
                CanShareText = false;

                await Share.RequestAsync(new ShareTextRequest
                {
                    Title = model.title,
                    Text = model.text
                });
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanShareText = true;
            }
        }, (_) => CanShareText);


        private bool CanLogout = true;
        public ICommand LogoutCommand => new Command(() =>
        {
            try
            {
                CanLogout = false;


                Settings.ClearSettings();

                Application.Current.MainPage = new NavigationPage(new Views.SignUp.SignupPage());
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanLogout = true;
            }
        }, () => CanLogout);


        private bool CanOpenProductImage = true;
        public ICommand OpenProductCommandImage => new Command<ImageSource>(async (field) =>
        {
            try
            {
                CanOpenProductImage = false;

                if (field == null) return;

                await Navigation.PushModalAsync(new Views.SharedViews.PinchToZoomPage(field));
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, showError: true);
            }
            finally
            {
                CanOpenProductImage = true;
            }
        }, (_) => CanOpenProductImage);
    }
}