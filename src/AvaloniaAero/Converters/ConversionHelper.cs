using System;

namespace AvaloniaAero
{
    internal static class ConversionHelper
    {
        public static bool TryGetDouble(object value, out double result)
        {
            result = -1;
            if (value is double val)
            {
                result = val;
                return true;
            }
            else if (value != null)
            {
                if (double.TryParse(value.ToString(), out result))
                    return true;
            }
            
            return false;
        }

        public static bool TryGetBool(object value, out bool result)
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
    }
}