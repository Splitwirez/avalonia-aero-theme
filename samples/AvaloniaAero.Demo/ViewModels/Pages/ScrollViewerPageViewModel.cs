using System;

namespace AvaloniaAero.Demo.ViewModels
{
    public class ScrollViewerPageViewModel : PageViewModelBase
    {
        public ScrollViewerPageViewModel()
            : base()
        {
            Title = "ScrollViewer";
        }

        bool _allowScrollbarAutoHide = true;
        public bool AllowScrollbarAutoHide
        {
            get => _allowScrollbarAutoHide;
            set => RASIC(ref _allowScrollbarAutoHide, value);
        }
    }
}
