using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Styling;

namespace AvaloniaAero.Demo.ViewModels
{
    public class MainViewModel
        : TabsViewModelBase
    {
        public ObservableCollection<ViewModelBase> Pages
        {
            get => Tabs;
            protected set
            {
                var _pages = Tabs;
                RASIC(ref _pages, value);
            }
        }
        protected override ObservableCollection<ViewModelBase> CreateTabs()
        {
            ObservableCollection<ViewModelBase> tabs = new()
            {
                new ThemeOverviewPageViewModel(),
                new ButtonsPageViewModel(),
                //new ListBoxPageViewModel(),
                new MenusPageViewModel(),
                new ProgressBarPageViewModel(),
                new ScrollViewerPageViewModel(),
                new SpinnersPageViewModel(),
                new TextBoxPageViewModel(),
                new ToggleSwitchPageViewModel(),
            };


            if (Config.Current.AllowTestPage)
            {
                tabs.Add(new TestCaptionButtonsViewModel());
                tabs.Add(new TestGradientPageViewModel());
            }

            return tabs;
        }


        ViewModelBase _currentPage = null;
        public ViewModelBase CurrentPage
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
            CurrentPage = Tabs.First();
        }
    }
}
