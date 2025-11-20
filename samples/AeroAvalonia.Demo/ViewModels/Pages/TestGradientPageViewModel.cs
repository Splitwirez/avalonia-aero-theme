using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Media;

namespace AeroAvalonia.Demo.ViewModels
{
    public class TestGradientPageViewModel
        : PageViewModelBase
    {
        static readonly string _DEFAULT_Center;
        static readonly string _DEFAULT_GradientOrigin;
        static readonly double _DEFAULT_Radius;
        static TestGradientPageViewModel()
        {
            RadialGradientBrush brush = new();
            _DEFAULT_Center = brush.Center.ToString();
            _DEFAULT_GradientOrigin = brush.GradientOrigin.ToString();
            _DEFAULT_Radius = brush.Radius;
        }




        RadialGradientBrush _brush = new()
        {
            GradientStops = 
            {
                new(Colors.White, 0),
                new(Colors.Black, 1)
            }
        };


        public RadialGradientBrush GeneratedBrush
        {
            get => _brush;
            protected set => RASIC(ref _brush, value);
        }


        string _center = _DEFAULT_Center;
        public string Center
        {
            get => _center;
            set => RASIC(ref _center, value);
        }


        string _gradientOrigin = _DEFAULT_GradientOrigin;
        public string GradientOrigin
        {
            get => _gradientOrigin;
            set => RASIC(ref _gradientOrigin, value);
        }


        double _radius = _DEFAULT_Radius;
        public double Radius
        {
            get => _radius;
            set => RASIC(ref _radius, value);
        }




        public TestGradientPageViewModel()
        {
            PropertyChanged += This_PropertyChanged;
        }


        void This_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string propName = e.PropertyName;
            if (propName == nameof(GeneratedBrush))
                return;

            var brush = GeneratedBrush;


            if (propName == nameof(Radius))
            {
                brush.Radius = Radius;
            }
            else if (propName == nameof(Center))
            {
                if (RelativePoint_TryParse(propName, out RelativePoint center))
                    brush.Center = center;
                else
                    return;
            }
            else if (propName == nameof(GradientOrigin))
            {
                if (RelativePoint_TryParse(propName, out RelativePoint gradientOrigin))
                    brush.GradientOrigin = gradientOrigin;
                else
                    return;
            }
            else
            {
                return;
            }


            GeneratedBrush = brush;
        }
        static bool RelativePoint_TryParse(string value, out RelativePoint point)
        {
            try
            {
                point = RelativePoint.Parse(value);
                return true;
            }
            catch (Exception)
            {
                point = default;
                return false;
            }
        }
    }
}
