using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Layout;
using Avalonia.Media;

namespace AvaloniaAero.Converters
{
    public class ProgressBarFillBrushConverter
        : IMultiValueConverter
    {
        public static ProgressBarFillBrushConverter Instance { get; } = new();
        private ProgressBarFillBrushConverter()
        {}


        static bool TryGetColorFrom(object obj, out Color color)
        {
            if (obj == null)
            {
                goto fail;
            }
            else if (obj is Color cl)
            {
                color = cl;
            }
            else if (obj is SolidColorBrush scBrush)
            {
                color = scBrush.Color;
            }
            else if (obj is GradientBrush grBrush)
            {
                var stops = grBrush.GradientStops;
                if (stops.Count <= 0)
                    goto fail;
                color = stops[0].Color;
            }
            else
            {
                goto fail;
            }
            return color != null;

            fail:
            color = default;
            return false;
        }
        const double _L_DENOM = 35d / 41d;
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!TryGetColorFrom(values[0], out Color color1))
            {
                return values[2];
            }
            
            bool vertical = (Orientation)values[1] == Orientation.Vertical;

            var hsl1 = color1.ToHsl();
            var hsl0 = HslColor.FromAhsl(color1.A, hsl1.H, hsl1.S, hsl1.L * _L_DENOM);
            Color color0 = hsl0.ToRgb();

            return new LinearGradientBrush()
            {
                StartPoint = new(0, 0, RelativeUnit.Relative),
                EndPoint = new(
                    vertical ? 0 : 1,
                    vertical ? 1 : 0,
                    RelativeUnit.Relative
                ),
                GradientStops = new()
                {
                    new(color0, 0),
                    new(color1, 0.5),
                    new(color0, 1),
                },
            };
        }
    }
}