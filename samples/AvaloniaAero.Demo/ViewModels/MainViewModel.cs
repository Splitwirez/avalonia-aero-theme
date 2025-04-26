using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Styling;
using AvaloniaAero.Demo.Navigation;

namespace AvaloniaAero.Demo.ViewModels
{
    public class MainViewModel
        : ViewModelBase
        , INavigator
    {
        List<IPage> _navHistory = new();
        int _navCurrentPos = -1;


        bool GetCanGoBack()
            => _navCurrentPos > 0;

        bool _canGoBack = false;
        public bool CanGoBack
        {
            get => _canGoBack;
            protected set => RASIC(ref _canGoBack, value);
        }


        bool GetCanGoForward()
            => _navCurrentPos < (_navHistory.Count - 1);

        bool _canGoForward = false;
        public bool CanGoForward
        {
            get => _canGoForward;
            protected set => RASIC(ref _canGoForward, value);
        }


        IPage _currentPage = null;
        public IPage CurrentPage
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
            //CurrentPage = Tabs.First();
            NavigateTo(new HomePageViewModel());
        }




        public void GoBack()
        {
            if (!GetCanGoBack())
                return;

            _navCurrentPos--;
            CurrentPage = _navHistory[_navCurrentPos];
            AfterNavigate();
        }


        public void GoForward()
        {
            NavigateToNext();
            AfterNavigate();
        }


        public void NavigateTo(IPage page)
        {
            page.Navigator = this;


            var navNewPos = _navCurrentPos + 1;
            _navHistory.Insert(navNewPos, page);
            NavigateToNext();


            int navDesiredCount = _navCurrentPos + 1;
            while (_navHistory.Count > navDesiredCount)
            {
                _navHistory.RemoveAt(_navHistory.Count - 1);
            }
            /*
            int navActualCount = _navHistory.Count;
            if (navActualCount > navDesiredCount)
            {
                for (int i = navDesiredCount; i < navActualCount; i++)
                {
                    _navHistory.RemoveAt(navDesiredCount);
                }
                //_navHistory = new(_navHistory.Take(navDesiredCount));
            }
            */
            //CurrentPage = page;
            AfterNavigate();
        }


        void NavigateToNext()
        {
            if (!GetCanGoForward())
                return;

            _navCurrentPos++;
            CurrentPage = _navHistory[_navCurrentPos];
        }


        void AfterNavigate()
        {
            CanGoBack = GetCanGoBack();
            CanGoForward = GetCanGoForward();
        }
    }
}
