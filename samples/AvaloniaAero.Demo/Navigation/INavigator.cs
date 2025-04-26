using System;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace AvaloniaAero.Demo.Navigation
{
    public interface INavigator
    {
        IPage CurrentPage
        {
            get;
        }


        void NavigateTo(IPage page);
    }
}
