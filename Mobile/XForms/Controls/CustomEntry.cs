using System;
using System.Linq;
using System.Runtime.CompilerServices;
using XForms.Enums;
using Xamarin.Forms;

namespace XForms.Controls
{
    public class CustomEntry : Entry
    {
        private ControlStyleCorner styleCorner = ControlStyleCorner.Default;
        public ControlStyleCorner StyleCorner
        {
            get { return styleCorner; }
            set { styleCorner = value; }
        }

        public static readonly BindableProperty ImageProperty =
    BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomEntry), string.Empty);

        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create(nameof(LineColor), typeof(Xamarin.Forms.Color), typeof(CustomEntry), Color.White);


        public static readonly BindableProperty GlyphProperty =
            BindableProperty.Create(nameof(Glyph), typeof(string), typeof(CustomEntry), string.Empty);


        public static readonly BindableProperty GlyphFontSizeProperty =
           BindableProperty.Create(nameof(GlyphFontSize), typeof(int), typeof(CustomEntry), 40);

        public static readonly BindableProperty ImageHeightProperty =
            BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(CustomEntry), 20);

        public static readonly BindableProperty ImageWidthProperty =
            BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(CustomEntry), 20);

        public static readonly BindableProperty ImageAlignmentProperty =
            BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(CustomEntry), ImageAlignment.Left);

 public static readonly BindableProperty BackgroundColorProperty =
          BindableProperty.Create(nameof(BackgroundColor), typeof(Xamarin.Forms.Color), typeof(CustomEntry), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);
        public Xamarin.Forms.Color BackgroundColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BackgroundColorProperty); }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }
        
        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }

        public int GlyphFontSize
        {
            get { return (int)GetValue(GlyphFontSizeProperty); }
            set { SetValue(GlyphFontSizeProperty, value); }
        }

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public ImageAlignment ImageAlignment
        {
            get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }

        public static readonly BindableProperty IsBorderErrorVisibleProperty =
            BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(CustomEntry), false, BindingMode.TwoWay);

        public bool IsBorderErrorVisible
        {
            get { return (bool)GetValue(IsBorderErrorVisibleProperty); }
            set
            {
                SetValue(IsBorderErrorVisibleProperty, value);
            }
        }

        public static readonly BindableProperty IsHasBorderProperty =
           BindableProperty.Create(nameof(IsHasBorder), typeof(bool), typeof(CustomEntry), true, BindingMode.TwoWay);

        public bool IsHasBorder
        {
            get { return (bool)GetValue(IsHasBorderProperty); }
            set
            {
                SetValue(IsHasBorderProperty, value);
            }
        }


        public static readonly BindableProperty IsAutoNextFocusProperty =
            BindableProperty.Create(nameof(IsAutoNextFocus), typeof(bool), typeof(CustomEntry), false, BindingMode.TwoWay);

        public bool IsAutoNextFocus
        {
            get { return (bool)GetValue(IsAutoNextFocusProperty); }
            set
            {
                SetValue(IsAutoNextFocusProperty, value);
            }
        }

        public static readonly BindableProperty IsCustomProperty =
            BindableProperty.Create(nameof(IsCustom), typeof(bool), typeof(CustomEntry), true, BindingMode.TwoWay);

        public bool IsCustom
        {
            get { return (bool)GetValue(IsCustomProperty); }
            set
            {
                SetValue(IsCustomProperty, value);
            }
        }

        public static readonly BindableProperty BorderErrorColorProperty =
            BindableProperty.Create(nameof(BorderErrorColor), typeof(Xamarin.Forms.Color), typeof(CustomEntry), Xamarin.Forms.Color.Red, BindingMode.TwoWay);

        public Xamarin.Forms.Color BorderErrorColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BorderErrorColorProperty); }
            set
            {
                SetValue(BorderErrorColorProperty, value);
            }
        }

        public static readonly BindableProperty ErrorTextProperty =
        BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(CustomEntry), string.Empty);

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set
            {
                SetValue(ErrorTextProperty, value);
            }
        }

        public static readonly BindableProperty BorderColorProperty =
           BindableProperty.Create(nameof(BorderColor), typeof(Xamarin.Forms.Color), typeof(CustomEntry), Xamarin.Forms.Color.Gray, BindingMode.TwoWay);
        public Xamarin.Forms.Color BorderColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BorderColorProperty); }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public static readonly BindableProperty BorderWidthProperty =
     BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(CustomEntry), 1);

        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set
            {
                SetValue(BorderWidthProperty, value);
            }
        }

        public static readonly BindableProperty CornerRaduisProperty =
        BindableProperty.Create(nameof(CornerRaduis), typeof(int), typeof(CustomEntry), 10);

        public int CornerRaduis
        {
            get { return (int)GetValue(CornerRaduisProperty); }
            set
            {
                SetValue(CornerRaduisProperty, value);
            }
        }

        //    public static readonly BindableProperty HorizontalTextAlignmentProperty =
        //BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(CustomEntry), TextAlignment.Start);

        //    public TextAlignment HorizontalTextAlignment
        //    {

        //        get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
        //        set
        //        {
        //            SetValue(HorizontalTextAlignmentProperty, value);
        //        }
        //    }

        public static readonly BindableProperty PaddingProperty =
  BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(CustomEntry), new Thickness(10, 15));

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set
            {
                SetValue(PaddingProperty, value);
            }
        }

        public static readonly BindableProperty NextViewProperty = BindableProperty.Create(nameof(NextView), typeof(View), typeof(Entry));
        public View NextView
        {
            get => (View)GetValue(NextViewProperty);
            set => SetValue(NextViewProperty, value);
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            this.Completed += (sender, e) =>
            {
                OnNext();
            };
        }

        public void OnNext()
        {
            NextView?.Focus();
        }

        public CustomEntry()
        {
            //this.Effects.Add(Effect.Resolve("Effects.EntryMoveNextEffect"));
            //this.Behaviors.Add(new Behavior.EmptyEntryValidatorBehavior());
            //if (Device.RuntimePlatform == Device.iOS)
            //{
            this.HeightRequest = 60;
            //}

            this.TextChanged += (sender, e) =>
            {
                if (IsAutoNextFocus)
                {
                    if (Text.Length == 1 && MaxLength == 1 && NextView != null)
                    {
                        NextView?.Focus();
                    }
                }
            };

            this.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == nameof(BackgroundColor))
                {
                    this.BackgroundColor = BackgroundColor;
                }
            };
        }
    }
}
