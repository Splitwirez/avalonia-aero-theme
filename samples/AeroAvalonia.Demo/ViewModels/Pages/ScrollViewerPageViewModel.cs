using System;

namespace AeroAvalonia.Demo.ViewModels
{
    public class ScrollViewerPageViewModel
        : PageViewModelBase
    {
        bool _allowScrollbarAutoHide = true;
        public bool AllowScrollbarAutoHide
        {
            get => _allowScrollbarAutoHide;
            set => RASIC(ref _allowScrollbarAutoHide, value);
        }
    }
}
