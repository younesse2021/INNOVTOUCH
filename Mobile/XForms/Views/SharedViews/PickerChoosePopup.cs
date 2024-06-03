using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XForms.Models;

namespace XForms.Views.SharedViews
{
    public partial class PickerChoosePopup : BasePopupView
    {
        public event EventHandler<REFItem> OnEventAcquired;

        public string ViewTitle { get; set; }

        public List<REFItem> ChooseList { get; set; }


        public PickerChoosePopup(string title, List<REFItem> chooselist)
        {
            InitializeComponent();

            ViewTitle = title;
            ChooseList = chooselist;

            BindingContext = this;
        }

        private void Itemt_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if ((sender as View).BindingContext is not REFItem item) return;
                foreach (var x in ChooseList)
                {
                    x.IsSelected = x.Id == item.Id;
                }
                OnEventAcquired?.Invoke(this, item);
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