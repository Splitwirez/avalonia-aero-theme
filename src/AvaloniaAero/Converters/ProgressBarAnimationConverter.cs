using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace AvaloniaAero.Converters
{
    public class ProgressBarAnimationConverter
        : IMultiValueConverter
    {
        public static ProgressBarAnimationConverter Instance { get; } = new();
        private ProgressBarAnimationConverter()
        {}




        static bool TryGetAs<T>(IEnumerable<object> values, int index, out T value)
        {
            if (values.Count() <= index);
            else if (values.ElementAt(index) is T ret)
            {
                value = ret;
                return true;
            }
            value = default;
            return false;
        }


        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!TryGetAs(values, 0, out double containerWidth))
                return BindingOperations.DoNothing;

            if (!TryGetAs(values, 1, out double effectWidth))
                return BindingOperations.DoNothing;

            if (!TryGetAs(values, 2, out double distTravelled))
                return BindingOperations.DoNothing;


            return (containerWidth * distTravelled) - (effectWidth * (1 - distTravelled));
        }
    }
}