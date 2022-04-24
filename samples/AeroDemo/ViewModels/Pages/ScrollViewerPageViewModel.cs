using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace AeroDemo.ViewModels
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
