using System;

namespace AvaloniaAero.Demo.ViewModels
{
    public class ButtonsPageViewModel : PageViewModelBase
    {
        public ButtonsPageViewModel()
            : base()
        {
            Title = "Buttons";
        }

        int _radioButtonIndex = 0;
        public int RadioButtonIndex
        {
            get => _radioButtonIndex;
            set => RASIC(ref _radioButtonIndex, value);
        }
    }
}
