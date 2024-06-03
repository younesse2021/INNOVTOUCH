using Android.Support.Design.Widget;
using XForms.Droid.Effects;
using XForms.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Support.Design.BottomNavigation;
using System.Linq;

[assembly: ExportEffect(typeof(HideTabLabelsEffect), nameof(HideTabLabelsEffect))]

namespace XForms.Droid.Effects
{
    public class HideTabLabelsEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var renderer = (Control ?? Container) as TabbedPageRenderer;

            var children = renderer?.ViewGroup?.RetrieveAllChildViews();
            if (children?.FirstOrDefault(x => x is BottomNavigationView) is BottomNavigationView bottomNav)
            {
                bottomNav.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilitySelected;
            }
        }

        protected override void OnDetached()
        {
        }
    }
}