using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XForms.Controls
{
    public class CustomNativeEntry : Entry
    {
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

        public CustomNativeEntry()
        {

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
        }
    }
}
