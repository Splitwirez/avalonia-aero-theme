using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaAero.Demo.Views
{
    public partial class ProgressBarPageView
        : UserControl
    {
        public ProgressBarPageView()
        {
            InitializeComponent();
            //var a = new ProgressBar.ProgressBarTemplateSettings();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
