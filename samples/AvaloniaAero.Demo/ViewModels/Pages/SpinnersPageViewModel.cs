using System;
using System.Collections.Generic;
using System.Linq;
using Location = Avalonia.Controls.Location;

namespace AvaloniaAero.Demo.ViewModels
{
    public class SpinnersPageViewModel
        : PageViewModelBase
    {
        static readonly string[] _mountains = new[]
        {
            "Everest",
            "K2 (Mount Godwin Austen)",
            "Kangchenjunga",
            "Lhotse",
            "Makalu",
            "Cho Oyu",
            "Dhaulagiri",
            "Manaslu",
            "Nanga Parbat",
            "Annapurna"
        };


        double _doubleValue = 0;
        public double DoubleValue
        {
            get => _doubleValue;
            set => RASIC(ref _doubleValue, value);
        }


        readonly SpinnersPageSpinnerViewModel _spinnerVM1 = new SpinnersPageSpinnerViewModel(_mountains);
        public SpinnersPageSpinnerViewModel SpinnerVM1
        {
            get => _spinnerVM1;
        }

        
        readonly SpinnersPageSpinnerViewModel _spinnerVM2 = new SpinnersPageSpinnerViewModel(_mountains, 1);
        public SpinnersPageSpinnerViewModel SpinnerVM2
        {
            get => _spinnerVM2;
        }


        /*
        readonly SpinnersPageSpinnerViewModel _spinnerVM3 = new SpinnersPageSpinnerViewModel(_mountains, 2);
        public SpinnersPageSpinnerViewModel SpinnerVM3
        {
            get => _spinnerVM3;
        }
        */

        
        bool _allowSpin = true;
        public bool AllowSpin
        {
            get => _allowSpin;
            set => RASIC(ref _allowSpin, value);
        }

        
        bool _showButtonSpinner = true;
        public bool ShowButtonSpinner
        {
            get => _showButtonSpinner;
            set => RASIC(ref _showButtonSpinner, value);
        }


        static readonly IList<Location> _spinnerLocations = Enum.GetValues(typeof(Location))
            .Cast<Location>()
            .ToList()
        ;
        public IList<Location> SpinnerLocations
        {
            get => _spinnerLocations;
        }

        Location _selectedSpinnerLocation = Location.Right;
        public Location SelectedSpinnerLocation
        {
            get => _selectedSpinnerLocation;
            set => RASIC(ref _selectedSpinnerLocation, value);
        }
    }

    public class SpinnersPageSpinnerViewModel
        : ViewModelBase
    {
        readonly string[] _values;
        public SpinnersPageSpinnerViewModel(IEnumerable<string> values, int initIndex = 0)
        {
            _values = values.ToArray();
            _spunText = _values[initIndex];
        }

        int _currentIndex = 0;
        public int CurrentIndex
        {
            get => _currentIndex;
            private set => RASIC(ref _currentIndex, value);
        }

        string _spunText;
        public string SpunText
        {
            get => _spunText;
            private set => RASIC(ref _spunText, value);
        }

        public void OnSpin(bool isIncreasing)
        {
            var index = CurrentIndex;
            
            int maxIndex = _values.Length - 1;
            
            if (isIncreasing)
            {
                if (index >= maxIndex)
                    index = 0;
                else
                    index++;
            }
            else
            {
                if (index <= 0)
                    index = maxIndex;
                else
                    index--;
            }
            
            CurrentIndex = index;
            SpunText = _values[index];
        }
    }
}
