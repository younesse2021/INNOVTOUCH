using System;
using CoreGraphics;
using XForms.Controls;
using XForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Drawing;
using CoreAnimation;
using Foundation;
using XForms.Enums;
using System.ComponentModel;
using XForms.Enums;
using XForms.Interfaces;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace XForms.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);


            if (Control == null || this.Element == null) return;

            UpdateControl();

            //if (e.OldElement != null || e.NewElement == null)
            //    return;

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || this.Element == null) return;

            if (
                //e.PropertyName == CustomEntry.IsBorderErrorVisibleProperty.PropertyName ||
                e.PropertyName == CustomEntry.TextColorProperty.PropertyName ||
                e.PropertyName == CustomEntry.BackgroundColorProperty.PropertyName ||
                e.PropertyName == CustomEntry.BorderColorProperty.PropertyName ||
                e.PropertyName == CustomEntry.PlaceholderColorProperty.PropertyName
                )
            {

                UpdateControl();
            }
        }

        private  void UpdateControl()
        {
            var element = (CustomEntry)Element;

            //Control.KeyboardAppearance
            //    = App.AppTheme
            //    == Theme.Light ?
            //    Control.KeyboardAppearance = UIKeyboardAppearance.Light :
            //    Control.KeyboardAppearance = UIKeyboardAppearance.Dark;

            //Control.ReturnKeyType = UIReturnKeyType.Done;
            // Radius for the curves

            Control.Layer.MasksToBounds = true;

            Control.Layer.BorderWidth = element.BorderWidth;

            Control.BackgroundColor = element.BackgroundColor.ToUIColor();
            Control.TextAlignment = (UITextAlignment)element.HorizontalTextAlignment;

            if (!string.IsNullOrEmpty(element.Glyph))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        Control.LeftViewMode = UITextFieldViewMode.Always;
                        Control.LeftView = GetGlyphView(element.Glyph, element.TextColor, element.GlyphFontSize); ;
                        break;
                    case ImageAlignment.Right:
                        Control.RightViewMode = UITextFieldViewMode.Always;
                        Control.RightView = GetGlyphView(element.Glyph, element.TextColor, element.GlyphFontSize);
                        break;
                }
            }
            else
            {
                Control.LeftView = new UIView(new CGRect(0, 0, element.Padding.Left, 0));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIView(new CGRect(0, 0, element.Padding.Right, 0));
                Control.RightViewMode = UITextFieldViewMode.Always;
            }

            // Thickness of the Border Width  
            Control.ClipsToBounds = true;

            if (element.IsBorderErrorVisible)
            {
                Control.Layer.BorderColor = element.BorderErrorColor.ToCGColor();
            }
            else
            {
                Control.Layer.BorderColor = element.BorderColor.ToCGColor();
            }

            if (!element.IsHasBorder)
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }

            if (element.StyleCorner == ControlStyleCorner.RoundCorner)
            {
                element.SizeChanged += (sender, ev) =>
                {
                    Control.Layer.CornerRadius = (nfloat)element.Height / 2;
                };
            }
            else
            {
                Control.Layer.CornerRadius = element.CornerRaduis;
            }

        }

        private UIView GetGlyphView(string glyphCode, Xamarin.Forms.Color color, int fontSize)
        {
            var uiLabelView = new UILabel()
            {
                Frame = new RectangleF(15, 0, fontSize, fontSize),
                Text = glyphCode,
                TextColor = color.ToUIColor(),
                Font = UIFont.FromName("feather", fontSize / 2)
            };

            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, fontSize, fontSize));
            objLeftView.AddSubview(uiLabelView);

            return objLeftView;
        }

        //private UIView GetImageView(string imagePath, int height, int width)
        //{
        //    var uiImageView = new UIImageView(UIImage.FromBundle(imagePath))
        //    {
        //        Frame = new RectangleF(15, 0, width, height)
        //    };
        //    UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 30, height));
        //    objLeftView.AddSubview(uiImageView);

        //    return objLeftView;
        //}
    }
}