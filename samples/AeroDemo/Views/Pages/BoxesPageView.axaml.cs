using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AeroDemo.Views
{
    public class BoxesPageView : UserControl
    {
        public BoxesPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
