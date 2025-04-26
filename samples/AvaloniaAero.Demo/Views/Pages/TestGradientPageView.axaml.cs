using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using AvaloniaAero.Demo.ViewModels;

namespace AvaloniaAero.Demo.Views
{
    public partial class TestGradientPageView
        : UserControl
    {
        public TestGradientPageViewModel VM
        {
            get => (TestGradientPageViewModel)DataContext;
        }
        Window _gradientTestWindow = null;


        public TestGradientPageView()
        {
            InitializeComponent();
        }

        void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            if (_gradientTestWindow != null)
                return;


            if (Resources.TryGetValue("GradientTestWindow", out object gradientTestWin) && gradientTestWin is Window gradientTestWindow)
                _gradientTestWindow = gradientTestWindow;
            else
                throw new Exception("AAAAA"); //_gradientTestWindow = new();

            /*
            _gradientTestWindow.Bind(BackgroundProperty,
                new Binding()
                {
                    Source = VM,
                    Path = nameof(VM.GeneratedBrush),
                    Mode = BindingMode.OneWay,
                }
            );
            */

            _gradientTestWindow.Width = 100;
            _gradientTestWindow.Height = 30;


            Dispatcher.UIThread.Post(() =>
            {
                _gradientTestWindow.Show();
                _gradientTestWindow.Closing += GradientTestWindow_Closing;
                //VM.PropertyChanged += VM_PropertyChanged;
            });
            if (TopLevel.GetTopLevel(this) is Window parentWindow)
                parentWindow.Closed += ParentWindow_Closed;
        }

        void ParentWindow_Closed(object sender, EventArgs e)
        {
            (sender as Window).Closed -= ParentWindow_Closed;
            if (_gradientTestWindow == null)
                return;

            _gradientTestWindow.Closing -= GradientTestWindow_Closing;
            _gradientTestWindow.Close();
        }

        void GradientTestWindow_Closing(object sender, WindowClosingEventArgs e)
        {
            e.Cancel = true;
            _gradientTestWindow.Hide();
        }

        void VM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}
