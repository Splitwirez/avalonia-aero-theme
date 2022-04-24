using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.Styling;
using System;
using System.Diagnostics;
using System.Linq;

namespace Avalonia.Themes.Aero.NormalColor.Sample
{
    public class MainWindow : Window
    {
        /*public bool? AreLightsOn
        {
            get => GetValue(AreLightsOnProperty);
            set => SetValue(AreLightsOnProperty, value);
        }


        public static readonly StyledProperty<bool?> AreLightsOnProperty = AvaloniaProperty.Register<MainWindow, bool?>(nameof(AreLightsOn), true);



        static MainWindow()
        {
            AreLightsOnProperty.Changed.Subscribe(AreLightsOnChanged);
        }*/

        public MainWindow()
        {
            InitializeComponent();
/*#if DEBUG
            this.AttachDevTools();
#endif*/
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.Find<CheckBox>("LightsOnCheckBox").Click += LightsOnCheckBox_Click;
        }

        private void LightsOnCheckBox_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Debug.WriteLine("LightsOnCheckBox_Click");
            
            string includeString = "avares://Avalonia.Themes.Aero.NormalColor/Accents/BaseLight.xaml";
            if (!((sender as CheckBox).IsChecked.Value))
                includeString = "avares://Avalonia.Themes.Aero.NormalColor/Accents/BaseDark.xaml";

            App.Current.Resources.MergedDictionaries[0] = new ResourceInclude()
            {
                Source = new Uri(includeString)
            };
        }

        /*private static void AreLightsOnChanged(AvaloniaPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool?)
            {
                
            }
        }*/
    }
}
