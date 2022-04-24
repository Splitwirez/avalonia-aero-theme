using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AeroDemo.Views
{
    public class SpinnersPageView : UserControl
    {
        public SpinnersPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
