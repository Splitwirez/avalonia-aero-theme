using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AeroDemo.Views
{
    public class ScrollViewerPageView : UserControl
    {
        public ScrollViewerPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
