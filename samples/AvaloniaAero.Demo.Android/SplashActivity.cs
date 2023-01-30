using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AppBuilder = Avalonia.AppBuilder;
using Avalonia.Android;

namespace AvaloniaAero.Demo
{
    [Activity(Theme = "@style/AvaloniaAeroDemo.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AvaloniaSplashActivity<App>
    {
        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
			=> base.CustomizeAppBuilder(builder)
				.With(new AndroidPlatformOptions()
                {
                    UseDeferredRendering = true //DEFAULT: false
					//UseGpu
					//UseCompositor
                })
			;
        protected override void OnCreate(Bundle? savedInstanceState)
			=> base.OnCreate(savedInstanceState);
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}
