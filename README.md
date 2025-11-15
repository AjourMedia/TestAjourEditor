# ![Ajour Media](https://github.com/AjourMedia/TestAjourEditor/blob/master/logo64.png) Maui Cross platform Editor-library<br/>for HTML, XML and RTF.[^1]

## Editorial tool to produce articles and reportage for use in newspapers, online newspapers, TV or radio.

### Supported platforms: Windows, MacOS, iOS and Android. Default languages: Norwegian, English y Español.

#### Module 1: Write articles, using paragraph stylesheets and character styles. Save as rtf and html. Publish your stories via epost, your favorite social media platforms or create your own favorite smtp, ftp and https/rest destination channels.
#### Module 2: Texts, images and videos are linked to the article from here.
#### Module 3: Choosing the image section, correct resolution, light and contrast.
#### Module 4: Format/design and finalize the article with text and images to the desired layout for print, web and mobile. The finished product is saved as a pdf file. (The pdf module requires a separate license if the product is to be used commercially)

### TODO:
Xcode Version **26.1.1** (17B100)<br />
Xcode->Settings->Components:<br />
Verify installed = macOS 26.1 (25B74) SDK (Built-in)<br />
If not installed, install iOS 26.1 (**23B77**) SDK + iOS 26.1 (23B86) Simulator.<br />
Android simulator API **36.1**, arm64 v8a, **16KB** Page Size.<br />
Mac> sudo dotnet workload update (verify SDK 10.0.100)<br />
Windows> dotnet workload update (verify SDK 10.0.100)<br />
Mac> open /Users/admin/Library/Caches/Xamarin (**Obsolete**)<br />
Mac> open /Users/admin/Library/Caches/maui (**new location** .NET 10.0)<br />
Mac> open /usr/local/share/dotnet/library-packs <br />(local store to put **Ajour.EditorLib.nupkg**)<br />

### TODO:
**v1.8.31**<br />
- Create new document, open existing document from local storage folder and save documents in file folder as .rtf file format.<br />
- Style text using predefined paragraph stylesheets and text styles, as well as bold, italic, and underline.<br />
- Edit the text letter by letter within the paragraph. Merging paragraphs and editing multiple selected letters at once is not yet available.<br />

![Windows Desktop](https://github.com/AjourMedia/TestAjourEditor/blob/master/reporter_windows.png)
![Android Mobile](https://github.com/AjourMedia/TestAjourEditor/blob/master/android_mobile.png)

![MacOS Desktop](https://github.com/AjourMedia/TestAjourEditor/blob/master/reporter_macintosh.png)
![iPhone Mobile](https://github.com/AjourMedia/TestAjourEditor/blob/master/reporter_iPhone.png)


### PROJECT: TESTE AJOUR EDITOR Library
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


### Customize your own appearance:
```xhtml
<Color x:Key="editor_background">#C8C8C8</Color>
<Color x:Key="editor_background_dark">#ACACAC</Color>
<Color x:Key="editor_background_selected">#E1E1E1</Color>
<Color x:Key="editor_forground">#141414</Color>
<Color x:Key="Greenish">#339933</Color>
```


[^1]: Copyright © 1991 - 2025 Ajour Media AS.

```cs
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseAjourEditor();

            #if DEBUG
            builder.Logging.AddDebug();
            #endif

            builder.Services.AddSingleton<DesktopWindow>();

            return builder.Build();
        }
    }
}
```

```xhtml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage 
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="TestAjourEditor.MainPage"
    xmlns:ajourlib="clr-namespace:Ajour.EditorLib;assembly=Ajour.EditorLib"
    >
    <!-- Editor -->
    <ajourlib:AjourEditor />
</ContentPage>
```


**Android Required:**
```xhtml
XML
<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" android:maxSdkVersion="32" />
<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" android:maxSdkVersion="34" />
<!-- Required only if your app needs to access images or photos that other apps created -->
<uses-permission android:name="android.permission.READ_MEDIA_IMAGES" />
<!-- Required only if your app needs to access videos that other apps created -->
<uses-permission android:name="android.permission.READ_MEDIA_VIDEO" />
<!-- Required only if your app needs to access audio files that other apps created -->
<uses-permission android:name="android.permission.READ_MEDIA_AUDIO" />
<queries>
<intent>
<action android:name="android.media.action.IMAGE_CAPTURE" />
<action android:name="android.intent.action.SENDTO" />
<data android:scheme="mailto" />
</intent>
</queries>
```


**iOS/Mac Catalyst Required:**
```plist
Info.plist
<key>com.apple.security.assets.movies.read-only</key>
<true/>
<key>com.apple.security.assets.music.read-only</key>
<true/>
<key>com.apple.security.assets.pictures.read-only</key>
<true/>
<key>com.apple.security.files.downloads.read-only</key>
<true/>
<key>com.apple.security.personal-information.photos-library</key>
<true/>
<key>LSApplicationQueriesSchemes</key>
<array>
<string>mailto</string>
</array>
```


**Mac Catalyst Crashes at Apple:**
```plist
<key>UIDeviceFamily</key>
<array>
<integer>6</integer>
</array>
```


**Mac Catalyst Alternative:**
```plist
<key>UIDeviceFamily</key>
<array>
<integer>2</integer>
</array>
```


**Mac Catalyst Required:**
```plist
Entitlements.plist
<key>com.apple.security.files.user-selected.read-write</key>
<true/>
```


**Windows Required:**
```
SDK-version 10.0.22621.0
- No setup is required.
```

**Optional: MacCatalyst and Windows**
```cs
#if MACCATALYST
builder.Services.AddSingleton<AppTitleCatalyst>();
#endif
#if WINDOWS10_0_22621_0_OR_GREATER
builder.Services.AddSingleton<AppTitleWinUI>();
#endif
builder.Services.AddSingleton<ReporterPage, ReporterViewModel>();

private readonly IServiceProvider? services;
public App(IServiceProvider services)
{
    InitializeComponent();
	this.services = services.GetService<IServiceProvider>();
}

protected override Window CreateWindow(IActivationState? activationState)
{
	if (DeviceInfo.Current.Platform == DevicePlatform.WinUI ||
		DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
	{
		Window? window = null;
		if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
		{
			window = services?.GetService<AppTitleWinUI>()!;
			window.Page = new StartupWinUI();
		}
		else
		{
			window = services?.GetService<AppTitleCatalyst>()!;
			window.Page = new StartupCatalyst();
		}
		window.Created += (sender, args) =>
		{
			Window? window = sender as Window;
			if (window != null)
			{
				string? position = Microsoft.Maui.Storage.Preferences.Get("Position", null);
				if (position != null)
				{
					string[] array = position.Split(";".ToCharArray());
					var bounds = new Rect(
						new Point(Convert.ToDouble(array[0]), Convert.ToDouble(array[1])),
						new Size(Convert.ToDouble(array[2]), Convert.ToDouble(array[3])));
					if (bounds.Width > 0 && bounds.Height > 0)
					{
						window.X = bounds.Left;
						window.Y = bounds.Top;
						window.Width = bounds.Width;
						window.Height = bounds.Height;
					}
				}
			}
		};
		window.Destroying += (sender, args) =>
		{
			Window? window = sender as Window;
			if (window != null)
			{
				string position = String.Format("{0};{1};{2};{3}",
					Convert.ToInt32(window.X),
					Convert.ToInt32(window.Y),
					Convert.ToInt32(window.Width),
					Convert.ToInt32(window.Height));
				Microsoft.Maui.Storage.Preferences.Set("Position", position);
			}
		};
		return window;
	}
	else
	{
		return new Window(new StartupMobile());
	}
}
```

