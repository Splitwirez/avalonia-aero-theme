using System;

namespace AvaloniaAero.Demo.ViewModels
{
    public class ProgressBarPageViewModel
        : PageViewModelBase
    {
        double _value = 5;
        public double Value
        {
            get => _value;
            set => RASIC(ref _value, value);
        }


        double _minimum = 0;
        public double Minimum
        {
            get => _minimum;
            protected set => RASIC(ref _minimum, value);
        }


        double _maximum = 10;
        public double Maximum
        {
            get => _maximum;
            protected set => RASIC(ref _maximum, value);
        }
    }
}
