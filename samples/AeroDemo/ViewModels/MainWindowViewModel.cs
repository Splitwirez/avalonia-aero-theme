using System;
using System.Collections.Generic;
using System.Text;

namespace AeroDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        PageViewModelBase[] _pages =
        {
            new ButtonsPageViewModel(),
            new BoxesPageViewModel(),
            new SpinnersPageViewModel(),
            new ScrollViewerPageViewModel(),
        };
        public PageViewModelBase[] Pages
        {
            get => _pages;
            set => RASIC(ref _pages, value);
        }
    }
}
