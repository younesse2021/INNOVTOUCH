using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XForms.Controls
{
    public class CustomBottomNavTabPage : TabbedPage
    {
        public static readonly BindableProperty IsHiddenroperty =
           BindableProperty.Create(nameof(IsHidden), typeof(bool), typeof(CustomBottomNavTabPage), false, BindingMode.TwoWay);

        public bool IsHidden
        {
            get { return (bool)GetValue(IsHiddenroperty); }
            set
            {
                SetValue(IsHiddenroperty, value);
            }
        }

        //public static readonly BindableProperty IsHiddenProperty = BindableProperty.Create("IsHidden", typeof(bool), typeof(CustomBottomNavTabPage), false);

        //public bool IsHidden
        //{
        //    set { SetValue(IsHiddenProperty, value); }
        //    get { return (bool)GetValue(IsHiddenProperty); }
        //}
    }
}