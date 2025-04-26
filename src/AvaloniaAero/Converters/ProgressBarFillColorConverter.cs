using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace AvaloniaAero.Converters
{
    public class ProgressBarFillColorConverter
        : IMultiValueConverter
    {
        const string _BRUSH = ";brush";
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            var valuesCount = values.Count();
            if (valuesCount < 2)
                return null;

            var fallback = values[1];
            if (!ProgressBarFillBrushConverter.TryGetColorFrom(values[0], out Color color1))
                return fallback;

            object lightnessObj = values.Count() > 2
                ? values[2]
                : parameter
            ;

            if (lightnessObj == null)
                return fallback;

            bool returnBrush = false;
            string lightnessStr = lightnessObj.ToString();
            if (lightnessStr.Contains(_BRUSH))
            {
                returnBrush = true;
                lightnessStr = lightnessStr.Replace(_BRUSH, string.Empty);
            }


            if (!double.TryParse(lightnessStr, out double lightness))
                return fallback;


            var hsl = color1.ToHsl();
            hsl = HslColor.FromAhsl(color1.A, hsl.H, hsl.S, lightness);
            Color color = hsl.ToRgb();

            if (returnBrush)
                return new SolidColorBrush(color);
            else
                return color;
        }
    }
}