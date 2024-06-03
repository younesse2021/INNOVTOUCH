using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using XForms.Popups;
using XForms.Services;

namespace XForms
{
    public partial class App : Application
    {
        public static bool IsSetDynamicResources;

        public App()
        {
            InitializeComponent();

            //Reditect to Initial View
            AppHelpers.SetInitialView();
        }

        private static readonly object lockerAppServices = new object();
        private static AppServices _appServices;
        public static AppServices AppServices
        {
            get
            {
                lock (lockerAppServices)
                {
                    if (_appServices != null)
                    {
                        return _appServices;
                    }
                    else
                    {
                        _appServices = new AppServices();
                        return _appServices;
                    }
                }
            }
            set
            {
                lock (lockerAppServices)
                {
                    _appServices = value;
                }
            }
        }

        private static readonly object lockerLoadingPopup = new object();
        private static LoadingPopup _loadingPopup;
        public static LoadingPopup LoadingPopup
        {
            get
            {
                lock (lockerLoadingPopup)
                {
                    if (_loadingPopup != null)
                    {
                        return _loadingPopup;
                    }
                    else
                    {
                        _loadingPopup = new LoadingPopup();
                        return _loadingPopup;
                    }
                }
            }
            set
            {
                lock (lockerLoadingPopup)
                {
                    _loadingPopup = value;
                }
            }
        }

        protected override void OnStart()
        {
            #region Call Api Mobile Gold Initailze Api Mobile Gold
            
            AppCenter.Start("android=323aa3f2-2ffb-4740-83d6-86b16f216059;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here};" +
                  "macos={Your macOS App secret here};",
                  typeof(Analytics), typeof(Crashes));
            #endregion
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}