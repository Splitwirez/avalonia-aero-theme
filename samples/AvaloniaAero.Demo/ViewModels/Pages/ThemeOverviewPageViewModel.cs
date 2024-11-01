using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaAero.Demo.ViewModels
{
    public class ThemeOverviewPageViewModel
        : PageViewModelBase
    {
        double _totalControlsToStyleCount = -1;
        public double TotalControlsToStyleCount
        {
            get => _totalControlsToStyleCount;
            protected set => RASIC(ref _totalControlsToStyleCount, value);
        }


        readonly ObservableCollection<string> _styledThusFar = new();
        public ObservableCollection<string> StyledThusFar
        {
            get => _styledThusFar;
        }


        double _styledThusFarCount = -1;
        public double StyledThusFarCount
        {
            get => _styledThusFarCount;
            protected set => RASIC(ref _styledThusFarCount, value);
        }


        public ThemeOverviewPageViewModel()
            : base("Overview")
        {
            AeroThemeInfo themeInfo = new(Avalonia.Application.Current.Styles.OfType<AeroTheme>().First());
            TotalControlsToStyleCount = themeInfo.TotalControlsToStyleCount;
            var currentlyStyledControls = themeInfo.CurrentlyStyledControls;

            foreach (var control in currentlyStyledControls)
            {
                StyledThusFar.Add(control);
            }
            StyledThusFarCount = StyledThusFar.Count();
        }
    }
}
