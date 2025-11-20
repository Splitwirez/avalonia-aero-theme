using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AeroAvalonia.Demo.Views
{
    public partial class ButtonsPageView
        : UserControl
    {
        public ButtonsPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
