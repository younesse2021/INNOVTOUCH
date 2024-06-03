using System;
using Xamarin.Forms;
using XForms.Models;
using XForms.ViewModels.Offline;

namespace XForms.Views.Offline
{
    public partial class OfflineInventoryRowsPage : BasePage
    {
        public OfflineInventoryRowsPage()
        {
            InitializeComponent();
        }

        private void SelectedRow_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                (BindingContext as OfflineInventoryViewModel)?.SelectedRowCommand.Execute(null);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }

    }
}