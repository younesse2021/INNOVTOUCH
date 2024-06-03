using System;
using Xamarin.Forms;
using XForms.Enums;

namespace XForms.Controls
{
    public class CustomImage : Image
    {
        public static readonly BindableProperty GlyphColorProperty =
           BindableProperty.Create(nameof(GlyphColor), typeof(Color), typeof(CustomImage), Color.White);

        public Color GlyphColor
        {
            get { return (Color)GetValue(GlyphColorProperty); }
            set { SetValue(GlyphColorProperty, value); }
        }


        private ControlStyleCorner styleCorner = ControlStyleCorner.Circle;
        public ControlStyleCorner StyleCorner
        {
            get { return styleCorner; }
            set { styleCorner = value; }
        }

        public CustomImage()
        {
            this.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == nameof(GlyphColor))
                {
                    this.Source?.SetValue(FontImageSource.ColorProperty, GlyphColor);
                }
            };

            this.SizeChanged += (object sender, EventArgs e) =>
            {
                switch (StyleCorner)
                { 
                    case ControlStyleCorner.Square:
                    this.HeightRequest = this.Width;

                    break;

                };
            };
        }
    }
}