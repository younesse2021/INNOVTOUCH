using System;
using Xamarin.Forms;
using XForms.ViewModels.Home;
using XForms.ViewModels.Inventory;

namespace XForms.Views.Inventory
{
    public partial class ScanInventoryPage : BasePage
    {
        public ScanInventoryPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<InventoryViewModel>(this, AppConstants.FocusProductBarCodeEntry, async (sender) =>
            {
                await System.Threading.Tasks.Task.Delay(1000);
                ProductBarCodeEntry.Focus();
                ProductBarCodeEntry.CursorPosition = (ProductBarCodeEntry.Text ?? "").Length;
            });

            MessagingCenter.Subscribe<InventoryViewModel>(this, AppConstants.FocusProductQuantityEntry, async (sender) =>
            {
                await System.Threading.Tasks.Task.Delay(1000);
                ProductQuantityEntry.Focus();
                ProductQuantityEntry.CursorPosition = (ProductQuantityEntry.Text ?? "").Length;
            });

            MessagingCenter.Subscribe<InventoryViewModel>(this, AppConstants.FocusProductWeigthEntry, async (sender) =>
            {
                await System.Threading.Tasks.Task.Delay(1000);
                ProductWeigthEntry.Focus();
                ProductWeigthEntry.CursorPosition = (ProductWeigthEntry.Text ?? "").Length;
            });
        }

        protected override void OnAppearing()
        {
            try
            {
                if (BindingContext == null)
                {
                    AppHelpers.In();
                    ProductBarCodeEntry.Focus();
                    BindingContext = new InventoryViewModel(Navigation);
                }

                base.OnAppearing();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }
        protected override bool OnBackButtonPressed()
        {
            AppHelpers.LoadingHide();

            return true;
        }

        private void ProductBarCodeEntry_Completed(object sender, EventArgs e)
        {
            try
            {
                (BindingContext as InventoryViewModel)?.ScanBarCodeCommand.Execute((sender as Entry).Text);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
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
    }
}