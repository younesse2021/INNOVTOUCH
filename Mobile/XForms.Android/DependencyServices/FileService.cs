using System.Threading.Tasks;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Support.V4.Content;
using Java.IO;
using XForms.Enums;

[assembly: Xamarin.Forms.Dependency(typeof(XForms.Droid.DependencyServices.FileService))]

namespace XForms.Droid.DependencyServices
{
    public class FileService : IFileService
    {
        //public Task<string> GetLocalFile(string filePath)
        //{
        //    try
        //    {
        //        var ctx = Plugin.CurrentActivity.CrossCurrentActivity.Current.AppContext;

        //        var file = new Java.IO.File(filePath);

        //        var fileExists = file.Exists();

        //        if (!fileExists)
        //        {
        //            //throw new Exception("File not found");
        //            XForms.AppHelpers.Alert("File not found");
        //            return Task.FromResult("");
        //        }

        //        //var myUri = FileProvider.GetUriForFile(ctx, $"{ctx.ApplicationContext.PackageName}.provider", file);
        //        var myUri = Uri.FromParts("package", "pro.mobiarchitects.droid.marjane", null);
        //        var i = new Intent(Intent.ActionView, myUri);
        //        i.AddFlags(ActivityFlags.GrantReadUriPermission);
        //        i.AddFlags(ActivityFlags.NewTask);
        //        ctx.StartActivity(i);

        //        return Task.FromResult("");
        //    }
        //    catch (Exception Ex)
        //    {
        //        AppsHelper.Snack(Ex.Message);
        //        return Task.FromResult(false);
        //    }
        //}

        public async Task<string> GetLocalFile(string filePath)
        {
            try
            {
                string text = "";
                var context = Plugin.CurrentActivity.CrossCurrentActivity.Current.AppContext;

                if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.P)
                {
                    if (!Environment.IsExternalStorageManager)
                    {
                        //request for the permission
                        //var myUri = FileProvider.GetUriForFile(context, $"{context.ApplicationContext.PackageName}.provider", file);

                        Intent intent = new Intent();
                        Uri uri = Uri.FromParts("package", context.ApplicationContext.PackageName, null);

                        //intent.SetAction(Android.Provider.Settings.ActionManageAllFilesAccessPermission);

                        intent.SetData(uri);
                        //intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                        intent.AddFlags(ActivityFlags.NewTask);

                        context.StartActivity(intent);
                    }
                }

                text = System.IO.File.ReadAllText(filePath);

                return text;
            }
            catch (System.Exception ex)
            {
                AppHelpers.Alert(ex.Message);
                return "";
            }
        }

        public bool CheckStoragePer()
        {
            try
            {
                var context = Plugin.CurrentActivity.CrossCurrentActivity.Current.AppContext;

                //if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.P)
                //{
                //    if (!Environment.IsExternalStorageManager)
                //    {
                //request for the permission
                //var myUri = FileProvider.GetUriForFile(context, $"{context.ApplicationContext.PackageName}.provider", file);

                Intent intent = new Intent();
                Uri uri = Uri.FromParts("package", context.ApplicationContext.PackageName, null);

                //intent.SetAction(Android.Provider.Settings.ActionManageAllFilesAccessPermission);

                intent.SetData(uri);
                //intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                intent.AddFlags(ActivityFlags.NewTask);

                context.StartActivity(intent);

                return true;
                //}
                //}


            }
            catch (System.Exception ex)
            {
                AppHelpers.Alert(ex.Message);
                return false;
            }
        }
    }
}