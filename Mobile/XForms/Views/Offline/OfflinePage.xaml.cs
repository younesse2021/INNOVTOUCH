using System;
using XForms.ViewModels;
using XForms.ViewModels.Offline;

namespace XForms.Views.Offline
{
    public partial class OfflinePage : BasePage
    {
        public OfflinePage()
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

        private void Service_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                (BindingContext as OfflineInventoryViewModel)?.OpenInventoryFieldsPageCommand.Execute(null);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }

        }
    }
}