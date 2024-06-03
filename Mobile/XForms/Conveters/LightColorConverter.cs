using System;
using System.Globalization;
using Xamarin.Forms;

namespace XForms.Converters
{
    public class LightColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            var alpha = GetParameter(parameter);
            var lightColor = new Color(color.R,color.G, color.B, alpha);

            return lightColor;
        }

       double GetParameter(object parameter)
        {
            if (parameter is double)
                return (double)parameter;

            else if (parameter is int)
                return (int)parameter;

            else if (parameter is string)
                return double.Parse((string)parameter, CultureInfo.InvariantCulture);

            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
