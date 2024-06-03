using System;
using XForms.Enums;
using XForms.Interfaces;
using XForms.ViewModels;
//using XForms.ViewModels.Base;
//using XForms.Views.SharedViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class BasePage : ContentPage
    {

        #region View Props
        public bool HasNavigationBar
        {
            get { return NavigationPage.GetHasNavigationBar(this); }
            set { NavigationPage.SetHasNavigationBar(this, value); }
        }

        private StatusBarStyle statusBarStyle = StatusBarStyle.Dark;
        public StatusBarStyle StatusBarStyle
        {
            get { return statusBarStyle; }
            set { statusBarStyle = value; }
        }

        public string BackButtonTitle
        {
            get { return NavigationPage.GetBackButtonTitle(this); }
            set { NavigationPage.SetBackButtonTitle(this, value); }
        }

        //private bool hasKeyboardOffset = true;
        //public bool HasKeyboardOffset
        //{
        //    get { return hasKeyboardOffset; }
        //    set { hasKeyboardOffset = value; }
        //}

        #endregion

        public BasePage()
        {
            //IsTabStop = true;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //  FIX: Clean stuck alerts
            //Xamarin.Forms.DependencyService.Get<IAlertCleaner>().CleanUnwantedAlerts();

            if (BindingContext is BaseViewModel bindingContext)
                bindingContext.OnAppearing();
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();

            //  FIX: Clean stuck alerts
            //Xamarin.Forms.DependencyService.Get<IAlertCleaner>().CleanUnwantedAlerts();

            if (BindingContext is BaseViewModel bindingContext)
                bindingContext.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            if (BindingContext is BaseViewModel bindingContext)
                bindingContext.OnBackButtonPressed();

            return base.OnBackButtonPressed();
        }

    }
}
