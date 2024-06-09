using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Styling;

namespace AvaloniaAero.Demo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        ObservableCollection<PageViewModelBase> _pages = new ObservableCollection<PageViewModelBase>()
        {
            new ButtonsPageViewModel(),
            //new ListBoxPageViewModel(),
            new ScrollViewerPageViewModel(),
            new TextBoxPageViewModel(),
            new ToggleSwitchPageViewModel(),
            //new SpinnersPageViewModel(),
            //new TestPageViewModel(),
        };
        public ObservableCollection<PageViewModelBase> Pages
        {
            get => _pages;
            protected set => RASIC(ref _pages, value);
        }


        PageViewModelBase _currentPage = null;
        public PageViewModelBase CurrentPage
        {
            get => _currentPage;
            set => RASIC(ref _currentPage, value);
        }

        
        bool _areLightsOn = Application.Current.RequestedThemeVariant != ThemeVariant.Dark;
        public bool AreLightsOn
        {
            get => _areLightsOn;
            set
            {
                bool prev = _areLightsOn;
                RASIC(ref _areLightsOn, value);
                if (_areLightsOn != prev)
                {
                    Application.Current.RequestedThemeVariant = _areLightsOn
                        ? ThemeVariant.Light
                        : ThemeVariant.Dark
                    ;
                }
            }
        }

        public MainViewModel()
        {
            CurrentPage = Pages.First();
        }
    }
}
