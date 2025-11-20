using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AeroAvalonia.Demo.Views
{
    public partial class ScrollViewerPageView
        : UserControl
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
