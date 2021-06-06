using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GPNuoto.Converters
{
  
    [ValueConversion(typeof(TimeSpan), typeof(DateTime))]
    public class TimeSpanToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // this will be called after getting the value from your backing property
            // and before displaying it in the textbox, so we just pass it as-is
            if (value is TimeSpan)
            {
                TimeSpan v = (TimeSpan)value;
                return new DateTime(1,1,1,v.Hours,v.Minutes,v.Seconds);
            }
            else
                return new DateTime(1, 1, 1, 0,0,0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // this will be called after the textbox loses focus (in this case) and
            // before its value is passed to the property setter, so we make our
            // change here
            if (value is DateTime)
            {
                DateTime v = (DateTime) value;
                return new TimeSpan(v.Hour, v.Minute, v.Second);
            }
            else
                return new TimeSpan(0);
        }
    }
}
