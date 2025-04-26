using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaAero.Demo.Navigation;

namespace AvaloniaAero.Demo.ViewModels
{
    public class HomePageViewModel
        : PageViewModelBase
    {
        readonly ObservableCollection<PageViewModelBase> _pages;
        public ObservableCollection<PageViewModelBase> Pages
        {
            get => _pages;
        }


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


        public HomePageViewModel()
            : base("Home")
        {
            _pages = new(CreatePages());

            AeroThemeInfo themeInfo = new(Avalonia.Application.Current.Styles.OfType<AeroTheme>().First());
            TotalControlsToStyleCount = themeInfo.TotalControlsToStyleCount;
            var currentlyStyledControls = themeInfo.CurrentlyStyledControls;

            foreach (var control in currentlyStyledControls)
            {
                StyledThusFar.Add(control);
            }
            StyledThusFarCount = StyledThusFar.Count();
        }

        IEnumerable<PageViewModelBase> CreatePages()
        {
            List<PageViewModelBase> ret = new()
            {
                new ButtonsPageViewModel(),
                new ListBoxPageViewModel(),
                new MenusPageViewModel(),
                new ProgressBarPageViewModel(),
                new ScrollViewerPageViewModel(),
                new SpinnersPageViewModel(),
                new TextBoxPageViewModel(),
                new ToggleSwitchPageViewModel(),
            };

            if (Config.Current.AllowTestPage)
            {
                ret.Add(new TestCaptionButtonsViewModel());
                ret.Add(new TestGradientPageViewModel());
            }

            return ret;
        }


        public void NavigateCommand(object parameter)
        {
            if (parameter is IPage page)
                Navigator?.NavigateTo(page);
        }
    }
}
