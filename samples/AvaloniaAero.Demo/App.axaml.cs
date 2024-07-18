using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Platform;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using AvaloniaAero.Demo.ViewModels;
using AvaloniaAero.Demo.Views;
using System;

namespace AvaloniaAero.Demo
{
    public class App
        : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var mainView = new MainView()
            {
                DataContext = new MainViewModel()
            };

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow(mainView);
                /*
                new Window()
                {
                    Content = mainView,
                    [!DataContextProperty] = mainView[!DataContextProperty],
                };
                */
            }
			else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewLifetime)
			{
				singleViewLifetime.MainView = mainView;
			}
            
            

            base.OnFrameworkInitializationCompleted();
        }
    }
}
