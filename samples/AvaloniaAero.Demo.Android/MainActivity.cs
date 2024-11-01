using Android.App;
//using Android.Content;
using Android.Content.PM;
//using Android.OS;
using Avalonia;
using Avalonia.Android;

namespace AvaloniaAero.Demo
{
    /*[Activity(Theme = "@style/AvaloniaAeroDemo.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AvaloniaSplashActivity<App>*/

    //[Activity(Label = "AvaloniaAero.Demo", Theme = "@style/AvaloniaAeroDemo.NoActionBar", Icon = "@drawable/AppIcon", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = (ConfigChanges.Orientation | ConfigChanges.ScreenSize))]
    //[Activity(Label = "AvaloniaAero.Demo", Theme = "@style/AvaloniaAeroDemo.NoActionBar", Icon = "@drawable/AppIcon", MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    [Activity(Label = "AvaloniaAero.Demo", Theme = "@style/AvaloniaAeroDemo.Splash", Icon = "@drawable/AppIcon", MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
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
