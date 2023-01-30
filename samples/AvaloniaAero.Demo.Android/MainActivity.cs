using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;

namespace AvaloniaAero.Demo
{
    [Activity(Label = "AvaloniaAero.Demo", Theme = "@style/AvaloniaAeroDemo.NoActionBar", Icon = "@drawable/AppIcon", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = (ConfigChanges.Orientation | ConfigChanges.ScreenSize))]
    public class MainActivity : AvaloniaMainActivity
    {
		
    }
}
