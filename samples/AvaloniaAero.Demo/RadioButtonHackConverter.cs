using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace AvaloniaAero.Demo
{
    public class RadioButtonHackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if
            (
                (
                    (value is int val)
                    || int.TryParse(value.ToString(), out val)
                )
                &&
                (
                    (parameter is int param)
                    || int.TryParse(parameter.ToString(), out param)
                )
            )
            {
                return val == param;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if
            (
                (
                    (value is bool val)
                    || bool.TryParse(value.ToString(), out val)
                )
                &&
                (
                    (parameter is int param)
                    || int.TryParse(parameter.ToString(), out param)
                )
            )
            {
                if (val)
                    return param;
            }
            return BindingOperations.DoNothing;
        }
    }
}
