using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace XForms.Localization
{
    public class AppLanguage
    {
        public static void SetAppCulture(string languageCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
            AppResources.Culture = new CultureInfo(languageCode);
        }
    }
}
