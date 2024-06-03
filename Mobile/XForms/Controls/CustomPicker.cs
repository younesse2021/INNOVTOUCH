using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using XForms.Enums;
using Xamarin.Forms;

namespace XForms.Controls
{
	public class CustomPicker : Picker
	{

		private ControlStyleCorner styleCorner = ControlStyleCorner.Circle;
		public ControlStyleCorner StyleCorner
		{
			get { return styleCorner; }
			set { styleCorner = value; }
		}

		public static readonly BindableProperty IsBorderErrorVisibleProperty =
		   BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(CustomPicker), false, BindingMode.TwoWay);

		public bool IsBorderErrorVisible
		{
			get { return (bool)GetValue(IsBorderErrorVisibleProperty); }
			set
			{
				SetValue(IsBorderErrorVisibleProperty, value);
			}
		}

		public static readonly BindableProperty ErrorTextProperty =
		BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(CustomPicker), string.Empty);

		public string ErrorText
		{
			get { return (string)GetValue(ErrorTextProperty); }
			set
			{
				SetValue(ErrorTextProperty, value);
			}
		}


		public static readonly BindableProperty RightImageProperty =
		BindableProperty.Create(nameof(RightImage), typeof(string), typeof(CustomPicker), string.Empty);

		public string RightImage
		{
			get { return (string)GetValue(RightImageProperty); }
			set
			{
				SetValue(RightImageProperty, value);
			}
		}

		public static readonly BindableProperty IsHasBorderProperty =
		BindableProperty.Create(nameof(IsHasBorder), typeof(bool), typeof(CustomPicker), true, BindingMode.TwoWay);

		public bool IsHasBorder
		{
			get { return (bool)GetValue(IsHasBorderProperty); }
			set
			{
				SetValue(IsHasBorderProperty, value);
			}
		}

        public static readonly BindableProperty PaddingProperty =
BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(CustomPicker), new Thickness(15, 15));

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set
            {
                SetValue(PaddingProperty, value);
            }
        }
        public static readonly BindableProperty IsCustomProperty =
			BindableProperty.Create(nameof(IsCustom), typeof(bool), typeof(CustomPicker), false, BindingMode.TwoWay);

		public bool IsCustom
		{
			get { return (bool)GetValue(IsCustomProperty); }
			set
			{
				SetValue(IsCustomProperty, value);
			}
		}

		public static readonly BindableProperty BorderColorProperty =
		   BindableProperty.Create(nameof(BorderColor), typeof(Xamarin.Forms.Color), typeof(CustomPicker), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);
		public Xamarin.Forms.Color BorderColor
		{
			get { return (Xamarin.Forms.Color)GetValue(BorderColorProperty); }
			set
			{
				SetValue(BorderColorProperty, value);
			}
		}

		public static readonly BindableProperty CornerRaduisProperty =
		BindableProperty.Create(nameof(CornerRaduis), typeof(int), typeof(CustomPicker), 10);

		public int CornerRaduis
		{
			get { return (int)GetValue(CornerRaduisProperty); }
			set
			{
				SetValue(CornerRaduisProperty, value);
			}
		}

		public static readonly BindableProperty BorderWidthProperty =
	BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(CustomPicker), 1);

		public int BorderWidth
		{
			get { return (int)GetValue(BorderWidthProperty); }
			set
			{
				SetValue(BorderWidthProperty, value);
			}
		}

        public static readonly BindableProperty HorizontalTextAlignmentProperty =
    BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(CustomPicker), TextAlignment.Start);

        public TextAlignment HorizontalTextAlignment
        {

            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set
            {
                SetValue(HorizontalTextAlignmentProperty, value);
            }
        }

		public static readonly BindableProperty ImageAlignmentProperty =
		BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(CustomPicker), ImageAlignment.Left);

		public ImageAlignment ImageAlignment
		{
			get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
			set { SetValue(ImageAlignmentProperty, value); }
		}

		public static readonly BindableProperty GlyphProperty =
		  BindableProperty.Create(nameof(Glyph), typeof(string), typeof(CustomPicker), string.Empty);
		public string Glyph
		{
			get { return (string)GetValue(GlyphProperty); }
			set { SetValue(GlyphProperty, value); }
		}

		public static readonly BindableProperty GlyphFontSizeProperty =
		   BindableProperty.Create(nameof(GlyphFontSize), typeof(int), typeof(CustomPicker), 40);
		public int GlyphFontSize
		{
			get { return (int)GetValue(GlyphFontSizeProperty); }
			set { SetValue(GlyphFontSizeProperty, value); }
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

			this.SelectedIndexChanged += (sender, e) =>
			{
				if (Device.RuntimePlatform != Device.iOS)
				{
					NextView?.Focus();
				}
			};
		}

		public CustomPicker()
		{
			//if (Device.RuntimePlatform == Device.iOS)
			//{
				this.HeightRequest = 60;
			//}
		}

	}
}
