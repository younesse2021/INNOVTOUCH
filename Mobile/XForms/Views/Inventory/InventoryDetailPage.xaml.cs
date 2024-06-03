using System;
using Xamarin.Forms;
using XForms.Models;
using XForms.ViewModels.Inventory;

namespace XForms.Views.Inventory
{
    public partial class InventoryDetailPage : BasePage
    {
        public InventoryDetailPage()
        {
            InitializeComponent();
        }

        private void InventoryZone_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if ((sender as View).BindingContext is not InventoryZoneModel item)
                    return;

                (BindingContext as InventoryViewModel)?.SelectInventoryZoneCommand.Execute(item);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }

        private void SwitchOne_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                (BindingContext as InventoryViewModel)?.SelectedZoneCommand.Execute(1);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }

        private void SwitchTwo_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                (BindingContext as InventoryViewModel)?.SelectedZoneCommand.Execute(2);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }
    }
}