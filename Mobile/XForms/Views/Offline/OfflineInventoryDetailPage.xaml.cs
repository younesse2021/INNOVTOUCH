using System;
using Xamarin.Forms;
using XForms.Models;
using XForms.ViewModels.Offline;

namespace XForms.Views.Offline
{
    public partial class OfflineInventoryDetailPage : BasePage
    {
        public OfflineInventoryDetailPage()
        {
            InitializeComponent();
        }

        private void InventoryZone_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if ((sender as View).BindingContext is not InventoryZoneModel item)
                    return;

                (BindingContext as OfflineInventoryViewModel)?.SelectInventoryZoneCommand.Execute(item);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }


    }
}
