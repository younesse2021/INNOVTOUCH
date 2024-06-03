using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using FluentValidation;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Shared.DTO.InnovTouch.DTO.Role;
using Shared.Models;
using Shared.Models.OUT;
using Xamarin.Forms;
using XForms.Interfaces;
using XForms.Validators.Authentication;
using XForms.ViewModels.Home;
using XForms.Views.SharedViews;

namespace XForms.ViewModels.SignUp
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class SignUpViewModel : BaseViewModel
    {
        #region SingIn
        public string SingInUserName { get; set; } = Settings.UserName;
        public string SingInPassword { get; set; }

        public bool IsSingInPassword { get; set; } = true;
        public string SingInPasswordGlyph { get; set; } = Resources.FontAwesomeFonts.EyeSlash;
        #endregion

        public SignUpViewModel(INavigation navigation, ILogger logger = null, IValidator validator = null)
             : base(navigation, logger, validator)
        {
            Validator = validator ?? new AuthenticationValidator();

#if DEBUG
            SingInUserName = "Admin";
            SingInPassword = "admin";
#endif

        }


        public override void OnAppearing()
        {
            base.OnAppearing();
        }

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

        #region Commands
        private bool CanSignIn = true;
        public ICommand SignInCommand => new Command(async () =>
        {
            try
            {
                CanSignIn = false;


                var validationResult = await Validator.ValidateAsync(this);

                if (!validationResult.IsValid)
                {
                    AppHelpers.Alert(validationResult.Errors.First()?.ErrorMessage);
                    return;
                }

                await SetBusyAsync(async () =>
                {

                    var postParams = new UtilisateurDto()
                    {
                        Login = SingInUserName,
                        Password = SingInPassword,
                    };

                    var result = await App.AppServices.LoginAction(postParams);

                    if (result?.succeeded == true && result?.data != null)
                    {
                        #region - Stored User Information In Mobile Cache

                        Settings.UserName = SingInUserName;

                        Settings.HashPass = result.data.Password;

                        Settings.IsSignIn = true;

                        Settings.ValidSession = DateTime.Now.AddSeconds(AppConstants.AppValidSession);

                        var storedSites = result.data;

                        Settings.StoredSitesData = JsonConvert.SerializeObject(storedSites);

                        Settings.CurrentSiteId = result.data.MagasinId.ToString();

                        Settings.NomMagasin = result.data.Magasin.Libelle;

                        Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new Views.Home.HomePage());

                        #endregion
                    }
                    else
                    {
                        AppHelpers.Alert(result.message);
                    }
                     

                });
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex);
            }
            finally
            {
                AppHelpers.LoadingHide();

                GC.Collect();

                CanSignIn = true;
            }
        }, () => CanSignIn);

        private bool CanSingInShowOrHide = true;
        public ICommand SingInShowOrHideCommand => new Command<Entry>((entry) =>
        {
            try
            {
                CanSingInShowOrHide = false;

                if (IsSingInPassword)
                {
                    IsSingInPassword = false;
                    SingInPasswordGlyph = Resources.FontAwesomeFonts.Eye;
                }
                else
                {
                    IsSingInPassword = true;
                    SingInPasswordGlyph = Resources.FontAwesomeFonts.EyeSlash;
                }

                if (entry != null)
                {
                    entry.Focus();
                    entry.CursorPosition = (entry.Text ?? "").Length;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                CanSingInShowOrHide = true;
            }
        }, (_) => CanSingInShowOrHide);

        private bool CanOpenOfflinePage = true;
        public ICommand OpenOfflinePageCommand => new Command(async () =>
        {
            try
            {
                CanOpenOfflinePage = false;

                //Open Popup To Insert The Code
                var popup = new DisplayPromptAsyncPopup();

                popup.OnEventAcquired += async (object sender, string args) =>
                {
                    if (args.Equals(AppConstants.OfflinePinCode))
                    {
                        //If Code Correct
                        await PopupNavigation.Instance.PopSafeAsync();

                        await Navigation.PushSingleAsync(new Views.Offline.OfflinePage());
                    }
                    else
                    {
                        //If Le Code InCorrect
                        AppHelpers.Alert(Localizable.CODE_INCORRECT);
                    }
                };

                await PopupNavigation.Instance.PushSingleAsync(popup);
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex);
            }
            finally
            {
                AppHelpers.LoadingHide();

                CanOpenOfflinePage = true;
            }
        }, () => CanOpenOfflinePage);

        #endregion
    }
}