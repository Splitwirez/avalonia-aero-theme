using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace AvaloniaAero.Converters
{
    public class AdjustCornerRadiusConverter
        : IValueConverter
    {
        public double Amount { get; set; } = 0.0;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CornerRadius radii = (CornerRadius)value;
            var amount = Amount;

            return new CornerRadius(
                radii.TopLeft + amount
                , radii.TopRight + amount
                , radii.BottomRight + amount
                , radii.BottomLeft + amount
            );
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}