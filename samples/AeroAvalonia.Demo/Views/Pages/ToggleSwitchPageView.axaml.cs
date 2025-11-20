using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AeroAvalonia.Demo.Views
{
    public partial class ToggleSwitchPageView
        : UserControl
    {
        public ToggleSwitchPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
