using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace AvaloniaAero.Demo.ViewModels
{
    public class PageViewModelBase : ViewModelBase
    {
        string _title = null;
        public string Title
        {
            get => _title;
            set => RASIC(ref _title, value);
        }
    }
}
