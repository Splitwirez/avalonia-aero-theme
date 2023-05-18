using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Chrome;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Rendering;
using Avalonia.VisualTree;
//using static VTVExtensions = Avalonia.VisualTree.VisualExtensions;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
//using Avalonia.Reactive;
using System.Reflection;

namespace AvaloniaAero.Demo.Views
{
    public partial class TestPageView : UserControl
    {
        CaptionButtons _testCaptionButtons = null;
        TitleBar _testTitleBar = null;

        public TestPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
            _testCaptionButtons = this.Find<CaptionButtons>("TestCaptionButtons");


            
            _testTitleBar = this.Find<TitleBar>("TestTitleBar");
            Console.WriteLine($"_testTitleBar: {_testTitleBar != null}");
            
            
            //Attempt();
            Attempt2();
        }

        void Attempt2()
        {
            var window = GetRootWindow();
            _testTitleBar[!HeightProperty] = _testCaptionButtons.GetObservable(CaptionButtons.BoundsProperty).Select(x => x.Height).ToBinding();
            /*_testTitleBar.AttachedToVisualTree += (s, e) =>
            {
                var cb = _testTitleBar.FindDescendantOfType<CaptionButtons>(false);
                cb.Attach(GetRootWindow());
            };*/
        }


        void Attempt()
        {
            var vRoot = GetRootWindow();
            Console.WriteLine($"vRoot: {vRoot != null}");
            var dtaArgs = new VisualTreeAttachmentEventArgs(_testTitleBar, (IRenderRoot)vRoot);
            MethodInfo dtaFunc = typeof(TitleBar).GetMethod("OnDetachedFromVisualTree", BindingFlags.Instance | BindingFlags.NonPublic);
            /*_testTitleBar.AttachedToVisualTree += (s, e) =>
            {
                dtaFunc.Invoke(_testTitleBar, new object[]
                {
                    dtaArgs
                });
            };*/
            //detachedFunc.I
            
            
            /*var titleBarDisposableField = typeof(TitleBar).GetField("_disposables", BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine($"titleBarDisposableField: {titleBarDisposableField != null}");
            
            _testTitleBar.AttachedToLogicalTree += (s, e) =>
            {
                var testValue = titleBarDisposableField.GetValue(_testTitleBar);
                Console.WriteLine($"testValue: {testValue != null}");
                CompositeDisposable titleBarDisposables = (CompositeDisposable)testValue;
                titleBarDisposables.Dispose();
                _testTitleBar.IsVisible = true;  
            };*/
            
            //titleBarDisposables.SetValue(_testTitleBar, )
            //_testTitleBar.PropertyChanged
            //.AddHandler()
            //typeof(TitleBar).GetMethod("UpdateSize", BindingFlags.Instance | BindingFlags.NonPublic)
            //_testTitleBar.AddHandler
            //_testTitleBar.IsVisible = true;
        }

        Window GetRootWindow()
            => (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow; //Avalonia.VisualTree.VisualExtensions.GetVisualRoot(this); // as Window
    }
}
