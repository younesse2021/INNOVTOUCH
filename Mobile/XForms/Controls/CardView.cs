using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using XForms.Enums;

namespace XForms.Controls
{
    public class CardView : Frame
    {
        private ControlStyleCorner styleCorner = ControlStyleCorner.Default;
        public ControlStyleCorner StyleCorner
        {
            get { return styleCorner; }
            set { styleCorner = value; }
        }

        public static readonly BindableProperty ElevationProperty = BindableProperty.Create(
            nameof(Elevation),
            typeof(int),
            typeof(CardView),
            4,
            propertyChanged: (control, _, __) => ((CardView)control).UpdateCard());

        public int Elevation
        {
            get { return (int)GetValue(ElevationProperty); }
            set { SetValue(ElevationProperty, value); }
        }

        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(
          nameof(ShadowColor),
          typeof(Color),
          typeof(CardView),
          Color.Gray,
          propertyChanged: (control, _, __) => ((CardView)control).UpdateCard());

        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly BindableProperty ShadowOffsetProperty = BindableProperty.Create(
  nameof(ShadowOffset),
  typeof(Size),
  typeof(CardView),
  new Size(2,2),
  propertyChanged: (control, _, __) => ((CardView)control).UpdateCard());

        public Size ShadowOffset
        {
            get { return (Size)GetValue(ShadowOffsetProperty); }
            set { SetValue(ShadowOffsetProperty, value); }
        }


        public static readonly BindableProperty ShadowOpacityProperty = BindableProperty.Create(
          nameof(ShadowOpacity),
          typeof(double),
          typeof(CardView),
          0.5,
          propertyChanged: (control, _, __) => ((CardView)control).UpdateCard());

        public double ShadowOpacity
        {
            get { return (double)GetValue(ShadowOpacityProperty); }
            set { SetValue(ShadowOpacityProperty, value); }
        }

        public CardView()
        {
            BackgroundColor = Color.White;
            HasShadow = false;
            Padding = new Thickness(12, 6);
            
             this.SizeChanged += (object sender, EventArgs e) =>
            {
                switch (StyleCorner)
                {
                    case ControlStyleCorner.Circle:
                        this.WidthRequest = this.Height - this.Padding.HorizontalThickness;
                        this.CornerRadius = (float)this.Height / 2;
                        break;
                    case ControlStyleCorner.RoundCorner:
                        this.CornerRadius = (float)this.Height / 2;
                        break;
                };
            };
        }



            private void UpdateCard()
            {
            //On<iOS>()
            //    .SetIsShadowEnabled(true)
            //    .SetShadowColor(Color.Black)
            //    .SetShadowOffset(new Size(4, 4))
            //    .SetShadowOpacity(1)
            //    .SetShadowRadius(Elevation / 2);

            //On<Android>()
            //    .SetElevation(Elevation);
        }

        /// <summary>
        /// Fix for styling a few properties (Padding, BackgroundColor...)
        /// </summary>
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == StyleProperty.PropertyName)
            {
                if (Style.Setters.Any(s => s.Property == PaddingProperty))
                {
                    Padding = (Thickness)Style.Setters.First(s => s.Property == PaddingProperty).Value;
                }

                //if (Style.Setters.Any(s => s.Property == BackgroundColorProperty))
                //{
                //    BackgroundColor = (Color)Style.Setters.First(s => s.Property == BackgroundColorProperty).Value;
                //}
            }
        }
    }
}
