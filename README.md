# ![Ajour Media](logo64.png) Maui Cross platform Editor-library<br/>for HTML, XML and RTF.

## Editorial tool to produce articles and reportage for use in newspapers, online newspapers, TV or radio.


### PROJECT: TESTE **AJOUR EDITOR Library**
1. Create a new MAUI Application
2. Add Nuget package [Ajour.EditorLib.1.4.xx.nupkg]()<br/>
2a. copy to your offline packages folder, then add to your project.
3. Open **MauiProgram.cs**<br/>
3a. Add [using Ajour.EditorLib;]()<br/>
3b. Add [builder.UseAjourEditor();]()
4. Open **MainPage.xaml**<br/>
4a. Add [xmlns:ajourlib="clr-namespace:Ajour.EditorLib;assembly=Ajour.EditorLib"]()<br/>
4b. Replace sample content with [<ajourlib:AjourEditor />]()
5. Open **MainPage.xaml.cs**<br/>
5.a remove sample source
6. Build and run

### TODO:[^1]
- [x] Skriv noe tekst og klikk på **B**, **I** eller **U** (v1.4.21)
- [x] Klikk på Åpne **testfil2 med bilder.html** (v1.4.30)

```cs
using Microsoft.Extensions.Logging;
using Ajour.EditorLib;
namespace TestAjourEditor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				.UseAjourEditor();

            #if DEBUG
			builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }
    }
}
```

```cs
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="TestAjourEditor.MainPage"
			 xmlns:ajourlib="clr-namespace:Ajour.EditorLib;assembly=Ajour.EditorLib"
			 >
	<!-- Editor -->
	<ajourlib:AjourEditor />
</ContentPage>
```


```cs
Android Required:

C#
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadMediaAudio)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadMediaImages)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadMediaVideo)]

XML
<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" android:maxSdkVersion="32" />
<!-- Required only if your app needs to access images or photos that other apps created -->
<uses-permission android:name="android.permission.READ_MEDIA_IMAGES" />
<!-- Required only if your app needs to access videos that other apps created -->
<uses-permission android:name="android.permission.READ_MEDIA_VIDEO" />
<!-- Required only if your app needs to access audio files that other apps created -->
<uses-permission android:name="android.permission.READ_MEDIA_AUDIO" />
```


```cs
iOS/Mac Catalyst Required:

<key>com.apple.security.assets.movies.read-only</key>
<true/>
<key>com.apple.security.assets.music.read-only</key>
<true/>
<key>com.apple.security.assets.pictures.read-only</key>
<true/>
<key>com.apple.security.files.downloads.read-only</key>
<true/>
<key>com.apple.security.files.user-selected.read-only</key>
<true/>
<key>com.apple.security.personal-information.photos-library</key>
<true/>
```


```cs
Windows Required:
SDK-version 10.0.22621.0
- No setup is required.
```

[^1]: © 1991 - 2025 Ajour Media AS.
