using System;
using XForms.Enums;

[assembly: Xamarin.Forms.Dependency(typeof(XForms.Droid.DependencyServices.PathService))]

namespace XForms.Droid.DependencyServices
{
    public class PathService : IPathService
    {
        public string InternalFolder
        {
            get
            {
                return Android.App.Application.Context.FilesDir.AbsolutePath;
            }
        }

        [Obsolete]
        public string PublicExternalFolder
        {
            get
            {
                return Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            }
        }

        public string PrivateExternalFolder
        {
            get
            {
                return Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;
            }
        }

    }
}