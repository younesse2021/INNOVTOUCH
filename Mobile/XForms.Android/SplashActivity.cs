using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace XForms.Droid
{

    [Activity(
        MainLauncher = true,
        NoHistory = true,
          Theme = "@style/SplashTheme",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            }

            InvokeMainActivity();
        }

        void InvokeMainActivity()
        {
            var mainActivityIntent = new Intent(this, typeof(MainActivity));

            if (Intent.Extras != null)
            {
                mainActivityIntent.PutExtras(Intent.Extras);
            }

            mainActivityIntent.SetFlags(ActivityFlags.SingleTop);

            StartActivity(mainActivityIntent);
        }
    }
}