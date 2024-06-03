using System;
using Xamarin.Forms;
using XForms.Models;
using XForms.ViewModels.Offline;

namespace XForms.Views.Offline
{
    public partial class OfflineChooseZoneTypePage : BasePage
    {
        public OfflineChooseZoneTypePage()
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



    }
}