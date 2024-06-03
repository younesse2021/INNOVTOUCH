using XForms.Enums;
using XForms.Interfaces;
using XForms.iOS.DependencyServices;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Page), typeof(CustomPageRenderer))]
namespace XForms.iOS.DependencyServices
{
    public class CustomPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var page = Element as XForms.Views.BasePage;

            if (page != null)
            {
                SetStatusBarStyle(page.StatusBarStyle);

                //RegisterForKeyboardNotifications();
            }

            //UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);
            //UIApplication.SharedApplication.SetStatusBarHidden(false, true);

            // var theme = DependencyService.Get<IEnvironment>().GetOperatingSystemTheme();


            // SetStatusBarStyle(StatusBar.GetStatusBarStyle(Element));
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var s = e.NewElement;
            //if (
            // //e.PropertyName == CustomEntry.IsBorderErrorVisibleProperty.PropertyName ||
            // e.NewElement == CustomEntry.TextColorProperty.PropertyName ||
            // e.PropertyName == CustomEntry.BackgroundColorProperty.PropertyName ||
            // e.PropertyName == CustomEntry.BorderColorProperty.PropertyName ||
            // e.PropertyName == CustomEntry.PlaceholderColorProperty.PropertyName
            // )
            //{

            //    UpdateControl();
            //}
        }

        private void SetStatusBarStyle(StatusBarStyle statusBarStyle)
        {
            switch (statusBarStyle)
            {
                case StatusBarStyle.Dark:
                    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.DarkContent, true);
                    UIApplication.SharedApplication.SetStatusBarHidden(false, true);
                    break;
                case StatusBarStyle.Light:
                    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);
                    UIApplication.SharedApplication.SetStatusBarHidden(false, true);
                    break;
                //case StatusBarStyle.Hidden:
                //    UIApplication.SharedApplication.SetStatusBarHidden(true, true);
                //    break;
                case StatusBarStyle.Default:
                default:
                    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, true);
                    UIApplication.SharedApplication.SetStatusBarHidden(false, true);
                    break;
            }

            SetNeedsStatusBarAppearanceUpdate();
        }

    }
}