using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XForms.Enums;
using XForms.Models;
using XForms.ViewModels.Home;

namespace XForms.Views.Home
{
    public partial class HomePage : BasePage
    {
        public HomePage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            try
            {
                if (BindingContext == null)
                {
                    BindingContext = new HomeViewModel(Navigation);
                }

                base.OnAppearing();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
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