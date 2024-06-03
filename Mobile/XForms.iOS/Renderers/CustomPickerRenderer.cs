using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
//using Microsoft.AppCenter.Crashes;
using XForms.Controls;
using XForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace XForms.iOS.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            UpControl();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || this.Element == null) return;
        }

        private void UpControl()
        {
            var element = (CustomPicker)Element;

            // Radius for the curves

            Control.Layer.MasksToBounds = true;

            Control.Layer.CornerRadius = element.CornerRaduis;
            Control.Layer.BorderWidth = element.BorderWidth;

            Control.BackgroundColor = element.BackgroundColor.ToUIColor();
            Control.Layer.BorderColor = element.BorderColor.ToCGColor();
            //Control.TextAlignment = (UITextAlignment)element.HorizontalTextAlignment;

            Control.LeftView = new UIView(new CGRect(0, 0, element.Padding.Left, 0));
            Control.LeftViewMode = UITextFieldViewMode.Always;

            if (!string.IsNullOrEmpty(element.RightImage))
            {
                Control.RightViewMode = UITextFieldViewMode.Always;
                //Control.RightView = GetImageView(element.RightImage, 10, 10);
            }
            else
            {
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIView(new CGRect(0, 0, element.Padding.Right, 0));
            }

            // Thickness of the Border Width  
            Control.ClipsToBounds = true;

            if (!element.IsHasBorder)
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }

        private UIView GetImageView(string imagePath, int height, int width)
        {
            var uiImageView = new UIImageView(UIImage.FromBundle(imagePath))
            {
                Frame = new System.Drawing.RectangleF(0, 0, width, height)
            };

            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 15, height));
            objLeftView.AddSubview(uiImageView);
            objLeftView.Alpha = 0.4f;

            return objLeftView;
        }
    }
}