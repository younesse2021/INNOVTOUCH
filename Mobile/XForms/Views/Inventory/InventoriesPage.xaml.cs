using System;
using Xamarin.Forms;
using XForms.Models;
using XForms.ViewModels.Inventory;

namespace XForms.Views.Inventory
{
    public partial class InventoriesPage : BasePage
    {
        public InventoriesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            try
            {
                if (BindingContext == null)
                {
                    AppHelpers.In();
                    BindingContext = new InventoryViewModel(Navigation);
                }

                base.OnAppearing();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }

        private  void Inventory_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if ((sender as View).BindingContext is not Emplacement item)
                    return;
            
                (BindingContext as InventoryViewModel)?.SelectInventoryCommand.Execute(item);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }
    }
}