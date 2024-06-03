using System;

namespace XForms
{
    public static class AppConstants
    {
        public const string AppName = "InnovTouch Store";
        public const string ShortAppName = "InnovTouch";
        //PIN Code for Acces to Offline Mode
        public const string OfflinePinCode = "ITIOFF";
        public static string AppVersion = Xamarin.Essentials.VersionTracking.CurrentVersion;
        public static string AppVersionName = $"Version {AppVersion}";
        public const int AppValidSession = 30 * 60;//30 Minutes
        public const string FocusProductBarCodeEntry = "FocusBarCodeEntry";
        public const string FocusProductQuantityEntry = "FocusProductQuantityEntry";
        public const string FocusProductWeigthEntry = "FocusProductWeigthEntry";
        public const string FocusNbrOfEtiquettesEntry = "FocusNbrOfEtiquettesEntry";
        public const string FocusRemiseEntry = "FocusRemiseEntry";
        public const string FocusNewPriceEntry = "FocusNewPriceEntry";
        public const string LayoutSizeChanged = "LayoutSizeChanged";
        public const string AndroidAppCenterKey = "b884bfa689d1897220cddd97e4bbbd8bc1d6997a";
    }
}