using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Database;
using Android.OS;
using Android.Provider;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using CommunityToolkit.Mvvm.Messaging;
using Ajour.EditorLib;
using Ajour.EditorLib.Models;

namespace Reporter
{
	[Activity(
        MainLauncher = false,
        LaunchMode = LaunchMode.SingleTop,
        AllowTaskReparenting = true,
        AutoRemoveFromRecents = true,
        Exported = true,
 		ExcludeFromRecents = true,
		NoHistory = true
	   )
	]
   [IntentFilter(
		new string[] { Intent.ActionView },
		Categories = new[] { Intent.CategoryDefault },
		DataSchemes = new[] { "content" },
		DataMimeTypes = new[] { "text/rtf", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
		Icon = "@mipmap/appicon",
		AutoVerify = true
		)
	]
    public class FileLauncherActivity : AppCompatActivity
    {
        protected override async void OnCreate(Bundle? savedInstanceState)
        {
			base.OnCreate(savedInstanceState);

			if (Intent.Action != Intent.ActionView)
				return;

			Android.Net.Uri uri = Intent.Data;
			if (uri == null)
				return;

			if (!uri.Scheme.Equals("content"))
				return;

			byte[] fileData = null;
			using (Stream inputStream = ContentResolver.OpenInputStream(uri))
			{
				using (var outputStream = new MemoryStream())
				{
					inputStream.CopyTo(outputStream);
					fileData = outputStream.ToArray();
				}
			}

			string? filename = null;
			DateTime created = DateTime.MinValue;
			DateTime modified = DateTime.MinValue;
			string[] projection =
			{
					MediaStore.IMediaColumns.DisplayName,
					MediaStore.IMediaColumns.DateTaken,
					MediaStore.IMediaColumns.DateModified
				};
			using (ICursor metaCursor = ContentResolver.Query(uri, projection, null, null, null))
			{
				if (metaCursor != null && metaCursor.MoveToFirst())
				{
					filename = metaCursor.GetString(0);
					created = DateTimeOffset.FromUnixTimeSeconds(metaCursor.GetLong(1) / 1000).DateTime;
					modified = DateTimeOffset.FromUnixTimeSeconds(metaCursor.GetLong(2) / 1000).DateTime;
				}
			}

			FileObj fileobj = new FileObj(
				filename!,
				fileData.Length,
				created,
				modified,
				uri.ToString());

			Context context = Platform.AppContext;
			PackageManager packageManager = context.PackageManager;
            Intent? MainLauncher_intent = packageManager.GetLaunchIntentForPackage(PackageName);

			// bring hosting app to foreground
			context.StartActivity(MainLauncher_intent);
			Finish();

			// If not already running.., then wait for Editor to be loaded.
			while (!AjourEditor.IsStarted)
				await Task.Delay(500);
			AppBuilder.FileLauncher = true;
			WeakReferenceMessenger.Default.Send(new NotificationModel("FileLauncher", fileData, fileobj));
		}
	}
}

