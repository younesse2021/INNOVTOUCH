using System;
using System.Globalization;
using Xamarin.Forms;

namespace XForms.Converters
{
    public class ValueToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = true;

            if (value is int)
            {
                if ((int)value <= 0)
                    isVisible = false;
            }
            else if (string.IsNullOrEmpty(value as string))
            {
                isVisible = false;
            }

            return isVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}