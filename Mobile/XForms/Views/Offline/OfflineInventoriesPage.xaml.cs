using System;
using Xamarin.Forms;
using XForms.Models;
using XForms.ViewModels;
using XForms.ViewModels.Offline;

namespace XForms.Views.Offline
{
    public partial class OfflineInventoriesPage : BasePage
    {
        public OfflineInventoriesPage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    try
        //    {
        //        if (BindingContext == null)
        //        {
        //            BindingContext = new BaseViewModel(Navigation);
        //        }

        //        base.OnAppearing();
        //    }
        //    catch (Exception ex)
        //    {
        //        AppHelpers.Alert(ex.Message, exception: ex);
        //    }
        //}

        private void Inventory_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if ((sender as View).BindingContext is not InventoryModel item)
                    return;

                (BindingContext as OfflineInventoryViewModel)?.SelectInventoryCommand.Execute(item);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }
    }
}