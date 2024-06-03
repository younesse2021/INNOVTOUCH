using System;
using Xamarin.Forms;
using XForms.Models;
using XForms.ViewModels.Offline;

namespace XForms.Views.Offline
{
    public partial class OfflineInventoryEmplacementsPage : BasePage
    {
        public OfflineInventoryEmplacementsPage()
        {
            InitializeComponent();
        }

        private void InventoryEmplacement_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if ((sender as View).BindingContext is not string item)
                    return;

                (BindingContext as OfflineInventoryViewModel)?.SelectInventoryEmplacementCommand.Execute(item);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }
    }
}