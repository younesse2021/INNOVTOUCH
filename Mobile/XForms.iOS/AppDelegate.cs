﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace XForms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif
            #region Initialize plugins
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            var ignore = typeof(FFImageLoading.Svg.Forms.SvgCachedImage);

            Rg.Plugins.Popup.Popup.Init();

            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.Forms.FormsMaterial.Init();

            PanCardView.iOS.CardsViewRenderer.Preserve();
            #endregion

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
