using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaAero.Demo.ViewModels;

namespace AvaloniaAero.Demo.Views
{
    public partial class SpinnersPageView : UserControl
    {
        public SpinnersPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        void Spinner_Spin(object sender, SpinEventArgs e)
        {
            if (!(sender is ButtonSpinner spinner))
                return;
            
            var dctx = spinner.DataContext;
            if (dctx == null)
                return;
            
            
            if (dctx is SpinnersPageSpinnerViewModel vm)
            {
                vm.OnSpin(e.Direction == SpinDirection.Increase);
            }
        }
    }
}
