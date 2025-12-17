using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TestAjourEditor
{
	[Activity(Theme = "@style/Maui.SplashTheme",
		MainLauncher = true,
		LaunchMode = LaunchMode.SingleTask,
		Exported = true,
		ScreenOrientation = ScreenOrientation.Sensor,
		ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.UiMode | ConfigChanges.KeyboardHidden | ConfigChanges.Density)
	]
	public class MainActivity : MauiAppCompatActivity
    {
    }
}
