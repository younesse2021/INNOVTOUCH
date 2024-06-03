using System;
using XForms.ViewModels.SignUp;

namespace XForms.Views.SignUp
{
    public partial class SignupPage : BasePage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            try
            {
                if (BindingContext == null)
                {
                    BindingContext = new SignUpViewModel(Navigation);
                }

                base.OnAppearing();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }

        private void ShowOrHide_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                (BindingContext as SignUpViewModel)?.SingInShowOrHideCommand.Execute(SingInPasswordEntry);
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }

    }
}