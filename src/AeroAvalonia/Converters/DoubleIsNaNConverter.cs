using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace AeroAvalonia.Converters
{
    internal class DoubleIsNaNConverter
        : IValueConverter
    {
        public static readonly DoubleIsNaNConverter IsNaN = new DoubleIsNaNConverter(true);
        public static readonly DoubleIsNaNConverter IsNotNaN = new DoubleIsNaNConverter(false);
        
        
        readonly bool _equalTo;
        private DoubleIsNaNConverter(bool equalTo)
            => _equalTo = equalTo;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double val))
                return _equalTo;
            
            return (double.IsNaN(val) || double.IsInfinity(val)) == _equalTo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
