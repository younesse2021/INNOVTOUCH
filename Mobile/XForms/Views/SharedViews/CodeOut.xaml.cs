﻿using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XForms.Views.SharedViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeOut : BasePopupView
    {
        public event EventHandler<string?> OnEventAcquired;

        public CodeOut()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                CodeEntry.Focus();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }

        private async void Confirm_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                try
                {
                    OnEventAcquired?.Invoke(this, CodeEntry.Text);

                    //await PopupNavigation.Instance.PopSafeAsync();
                }
                catch (Exception ex)
                {
                    AppHelpers.Alert(ex.Message, exception: ex);
                }
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }
        private async void Close_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await PopupNavigation.Instance.PopSafeAsync();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }
    }
}