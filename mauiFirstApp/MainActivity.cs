using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Microsoft.Maui.Essentials;

namespace SimpleApp.Droid
{
    [Activity(Label = "SimpleApp", Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .Build()
                .Start(this, savedInstanceState);
        }
    }
}
