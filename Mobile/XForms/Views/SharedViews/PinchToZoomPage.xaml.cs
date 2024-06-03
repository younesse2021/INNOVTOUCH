using System;
using Xamarin.Forms;

namespace XForms.Views.SharedViews
{
    public partial class PinchToZoomPage : BasePage
    {
        public PinchToZoomPage(ImageSource zoomableImage)
        {
            InitializeComponent();

            ZoomableImage.Source = zoomableImage;
        }

        //public static readonly BindableProperty ZoomableImageSourceProperty = BindableProperty.Create(nameof(ZoomableImageSource), typeof(string), typeof(PinchToZoomPage));
        //public ImageSource ZoomableImageSource
        //{
        //    get
        //    {
        //        return (string)GetValue(ZoomableImageSourceProperty);
        //    }
        //    set
        //    {
        //        SetValue(ZoomableImageSourceProperty, value);
        //    }
        //}

        private void Close_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(ex.Message, exception: ex);
            }
        }
    }
}