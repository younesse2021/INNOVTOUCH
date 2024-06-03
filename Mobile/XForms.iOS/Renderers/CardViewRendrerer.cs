using System;
using System.ComponentModel;
using CoreGraphics;
using XForms.Controls;
using XForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CardView), typeof(CardViewRendrerer))]
namespace XForms.iOS.Renderers
{
    public class CardViewRendrerer : FrameRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null) return;

           
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var element = (CardView)Element;

            //Layer.BorderColor = UIColor.Red.CGColor;
            //Layer.CornerRadius = element.Elevation;

            Layer.ShadowColor = element.ShadowColor.ToUIColor().CGColor;
            Layer.MasksToBounds = false;
            Layer.ShadowOffset = element.ShadowOffset.ToSizeF();
            Layer.ShadowRadius = element.Elevation;
            Layer.ShadowOpacity = (float)element.ShadowOpacity;
        }
    }
}