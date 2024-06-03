using System;
using Android.App;
using Plugin.CurrentActivity;

namespace XForms.Droid
{

#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif

    //You can specify additional application information in this attribute
    //[MetaData("com.google.android.maps.v2.API_KEY", Value = AppConstants.GOOGLE_MAPS_ANDROID_API_KEY)]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, Android.Runtime.JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            CrossCurrentActivity.Current.Init(this);
        }
    }
}