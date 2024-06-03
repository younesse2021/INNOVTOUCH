using System;
using Xamarin.Forms;
using XForms.ViewModels.Home;
using XForms.ViewModels.Offline;

namespace XForms.Views.Offline
{
    public partial class OfflineScanInventoryPage : BasePage
    {
        public OfflineScanInventoryPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<OfflineInventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry, async (sender) =>
            {
                await System.Threading.Tasks.Task.Delay(1000);
                ProductBarCodeEntry.Focus();
                ProductBarCodeEntry.CursorPosition = (ProductBarCodeEntry.Text ?? "").Length;
            });

            MessagingCenter.Subscribe<OfflineInventoryViewModel>(this, AppConstants.FocusProductQuantityEntry, async (sender) =>
            {
                await System.Threading.Tasks.Task.Delay(1000);
                ProductQuantityEntry.Focus();
                ProductQuantityEntry.CursorPosition = (ProductQuantityEntry.Text?? "").Length;
            });

            MessagingCenter.Subscribe<OfflineInventoryViewModel>(this, AppConstants.FocusProductWeigthEntry, async (sender) =>
            {
                await System.Threading.Tasks.Task.Delay(1000);
                ProductWeigthEntry.Focus();
                ProductWeigthEntry.CursorPosition = (ProductWeigthEntry.Text?? "").Length;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                ProductBarCodeEntry.Focus();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }

        protected override void OnDisappearing()
        {
            //MessagingCenter.Unsubscribe<OfflineInventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry);
            //MessagingCenter.Unsubscribe<OfflineInventoryViewModel>(this, AppConstants.LayoutSizeChanged);

            base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void ProductBarCodePlaceholder_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                ProductBarCodeEntry.Focus();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }

        private void ProductBarCodeEntry_Completed(object sender, EventArgs e)
        {
            try
            {
                (BindingContext as OfflineInventoryViewModel)?.ScanBarCodeCommand.Execute((sender as Entry).Text);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }

        private void ProductEntry_Completed(object sender, EventArgs e)
        {
            try
            {
                (BindingContext as OfflineInventoryViewModel)?.SaveInventaryProductCommand.Execute(null);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }
    }
}