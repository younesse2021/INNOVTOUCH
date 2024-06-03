using System;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using XForms.ViewModels;

namespace XForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class BasePopupView : PopupPage
    {
        public BasePopupView()
        {
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is BaseViewModel bindingContext)
                bindingContext.OnAppearing();
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is BaseViewModel bindingContext)
                bindingContext.OnDisappearing();
        }
    }
}
