using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XForms.Enums;
using XForms.Models;
using XForms.ViewModels.Home;

namespace XForms.Views.Home
{
    public partial class MenuChildrensPage : BasePage
    {
        public MenuChildrensPage()
        {
            InitializeComponent();

        }

        private void Service_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if ((sender as View).BindingContext is not ServiceModel item)
                    return;

                (BindingContext as HomeViewModel)?.SelectServiceCommand.Execute(item);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }
    }
}