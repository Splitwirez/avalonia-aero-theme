using Android.App;
//using Android.Content;
using Android.Content.PM;
//using Android.OS;
using Avalonia;
using Avalonia.Android;

namespace AeroAvalonia.Demo
{
    /*[Activity(Theme = "@style/AeroAvaloniaDemo.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AvaloniaSplashActivity<App>*/

    //[Activity(Label = "AeroAvalonia.Demo", Theme = "@style/AeroAvaloniaDemo.NoActionBar", Icon = "@drawable/AppIcon", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = (ConfigChanges.Orientation | ConfigChanges.ScreenSize))]
    //[Activity(Label = "AeroAvalonia.Demo", Theme = "@style/AeroAvaloniaDemo.NoActionBar", Icon = "@drawable/AppIcon", MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    [Activity(Label = "AeroAvalonia.Demo", Theme = "@style/AeroAvaloniaDemo.Splash", Icon = "@drawable/AppIcon", MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    public class MainActivity : AvaloniaMainActivity<App>
    {
        /*protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
			=> base.CustomizeAppBuilder(builder)
				.With(new AndroidPlatformOptions()
                {
                    UseDeferredRendering = true //DEFAULT: false
					//UseGpu
					//UseCompositor
                })
			;*/
        /*protected override void OnCreate(Bundle? savedInstanceState)
			=> base.OnCreate(savedInstanceState);
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }*/
    }
}
