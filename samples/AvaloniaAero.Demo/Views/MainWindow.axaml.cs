using System;
using System.Numerics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaAero.Demo.Views
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
            
            /*
            double w = Math.Max(MinWidth, ctrl.MinWidth);
            Width = w;
            double h = Math.Max(MinHeight, ctrl.MinHeight);
            Height = h;
            */
        }

        public MainWindow()
            : base()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
