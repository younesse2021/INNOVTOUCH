using System;
using Rg.Plugins.Popup.Services;
using XForms.ViewModels.Inventory;

namespace XForms.Views.SharedViews
{
    public partial class DisplayPromptAsyncPopup : BasePopupView
    {
        public event EventHandler<string?> OnEventAcquired;

        public DisplayPromptAsyncPopup()
        {
            InitializeComponent();
        }

        private async void Confirm_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                try
                {
                    OnEventAcquired?.Invoke(this, CodeEntry.Text);

                    //await PopupNavigation.Instance.PopSafeAsync();
                }
                catch (Exception ex)
                {
                    AppHelpers.Alert(ex.Message, exception: ex);
                }
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }


        private async void Close_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await PopupNavigation.Instance.PopSafeAsync();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }
    }

}