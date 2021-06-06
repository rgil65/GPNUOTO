using GPNuoto.ViewModel;
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
  
    [ValueConversion(typeof(CorsoViewModel.TipoCorsoValue), typeof(string))]
    public class TipoCorso2IconaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CorsoViewModel.TipoCorsoValue bValue = (CorsoViewModel.TipoCorsoValue) value;

            switch (bValue)
            { 
                case CorsoViewModel.TipoCorsoValue.Fisso:
                    return "FolderLock";
                case CorsoViewModel.TipoCorsoValue.Abbonamento:
                   return "FolderMultiple";
                default:
                    return "FolderAccount";
             }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
