using System;
using Xamarin.Forms;
using XForms.Models;
using XForms.ViewModels.Inventory;
using XForms.ViewModels.Offline;

namespace XForms.Views.Inventory
{
    public partial class InventoryEmplacementsPage : BasePage
    {
        public InventoryEmplacementsPage()
        {
            InitializeComponent();

        }

        private void ZoneStore_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                (BindingContext as OfflineInventoryViewModel)?.SelectedZoneCommand.Execute(1);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }

        private void ZoneStock_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                (BindingContext as OfflineInventoryViewModel)?.SelectedZoneCommand.Execute(2);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }


        private void InventoryEmplacement_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if ((sender as View).BindingContext is not string item)
                    return;

                var Vm = new InventoryViewModel(Navigation);
                Vm.SelectInventoryEmplacementCommand.Execute(item);
                // (BindingContext as InventoryViewModel)?.SelectInventoryEmplacementCommand.Execute(item);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }
    }
}