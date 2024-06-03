using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace XForms.Droid
{
    [
        Activity(MainLauncher = false,
         Theme = "@style/MainTheme",
            ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            #region Initialize plugins
            Acr.UserDialogs.UserDialogs.Init(this);
            Rg.Plugins.Popup.Popup.Init(this);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
             var ignore = typeof(FFImageLoading.Svg.Forms.SvgCachedImage);
            //FFImageLoading.Forms.Platform.SvgCachedImage.Init(enableFastRenderer: true);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);


            PanCardView.Droid.CardsViewRenderer.Preserve();
            #endregion


            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

          protected override void OnNewIntent(Android.Content.Intent intent)
        {
            base.OnNewIntent(intent);
            Xamarin.Essentials.Platform.OnNewIntent(intent);
        }

        protected override void OnResume()
        {
            base.OnResume();

            //Java.IO.File DataDirectoryPath = Android.OS.Environment.ExternalStorageDirectory;
            //string dirPath = DataDirectoryPath.AbsolutePath ;
            //bool exists = Directory.Exists(dirPath);
            //string filepath = dirPath + "/11_204297.txt";
            //if (!exists)
            //{
            //    Directory.CreateDirectory(dirPath);
            //    if (!File.Exists(filepath))
            //    {
            //        File.Create(filepath).Dispose();
            //        using (TextWriter tw = new StreamWriter(filepath))
            //        {
            //            tw.WriteLine("The very first line!");
            //            tw.Close();
            //        }
            //    }
            //}

            //bool existsFile = Directory.Exists(dirPath + filepath);

            //if (!exists)
            //{
            //}
        }

    }
}