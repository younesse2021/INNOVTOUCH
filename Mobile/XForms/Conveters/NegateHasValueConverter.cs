using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XForms.Converters
{
    public class NegateHasValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(((IEnumerable<object>)value)?.Any() == true);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}