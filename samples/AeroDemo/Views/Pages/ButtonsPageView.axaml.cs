using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AeroDemo.Views
{
    public class ButtonsPageView : UserControl
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
