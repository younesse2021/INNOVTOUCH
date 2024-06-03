using System;
using Xamarin.Forms;

namespace XForms.Views.SharedViews
{
    public partial class ScanFloatingButton : ContentView
    {
        public ScanFloatingButton()
        {
            InitializeComponent();
        }

        private async void OpenScanProductPopup_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
               // await PopupNavigation.Instance.PushSingleAsync(new ScanProductPopup());
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }

        }
    }
}
