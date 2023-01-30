using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using AvaloniaAero;
using AvaloniaAero.Demo;

namespace AvaloniaAero.Demo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        ObservableCollection<PageViewModelBase> _pages = new ObservableCollection<PageViewModelBase>()
        {
            new ButtonsPageViewModel(),
            new ToggleSwitchPageViewModel(),
            new ScrollViewerPageViewModel(),
            new BoxesPageViewModel(),
            new SpinnersPageViewModel(),
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

        bool _areLightsOn = true;
        
        public bool AreLightsOn
        {
            get => _areLightsOn;
            set
            {
                bool prev = _areLightsOn;
                RASIC(ref _areLightsOn, value);
                if (_areLightsOn != prev)
                {
                    var theme = App.Current.Styles.OfType<AeroTheme>().FirstOrDefault();
                    theme.Variant = _areLightsOn ? AeroVariant.Light : AeroVariant.Dark;
                    int index = App.Current.Styles.IndexOf(theme);
                    App.Current.Styles.Remove(theme);
                    App.Current.Styles.Insert(index, theme);
                    
                    /*var theme = App.Current.Styles.OfType<AeroTheme>().FirstOrDefault();
                    int index = App.Current.Styles.IndexOf(theme);
                    App.Current.Styles.Remove(theme);
                    //theme.Mode = _areLightsOn ? AeroThemeMode.Light : AeroThemeMode.Dark;
                    //App.Current.Styles.Insert(index, theme);
                    var newTheme = new AeroTheme((Uri)null);
                    newTheme.Mode = _areLightsOn ? AeroThemeMode.Light : AeroThemeMode.Dark;
                    App.Current.Styles.Insert(index, newTheme);*/
                }
            }
        }

        public MainViewModel()
        {
            CurrentPage = Pages.First();
        }
    }
}
