using Android.App;
using Android.Content.PM;
using Android.OS;

namespace App5.Droid
{
    [Activity(Label = "App5", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

        }
    }
}