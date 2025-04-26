using System;

namespace AvaloniaAero.Demo.Navigation
{
    public interface IPage
    {
        INavigator Navigator
        {
            get;
            set;
        }
    }
}
