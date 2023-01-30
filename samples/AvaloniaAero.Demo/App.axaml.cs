using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Platform;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using AvaloniaAero.Demo.ViewModels;
using AvaloniaAero.Demo.Views;
using Moq;
using System;
using System.Reflection;

namespace AvaloniaAero.Demo
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var mainVM = new MainViewModel();
            var mainView = new MainView()
            {
                DataContext = mainVM
            };
            /*MainWindow mainWindow = //null;
            new MainWindow() //CreateWindowImpl(ApplicationLifetime))
            {
                DataContext = mainVM,
            };*/
            
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                /*mainWindow = new MainWindow();
                OnFrameworkInitializationCompletedCommon(ref mainWindow, ref mainVM);*/
                //desktop.MainWindow = mainWindow;
                desktop.MainWindow = mainView.CreateWindow();
            }
			else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewLifetime)
			{
                /*mainWindow = new MainWindow();
                OnFrameworkInitializationCompletedCommon(ref mainWindow, ref mainVM);*/
                /*var winPlatformImpl = typeof(TopLevel).GetField("PlatformImpl");
                winPlatformImpl.SetValue(mainWindow, new Moq(IWindowImpl));*/
				singleViewLifetime.MainView = mainView;
			}

            base.OnFrameworkInitializationCompleted();
        }

        /*void OnFrameworkInitializationCompletedCommon(ref Window window, ref ViewModelBase vm)
        {
            window.DataContext = vm;
        }

        void OnFrameworkInitializationCompletedForDesktop(IClassicDesktopStyleApplicationLifetime lifetime)
        {

        }

        void OnFrameworkInitializationCompletedForSingleView(ISingleViewApplicationLifetime lifetime)
        {
            
        }*/

        /*static IWindowImpl CreateWindowImpl(IApplicationLifetime lifetime)
        {
            if (lifetime is IClassicDesktopStyleApplicationLifetime desktop)
                return PlatformManager.CreateWindow();
			else //if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewLifetime)
                return new Mock<IWindowImpl>().Object;
        }*/
    }
}
