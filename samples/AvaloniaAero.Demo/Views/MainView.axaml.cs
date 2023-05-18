using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Platform;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaAero.Demo.Views
{
    public partial class MainView : UserControl
    {
        public static readonly StyledProperty<SizeToContent> SizeToContentProperty =
            Window.SizeToContentProperty.AddOwner<MainView>();

        public static readonly StyledProperty<bool> ExtendClientAreaToDecorationsHintProperty =
            Window.ExtendClientAreaToDecorationsHintProperty.AddOwner<MainView>();

        public static readonly StyledProperty<ExtendClientAreaChromeHints> ExtendClientAreaChromeHintsProperty =
            Window.ExtendClientAreaChromeHintsProperty.AddOwner<MainView>();

        public static readonly StyledProperty<double> ExtendClientAreaTitleBarHeightHintProperty =
            Window.ExtendClientAreaTitleBarHeightHintProperty.AddOwner<MainView>();
        
        public static readonly StyledProperty<SystemDecorations> SystemDecorationsProperty =
            Window.SystemDecorationsProperty.AddOwner<MainView>();

        public static readonly StyledProperty<bool> ShowActivatedProperty =
            Window.ShowActivatedProperty.AddOwner<MainView>();

        public static readonly StyledProperty<bool> ShowInTaskbarProperty =
            Window.ShowInTaskbarProperty.AddOwner<MainView>();

        public static readonly StyledProperty<WindowState> WindowStateProperty =
            Window.WindowStateProperty.AddOwner<MainView>();

        public static readonly StyledProperty<string?> TitleProperty =
            Window.TitleProperty.AddOwner<MainView>();

        public static readonly StyledProperty<WindowIcon?> IconProperty =
            Window.IconProperty.AddOwner<MainView>();

        public static readonly StyledProperty<WindowStartupLocation> WindowStartupLocationProperty =
            Window.WindowStartupLocationProperty.AddOwner<MainView>();
        public static readonly StyledProperty<bool> CanResizeProperty =
            Window.CanResizeProperty.AddOwner<MainView>();
        public SizeToContent SizeToContent
        {
            get => GetValue(SizeToContentProperty);
            set => SetValue(SizeToContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the title of the window.
        /// </summary>
        public string? Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// Gets or sets if the ClientArea is Extended into the Window Decorations (chrome or border).
        /// </summary>
        public bool ExtendClientAreaToDecorationsHint
        {
            get => GetValue(ExtendClientAreaToDecorationsHintProperty);
            set => SetValue(ExtendClientAreaToDecorationsHintProperty, value);
        }

        /// <summary>
        /// Gets or Sets the <see cref="Avalonia.Platform.ExtendClientAreaChromeHints"/> that control
        /// how the chrome looks when the client area is extended.
        /// </summary>
        public ExtendClientAreaChromeHints ExtendClientAreaChromeHints
        {
            get => GetValue(ExtendClientAreaChromeHintsProperty);
            set => SetValue(ExtendClientAreaChromeHintsProperty, value);
        }

        /// <summary>
        /// Gets or Sets the TitlebarHeightHint for when the client area is extended.
        /// A value of -1 will cause the titlebar to be auto sized to the OS default.
        /// Any other positive value will cause the titlebar to assume that height.
        /// </summary>
        public double ExtendClientAreaTitleBarHeightHint
        {
            get => GetValue(ExtendClientAreaTitleBarHeightHintProperty);
            set => SetValue(ExtendClientAreaTitleBarHeightHintProperty, value);
        }

        /// <summary>
        /// Sets the system decorations (title bar, border, etc)
        /// </summary>
        public SystemDecorations SystemDecorations
        {
            get => GetValue(SystemDecorationsProperty);
            set => SetValue(SystemDecorationsProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that indicates whether a window is activated when first shown. 
        /// </summary>
        public bool ShowActivated
        {
            get => GetValue(ShowActivatedProperty);
            set => SetValue(ShowActivatedProperty, value);
        }

        /// <summary>
        /// Enables or disables the taskbar icon
        /// </summary>
        /// 
        public bool ShowInTaskbar
        {
            get => GetValue(ShowInTaskbarProperty);
            set => SetValue(ShowInTaskbarProperty, value);
        }

        /// <summary>
        /// Gets or sets the minimized/maximized state of the window.
        /// </summary>
        public WindowState WindowState
        {
            get => GetValue(WindowStateProperty);
            set => SetValue(WindowStateProperty, value);
        }

        /// <summary>
        /// Enables or disables resizing of the window.
        /// </summary>
        public bool CanResize
        {
            get => GetValue(CanResizeProperty);
            set => SetValue(CanResizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the icon of the window.
        /// </summary>
        public WindowIcon? Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public WindowStartupLocation WindowStartupLocation
        {
            get => GetValue(WindowStartupLocationProperty);
            set => SetValue(WindowStartupLocationProperty, value);
        }


        public static readonly StyledProperty<double> WindowWidthProperty =
            AvaloniaProperty.Register<MainView, double>(nameof(WindowWidth));
        public double WindowWidth
        {
            get => GetValue(WindowWidthProperty);
            set => SetValue(WindowWidthProperty, value);
        }

        public static readonly StyledProperty<double> WindowHeightProperty =
            AvaloniaProperty.Register<MainView, double>(nameof(WindowHeight));
        public double WindowHeight
        {
            get => GetValue(WindowHeightProperty);
            set => SetValue(WindowHeightProperty, value);
        }

        public MainView()
            /*: this(PlatformManager.CreateWindow())
        {
        }

        public MainWindow(IWindowImpl impl)
            : base(impl)*/
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public Window CreateWindow()
        {
            Window win = new Window()
            {
                Content = this,
                [!Window.DataContextProperty] = this[!UserControl.DataContextProperty],
                [!Window.SizeToContentProperty] = this[!MainView.SizeToContentProperty],
                [!Window.ExtendClientAreaToDecorationsHintProperty] = this[!MainView.ExtendClientAreaToDecorationsHintProperty],
                [!Window.ExtendClientAreaChromeHintsProperty] = this[!MainView.ExtendClientAreaChromeHintsProperty],
                [!Window.ExtendClientAreaTitleBarHeightHintProperty] = this[!MainView.ExtendClientAreaTitleBarHeightHintProperty],
                [!Window.SystemDecorationsProperty] = this[!MainView.SystemDecorationsProperty],
                [!Window.ShowActivatedProperty] = this[!MainView.ShowActivatedProperty],
                [!Window.ShowInTaskbarProperty] = this[!MainView.ShowInTaskbarProperty],
                [!Window.WindowStateProperty] = this[!MainView.WindowStateProperty],
                [!Window.TitleProperty] = this[!MainView.TitleProperty],
                [!Window.IconProperty] = this[!MainView.IconProperty],
                [!Window.WindowStartupLocationProperty] = this[!MainView.WindowStartupLocationProperty],
                [!Window.CanResizeProperty] = this[!MainView.CanResizeProperty],
                [!Window.WidthProperty] = this[!MainView.WindowWidthProperty],
                [!Window.HeightProperty] = this[!MainView.WindowHeightProperty],
            };
            /*win.Width = WindowWidth;
            win.Height  = WindowHeight;
            win[!Window.WidthProperty] = this[!MainView.WindowWidthProperty];
            win[!Window.HeightProperty] = this[!MainView.WindowHeightProperty];*/
#if DEBUG
            win.AttachDevTools();
#endif
            
            /*
            dumb hack so I don't have to break my neck until the fix for
            https://github.com/AvaloniaUI/Avalonia/issues/9286
            arrives in a preview or whatever
            */
            if (Environment.GetCommandLineArgs().Any(x => x == "--temp-monitor-hack"))
            {
                win.Initialized += Window_Initialized;
            }
            return win;
        }

        const int _WINDOW_HACK_INSET_EXTENT = 10; //15;
        static readonly PixelPoint _WINDOW_HACK_INSET = new PixelPoint(_WINDOW_HACK_INSET_EXTENT, _WINDOW_HACK_INSET_EXTENT);
        void Window_Initialized(object sender, EventArgs e)
        {
            if (!(sender is Window win))
                return;

            Dispatcher.UIThread.Post(() =>
            {
                var leastTall = win.Screens.All.MinBy(x => x.Bounds.Height);
                win.Position = leastTall.Bounds.TopLeft + _WINDOW_HACK_INSET;
            });
            win.Initialized -= Window_Initialized;
        }
    }

    //https://stackoverflow.com/a/914198
    //https://github.com/morelinq/MoreLINQ
    //thanks lol
    public static class MoreLINQExtracts
    {
        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MinBy(selector, null);
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");
            comparer ??= Comparer<TKey>.Default;

            using (var sourceIterator = source.GetEnumerator())
            {
                if (!sourceIterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                var min = sourceIterator.Current;
                var minKey = selector(min);
                while (sourceIterator.MoveNext())
                {
                    var candidate = sourceIterator.Current;
                    var candidateProjected = selector(candidate);
                    if (comparer.Compare(candidateProjected, minKey) < 0)
                    {
                        min = candidate;
                        minKey = candidateProjected;
                    }
                }
                return min;
            }
        }
    }
}
