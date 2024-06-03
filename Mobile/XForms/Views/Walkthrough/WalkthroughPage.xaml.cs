using XForms.ViewModels;

namespace XForms.Views.Walkthrough
{
    public partial class WalkthroughPage : BasePage
    {
        public WalkthroughPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (BindingContext == null)
            {
                BindingContext = new WalkthroughViewModel(Navigation);
            }

            base.OnAppearing();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            //if (width > 0 && height > 0)
            //{
            //    MainCarouselView.HeightRequest = Device.RuntimePlatform == Device.Android ? height / 2 : height / 2;
            //    //MainCarouselView.ScrollTo(0, 0, ScrollToPosition.End, false);
            //}
        }

    }
}