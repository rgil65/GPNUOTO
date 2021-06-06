using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GPNuoto.Converters
{
  
    [ValueConversion(typeof(DateTime), typeof(Visibility))]
    public class DateNotNullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // this will be called after getting the value from your backing property
            // and before displaying it in the textbox, so we just pass it as-is
            if (parameter == null)
            {
                if (((DateTime)value).Year >1900)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }else
            {
                if (((DateTime) value).Year > 1900)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;

            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // this will be called after the textbox loses focus (in this case) and
            // before its value is passed to the property setter, so we make our
            // change here
            return 0;
        }
    }
}
