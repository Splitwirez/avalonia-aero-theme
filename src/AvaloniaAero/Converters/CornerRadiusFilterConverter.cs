#if NO
using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls.Converters;
using Avalonia.Data.Converters;

namespace AvaloniaAero
{
    internal class CornerRadiusFilterConverter
        : AvaloniaObject
        , IValueConverter
    {
        public static readonly StyledProperty<bool> TopLeftProperty =
            AvaloniaProperty.Register<CornerRadiusFilterConverter, bool>(nameof(TopLeft), true);
        public bool TopLeft
        {
            get => GetValue(TopLeftProperty);
            set => SetValue(TopLeftProperty, value);
        }



        public static readonly StyledProperty<bool> TopRightProperty =
            AvaloniaProperty.Register<CornerRadiusFilterConverter, bool>(nameof(TopRight), true);
        public bool TopRight
        {
            get => GetValue(TopRightProperty);
            set => SetValue(TopRightProperty, value);
        }



        public static readonly StyledProperty<bool> BottomRightProperty =
            AvaloniaProperty.Register<CornerRadiusFilterConverter, bool>(nameof(BottomRight), true);
        public bool BottomRight
        {
            get => GetValue(BottomRightProperty);
            set => SetValue(BottomRightProperty, value);
        }



        public static readonly StyledProperty<bool> BottomLeftProperty =
            AvaloniaProperty.Register<CornerRadiusFilterConverter, bool>(nameof(BottomLeft), true);
        public bool BottomLeft
        {
            get => GetValue(BottomLeftProperty);
            set => SetValue(BottomLeftProperty, value);
        }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CornerRadius radii = (CornerRadius)value;
            return new CornerRadius(
                TopLeft
                    ? radii.TopLeft
                    : 0
                ,
                TopRight
                    ? radii.TopRight
                    : 0
                ,
                BottomRight
                    ? radii.BottomRight
                    : 0
                ,
                BottomLeft
                    ? radii.BottomLeft
                    : 0
            );
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


        //public static CornerRadiusFilterConverter
    }
}
#endif