using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XForms.Controls
{
    public class CustomSwitch : Grid
    {
        public static readonly BindableProperty TextLightProperty = BindableProperty.Create(nameof(TextLight), typeof(string), typeof(CustomSwitch));
        public string TextLight
        {
            get
            {
                return (string)GetValue(TextLightProperty);
            }
            set
            {
                SetValue(TextLightProperty, value);
            }
        }

        public static readonly BindableProperty TextDarkProperty = BindableProperty.Create(nameof(TextDark), typeof(string), typeof(CustomSwitch));
        public string TextDark
        {
            get
            {
                return (string)GetValue(TextDarkProperty);
            }
            set
            {
                SetValue(TextDarkProperty, value);
            }
        }

        public static readonly BindableProperty LightColorProperty = BindableProperty.Create(nameof(LightColor), typeof(Color), typeof(CustomSwitch), Color.LightGray);
        public Color LightColor
        {
            get
            {
                return (Color)GetValue(LightColorProperty);
            }
            set
            {
                SetValue(LightColorProperty, value);
            }
        }

        public static readonly BindableProperty DarkColorProperty = BindableProperty.Create(nameof(DarkColor), typeof(Color), typeof(CustomSwitch), Color.LightBlue);
        public Color DarkColor
        {
            get
            {
                return (Color)GetValue(DarkColorProperty);
            }
            set
            {
                SetValue(DarkColorProperty, value);
            }
        }

        public static readonly BindableProperty HeightRequestProperty =
          BindableProperty.Create(nameof(HeightRequest), typeof(int), typeof(CustomSwitch), 50);
        public int HeightRequest
        {
            get { return (int)GetValue(HeightRequestProperty); }
            set
            {
                SetValue(HeightRequestProperty, value);
            }
        }

        public static readonly BindableProperty FontSizeProperty =
         BindableProperty.Create(nameof(FontSize), typeof(int), typeof(CustomSwitch), 15);
        public int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        public static readonly BindableProperty SwitchOneCommandProperty =
    BindableProperty.Create(nameof(SwitchOneCommand), typeof(ICommand), typeof(CustomSwitch), default, defaultBindingMode: BindingMode.OneWay);

        public ICommand SwitchOneCommand
        {
            get => (ICommand)GetValue(SwitchOneCommandProperty);
            set => SetValue(SwitchOneCommandProperty, value);
        }

        public static readonly BindableProperty SwitchOneCommandParameterProperty =
     BindableProperty.Create(nameof(SwitchOneCommandParameter), typeof(object), typeof(CustomSwitch), default, defaultBindingMode: BindingMode.OneWay);

        public object SwitchOneCommandParameter
        {
            get => (object)GetValue(SwitchOneCommandParameterProperty);
            set => SetValue(SwitchOneCommandParameterProperty, value);
        }

        public static readonly BindableProperty SwitchTwoCommandProperty =
    BindableProperty.Create(nameof(SwitchTwoCommand), typeof(ICommand), typeof(CustomSwitch), default, defaultBindingMode: BindingMode.TwoWay);

        public ICommand SwitchTwoCommand
        {
            get => (ICommand)GetValue(SwitchTwoCommandProperty);
            set => SetValue(SwitchTwoCommandProperty, value);
        }

        public static readonly BindableProperty SwitchTwoCommandParameterProperty =
     BindableProperty.Create(nameof(SwitchTwoCommandParameter), typeof(object), typeof(CustomSwitch), default, defaultBindingMode: BindingMode.TwoWay);

        public object SwitchTwoCommandParameter
        {
            get => (object)GetValue(SwitchTwoCommandParameterProperty);
            set => SetValue(SwitchTwoCommandParameterProperty, value);
        }

        private BoxView parentSwitchView, childSwitchView;
        private Label switchTxtOne, switchTxtTwo;

        public event EventHandler ClickedSwitchOne, ClickedSwitchTwo;
        private double ViewWidth;
        private bool isSwitchInRight;

        public CustomSwitch()
        {
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            this.ColumnSpacing = 0;

            //BoxView 
            parentSwitchView = new BoxView()
            {
                BindingContext = this,
                CornerRadius = Device.RuntimePlatform == Device.Android ? 40 : 20
            };
            parentSwitchView.SetBinding(BackgroundColorProperty, new Binding(nameof(LightColor)));

            childSwitchView = new BoxView()
            {
                BindingContext = this,
                CornerRadius = Device.RuntimePlatform == Device.Android ? 40 : 20
            };

            childSwitchView.SetBinding(BackgroundColorProperty, new Binding(nameof(DarkColor)));

            //Label
            switchTxtOne = new Label()
            {
                BindingContext = this,
                MaxLines = 2,
                LineBreakMode = LineBreakMode.TailTruncation,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            switchTxtOne.SetBinding(Label.FontSizeProperty, new Binding(nameof(FontSize)));
            switchTxtOne.SetBinding(Label.TextProperty, new Binding(nameof(TextDark)));

            switchTxtTwo = new Label()
            {
                BindingContext = this,
                MaxLines = 2,
                LineBreakMode = LineBreakMode.TailTruncation,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
            };

            switchTxtTwo.SetBinding(Label.FontSizeProperty, new Binding(nameof(FontSize)));
            switchTxtTwo.SetBinding(Label.TextProperty, new Binding(nameof(TextLight)));
            switchTxtTwo.SetBinding(Label.TextColorProperty, new Binding(nameof(DarkColor)));

            //Setup
            this.Children.Add(parentSwitchView);
            this.Children.Add(childSwitchView);
            this.Children.Add(switchTxtOne, 0, 0);
            this.Children.Add(switchTxtTwo, 1, 0);

            Grid.SetColumnSpan(parentSwitchView, 2);

            //Events
            TapGestureRecognizer gestureSwitchOne = new TapGestureRecognizer()
            {
                Command = SwitchOneCommand,
                CommandParameter = SwitchOneCommandParameter
            };

            gestureSwitchOne.Tapped += GestureSwitchOne;
            switchTxtOne.GestureRecognizers.Add(gestureSwitchOne);

            TapGestureRecognizer gestureSwitchTwo = new TapGestureRecognizer()
            {
                Command = SwitchTwoCommand,
                CommandParameter = SwitchTwoCommandParameter
            };

            gestureSwitchTwo.Tapped += GestureSwitchTwo;
            switchTxtTwo.GestureRecognizers.Add(gestureSwitchTwo);
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > -1 && height > -1 && ViewWidth > -1 && (width != ViewWidth))
            {
                ViewWidth = width;

                childSwitchView.TranslationX = isSwitchInRight ? (ViewWidth / 2) : 0;
            }
        }

        private void GestureSwitchOne(object sender, EventArgs e)
        {
            SwitchOne();
            ClickedSwitchOne?.Invoke(sender, e);
        }

        private void GestureSwitchTwo(object sender, EventArgs e)
        {
            SwitchTwo();
            ClickedSwitchTwo?.Invoke(sender, e);
        }

        public async void SwitchOne()
        {
            switchTxtOne.TextColor = Color.White;

            switchTxtTwo.TextColor = DarkColor;
            _ = childSwitchView.FadeTo(.8, 100, Easing.CubicIn);
            await childSwitchView.TranslateTo(0, 0, 200, Easing.CubicOut);
            _ = childSwitchView.FadeTo(1, 100, Easing.CubicIn);

            isSwitchInRight = false;
        }

        public async void SwitchTwo()
        {
            switchTxtOne.TextColor = DarkColor;
            switchTxtTwo.TextColor = Color.White;

            _ = childSwitchView.FadeTo(.8, 100, Easing.CubicIn);
            await childSwitchView.TranslateTo(ViewWidth / 2, 0, 200, Easing.CubicOut);
            _ = childSwitchView.FadeTo(1, 100, Easing.CubicIn);

            isSwitchInRight = true;
        }
    }
}