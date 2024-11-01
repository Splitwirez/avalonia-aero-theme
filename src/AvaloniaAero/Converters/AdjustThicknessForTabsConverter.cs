using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;

namespace AvaloniaAero.Converters
{
    public class AdjustThicknessForTabsConverter
        : IMultiValueConverter
    {
        public static AdjustThicknessForTabsConverter Instance { get; } = new();
        private AdjustThicknessForTabsConverter()
        {}


        protected static readonly Thickness _ZERO = new(0);
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            var valuesCount = values.Count;
            if (valuesCount < 2)
                return _ZERO;
            
            if (!(values[0] is Thickness thickness))
                return _ZERO;
            
            if (!(values[1] is Dock dock))
                return thickness;
            
            return new Thickness(
                dock == Dock.Right
                    ? 0
                    : thickness.Left
                
                , dock == Dock.Bottom
                    ? 0
                    : thickness.Top
                
                , dock == Dock.Left
                    ? 0
                    : thickness.Right
                
                , dock == Dock.Top
                    ? 0
                    : thickness.Bottom
            );
        }
    }
}
