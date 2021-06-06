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
  
    [ValueConversion(typeof(decimal), typeof(bool))]
    [ValueConversion(typeof(int), typeof(bool))]
    public class NotZeroToTrueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // this will be called after getting the value from your backing property
            // and before displaying it in the textbox, so we just pass it as-is
            
            if (value != null)
            {
                bool IsZero = false;
                if (value is decimal)
                    IsZero = ((decimal)value)==0;
                else
                    if (value is int)
                        IsZero = ((int) value) == 0;

                if (parameter !=null)
                    return IsZero;
                else
                    return !IsZero;


            } else
                return false;
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
