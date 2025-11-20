using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AeroAvalonia.Demo.Views
{
    public partial class MainWindow
        : Window
    {
        public MainWindow(Control ctrl)
            : this()
        {
            if (ctrl == null)
                return;
            
            Content = ctrl;
        }

        public MainWindow()
            : base()
        {
            InitializeComponent();
#if DEBUG
            Title += $" (dotnet {Environment.Version})";
            this.AttachDevTools();
#endif
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
