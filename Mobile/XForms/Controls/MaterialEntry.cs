using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
//using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;
using XForms.Enums;

namespace XForms.Controls
{
    public partial class MaterialEntry : StackLayout
    {
        private ControlStyleCorner styleCorner = ControlStyleCorner.Default;
        public ControlStyleCorner StyleCorner
        {
            get { return styleCorner; }
            set { styleCorner = value; }
        }
        
        public static readonly BindableProperty HasLeftGlyphProperty =
          BindableProperty.Create(nameof(HasLeftGlyph), typeof(bool), typeof(View), false, BindingMode.TwoWay);

        public bool HasLeftGlyph
        {
            get { return (bool)GetValue(HasLeftGlyphProperty); }
            set
            {
                SetValue(HasLeftGlyphProperty, value);
            }
        }

        public static readonly BindableProperty LeftGlyphProperty =
         BindableProperty.Create(nameof(LeftGlyph), typeof(string), typeof(View), string.Empty, BindingMode.TwoWay);

        public string LeftGlyph
        {
            get { return (string)GetValue(LeftGlyphProperty); }
            set
            {
                SetValue(LeftGlyphProperty, value);
            }
        }

        public static readonly BindableProperty HasRightGlyphProperty =
         BindableProperty.Create(nameof(HasRightGlyph), typeof(bool), typeof(View), false, BindingMode.TwoWay);

        public bool HasRightGlyph
        {
            get { return (bool)GetValue(HasRightGlyphProperty); }
            set
            {
                SetValue(HasRightGlyphProperty, value);
            }
        }

        public static readonly BindableProperty RightGlyphProperty =
         BindableProperty.Create(nameof(RightGlyph), typeof(string), typeof(View), string.Empty, BindingMode.TwoWay);

        public string RightGlyph
        {
            get { return (string)GetValue(RightGlyphProperty); }
            set
            {
                SetValue(RightGlyphProperty, value);
            }
        }



        public static readonly BindableProperty TextProperty =
           BindableProperty.Create(nameof(Text), typeof(string), typeof(View), string.Empty, BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly BindableProperty PlaceholderProperty =
           BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(View), string.Empty, BindingMode.TwoWay);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }

        public static readonly BindableProperty NextViewProperty = BindableProperty.Create(nameof(NextView), typeof(View), typeof(View));
        public View NextView
        {
            get => (View)GetValue(NextViewProperty);
            set
            {
                SetValue(NextViewProperty, value);

                //if (NextView != null)
                //{
                //    var entry = (((this.Children.FirstOrDefault() as Frame)?.Content as Grid)?.Children.FirstOrDefault() as Entry);

                //    if (entry != null)
                //    {
                //        entry.ReturnType = ReturnType.Next;
                //    }
                //}
            }
        }

        public static readonly BindableProperty ErrorTextProperty =
            BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(View), "Champ obligatoire*", BindingMode.TwoWay);

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set
            {
                SetValue(ErrorTextProperty, value);
            }
        }

        public static readonly BindableProperty ErrorVisibilityProperty =
             BindableProperty.Create(nameof(ErrorVisibility), typeof(bool), typeof(View), false, BindingMode.TwoWay);

        public bool ErrorVisibility
        {
            get { return (bool)GetValue(ErrorVisibilityProperty); }
            set
            {
                SetValue(ErrorVisibilityProperty, value);

            }
        }

        public static readonly BindableProperty KeyboardTypeProperty =
         BindableProperty.Create(nameof(KeyboardType), typeof(Keyboard), typeof(View), default, BindingMode.TwoWay);

        public Keyboard KeyboardType
        {
            get { return (Keyboard)GetValue(KeyboardTypeProperty); }
            set
            {
                SetValue(KeyboardTypeProperty, value);
            }
        }

        public static readonly BindableProperty KeyboardReturnTypeProperty =
           BindableProperty.Create(nameof(KeyboardReturnType), typeof(ReturnType), typeof(View), default, BindingMode.TwoWay);

        public ReturnType KeyboardReturnType
        {
            get { return (ReturnType)GetValue(KeyboardReturnTypeProperty); }
            set
            {
                SetValue(KeyboardReturnTypeProperty, value);
            }
        }

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(View), false, BindingMode.TwoWay);

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        public static readonly BindableProperty MaxLengthProperty =
           BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(View), int.MaxValue, BindingMode.TwoWay);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }

        public static readonly BindableProperty IsAutoNextFocusProperty =
         BindableProperty.Create(nameof(IsAutoNextFocus), typeof(bool), typeof(View), false, BindingMode.TwoWay);

        public bool IsAutoNextFocus
        {
            get { return (bool)GetValue(IsAutoNextFocusProperty); }
            set
            {
                SetValue(IsAutoNextFocusProperty, value);
            }
        }

        public static readonly BindableProperty ReturnCommandProperty =
       BindableProperty.Create(nameof(ReturnCommand), typeof(ICommand), typeof(MaterialEntry), default, defaultBindingMode: BindingMode.OneWay);

        public ICommand ReturnCommand
        {
            get => (ICommand)GetValue(ReturnCommandProperty);
            set => SetValue(ReturnCommandProperty, value);
        }

        public static readonly BindableProperty ReturnCommandParameterProperty =
       BindableProperty.Create(nameof(ReturnCommandParameter), typeof(object), typeof(MaterialEntry), default, defaultBindingMode: BindingMode.OneWay);

        public object ReturnCommandParameter
        {
            get => (object)GetValue(ReturnCommandParameterProperty);
            set => SetValue(ReturnCommandParameterProperty, value);
        }

        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as CustomNativeEntry).Completed += (sender, e) =>
            {
                OnNext();
            };
        }


        public void OnNext()
        {
            if (NextView?.FindByName("NativeEntry") is CustomNativeEntry entry)
            {
                entry.Focus();
            }
        }

        //public string PasswordGlyph { get; set; } = XForms.Resources.FontAwesomeFonts.Eye;
        public string PasswordGlyph { get; set; } 
        public Color BorderColor => ErrorVisibility ? AppHelpers.LookupColor("RedStatut") : AppHelpers.LookupColor("InputBorder");

        public MaterialEntry()
        {
            InitializeComponent();

            try
            {

                NativeEntry.TextChanged += (sender, e) =>
                {
                    if (IsAutoNextFocus)
                    {
                        if (NativeEntry.Text?.Length == 1 && MaxLength == 1 && NextView != null)
                        {
                            OnNext();
                        }
                    }
                };

                this.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
                {
                    if (e.PropertyName == nameof(NextView))
                    {
                        NativeEntry.ReturnType = ReturnType.Next;
                    }

                    if (e.PropertyName == nameof(KeyboardReturnType))
                    {
                        NativeEntry.ReturnType = KeyboardReturnType;
                    }

                    if (e.PropertyName == nameof(ErrorVisibility))
                    {
                        OnPropertyChanged(nameof(BorderColor));
                    }


                    if (e.PropertyName == nameof(HasLeftGlyph))
                    {
                        PCView.Padding = HasLeftGlyph ? new Thickness(18, 2, 0, 2) : new Thickness(0, 2, 0, 2);
                    }

                    this.SizeChanged += (object sender, EventArgs e) =>
                    {
                        switch (StyleCorner)
                        {
                            case ControlStyleCorner.Default:
                                PCView.CornerRadius = 5;
                                break;
                            case ControlStyleCorner.RoundCorner:
                                PCView.CornerRadius = (int)this.Height / 2;
                                break;
                        }
                    };
                };
            }
            catch (Exception ex)
            {
                AppHelpers.Alert(message: ex.Message, exception: ex);
            }
        }

        private void ShowOrHidePassword_Clicked(object sender, EventArgs e)
        {
            if (NativeEntry.IsPassword)
            {
                NativeEntry.IsPassword = false;
                PasswordGlyph = XForms.Resources.FontAwesomeFonts.EyeSlash;
            }
            else
            {
                NativeEntry.IsPassword = true;
                PasswordGlyph = XForms.Resources.FontAwesomeFonts.Eye;
            }

            NativeEntry.Focus();
            NativeEntry.CursorPosition = (NativeEntry.Text ?? "").Length;
        }

    }
}