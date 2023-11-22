using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace AvaloniaAero.Demo
{
    public class RadioButtonHackConverter : IValueConverter
    {
        static bool TryGetInt(object value, out int result)
        {
            result = -1;
            if (value is int val)
            {
                result = val;
                return true;
            }
            else if (value != null)
            {
                if (int.TryParse(value.ToString(), out result))
                    return true;
            }
            
            return false;
        }

        static bool TryGetBool(object value, out bool result)
        {
            result = false;
            if (value is bool val)
            {
                result = val;
                return true;
            }
            else if (value != null)
            {
                if (bool.TryParse(value.ToString(), out result))
                    return true;
            }
            
            return false;
        }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!TryGetInt(value, out int val))
                return false;
                
            if (!TryGetInt(parameter, out int param))
                return false;
            
            return val == param;
        }




        static readonly object _ConvertBack_DEFAULT = BindingOperations.DoNothing;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!TryGetBool(value, out bool val))
                return _ConvertBack_DEFAULT;

            if (!TryGetInt(value, out int param))
                return _ConvertBack_DEFAULT;

            
            if (val)
                return param;
            
            return _ConvertBack_DEFAULT;
        }
    }
}
