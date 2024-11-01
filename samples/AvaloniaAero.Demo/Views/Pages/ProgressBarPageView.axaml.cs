using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaAero.Demo.ViewModels;

namespace AvaloniaAero.Demo.Views
{
    public partial class ProgressBarPageView
        : UserControl
    {
        public ProgressBarPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
