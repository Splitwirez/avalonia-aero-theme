using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace AvaloniaAero.Demo
{
    public class RadioButtonHackConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!ConversionHelper.TryGetDouble(value, out double val))
                return false;
                
            if (!ConversionHelper.TryGetDouble(parameter, out double param))
                return false;
            
            return ((int)val) == ((int)param);
        }




        static readonly object _ConvertBack_DEFAULT = BindingOperations.DoNothing;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!ConversionHelper.TryGetBool(value, out bool val))
                return _ConvertBack_DEFAULT;

            if (!ConversionHelper.TryGetDouble(value, out double param))
                return _ConvertBack_DEFAULT;

            
            if (val)
                return (int)param;
            
            return _ConvertBack_DEFAULT;
        }
    }
}
