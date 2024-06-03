using System;
using XForms.ViewModels;
using XForms.ViewModels.Offline;

namespace XForms.Views.Offline
{
    public partial class OfflineFieldsPage : BasePage
    {
        public OfflineFieldsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            try
            {
                if (BindingContext == null)
                {
                    BindingContext = new OfflineInventoryViewModel(Navigation);
                }

                base.OnAppearing();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }

        private void Verify_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                (BindingContext as OfflineInventoryViewModel)?.VerifyInventaryFolderCommand.Execute(null);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }
      
    }
}