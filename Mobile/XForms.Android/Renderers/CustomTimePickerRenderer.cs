using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XForms.Controls;
using XForms.Droid.Renderers;
using XForms.Enums;

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(CustomTimePickerRenderer))]
namespace XForms.Droid.Renderers
{
    public class CustomTimePickerRenderer : TimePickerRenderer
    {

        CustomTimePicker element;

        public CustomTimePickerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (((CustomTimePicker)this.Element).IsCustom)
            {
                UpdateControl();
            }
            else
            {
                Control.SetBackgroundResource(Resource.Layout.TimeStyle);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);


            if (Control == null || this.Element == null) return;

            //if (e.PropertyName == CustomEntry.IsBorderErrorVisibleProperty.PropertyName)
            if (e.PropertyName == CustomTimePicker.TextColorProperty.PropertyName ||
                e.PropertyName == CustomTimePicker.BorderColorProperty.PropertyName ||
                e.PropertyName == CustomTimePicker.BackgroundColorProperty.PropertyName)
            {
                UpdateControl();
            }
        }

        private void UpdateControl()
        {
            try
            {
                element = (CustomTimePicker)Element;

                if (element.IsCustom)
                {
                    float density = Context.Resources.DisplayMetrics.Density;
                    GradientDrawable shape = new GradientDrawable();
                    shape.SetShape(ShapeType.Rectangle);
                    shape.SetColor(element.BackgroundColor.ToAndroid());
                    shape.SetStroke((int)(element.BorderWidth * density), element.BorderColor.ToAndroid());
                    shape.SetCornerRadius(((float)element.Height / 2) * density);

                    if (element.IsHasBorder)
                    {
                        if (element.StyleCorner == ControlStyleCorner.RoundCorner)
                        {
                            element.SizeChanged += (sender, ev) =>
                            {
                                shape.SetCornerRadius(((float)element.Height / 2) * density);
                                this.Control.Background = shape;
                            };
                        }
                        else
                        {
                            shape.SetCornerRadius(element.CornerRaduis * density);
                        }

                        if (element.IsBorderErrorVisible)
                            this.Control.Error = element.ErrorText;
                    }

                    if (!string.IsNullOrEmpty(element.Glyph))
                    {
                        switch (element.ImageAlignment)
                        {
                            case ImageAlignment.Left:
                                this.Control.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Glyph, element.TextColor, element.GlyphFontSize), null, null, null);
                                break;
                            case ImageAlignment.Right:
                                this.Control.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Glyph, element.TextColor, element.GlyphFontSize), null);
                                break;
                        }
                    }

                    this.Control.Background = shape;
                    //this.Control.Gravity = (Android.Views.GravityFlags)element.HorizontalTextAlignment;

                    var padding = element.Padding;
                    this.Control.SetPadding((int)(padding.Left * density), (int)(padding.Top * density), (int)(padding.Right * density), (int)(padding.Bottom * density));
                }
                else
                {
                    Control.SetBackgroundResource(Resource.Layout.EntryStyle);
                }
            }
            catch (System.Exception Ex)
            {
                System.Console.WriteLine(Ex.Message);
                //AppsHelper.Snack(Ex.Message);
            }
        }

        private BitmapDrawable GetDrawable(string glyphCode, Xamarin.Forms.Color color, int fontSize)
        {
            float density = Context.Resources.DisplayMetrics.Density;

            Bitmap myBitmap = Bitmap.CreateBitmap((fontSize * (int)density) + ((int)element.Padding.Right * 2), (fontSize * (int)density), Bitmap.Config.Argb8888);
            Canvas myCanvas = new Canvas(myBitmap);
            Paint paint = new Paint();
            Typeface typeface = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "fontawesome-solid.ttf");
            paint.AntiAlias = true;
            paint.SubpixelText = true;

            paint.TextAlign = Paint.Align.Right;

            paint.SetTypeface(typeface);
            paint.SetStyle(Paint.Style.Fill);
            paint.Color = color.ToAndroid();
            paint.TextSize = (fontSize * (int)density);

            int xPos = (myCanvas.Width / 2) + 42;
            int yPos = (int)((myCanvas.Height / 2) - (((int)paint.Descent() + (int)paint.Ascent()) / 2));

            myCanvas.DrawText(glyphCode, xPos, yPos, paint);

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(myBitmap, 50 + (int)element.Padding.Right, 50, true));
        }
    }
}
