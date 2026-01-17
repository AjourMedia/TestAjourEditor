# ![Ajour Media](https://github.com/AjourMedia/TestAjourEditor/blob/master/logo64.png) Maui Cross platform Editor-library.[^1]

## Editorial tool to produce articles and reportage for use in newspapers, online newspapers, TV or radio.

### The main goal is similarity in working methods. To create the same recognizability and optimal production efficiency regardless of platform and devices. Speech To Text is an effective method we prioritize, especially regarding typing on mobile phones.

#### Supported platforms: Windows, MacOS, iOS and Android. Default languages: Norwegian, English y Español.

###### <ins>Reporter:</ins> Text editor. Has two primary purposes. Ease of use and recognisability on all types of mobile and desktop devices on large or small monitors.
###### <ins>Text catalog:</ins> Your folder structure where you organize your different documents and which images and videos are linked to each of them.
###### <ins>Image editing:</ins> Uses soft cropping tool to crop the image area you are interested in. Correct resolution, brightness, and contrast. Update XMP metadata. Images and videos are linked to your document from here.
###### <ins>Planner:</ins> Advanced graphic tools to produce layout for publishing to multiple publishing channels, pdf, rtf, html, social media and different types of xml formatting adapted to the editorial team you are associated with.

#### <ins>TODO:</ins>
Xcode Version **26.2** (17C52)<br />
Xcode->Settings->Components:<br />
Verify installed = macOS 26.2 (25C57) SDK (Built-in)<br />
If not installed, install iOS 26.2 (**23C53**) SDK + iOS 26.2 (**23C54**) Simulator.<br />
Android simulator API **36.1**, arm64 v8a, **16KB** Page Size.<br />
Mac> sudo dotnet workload update (verify SDK 10.0.100)<br />
Windows> dotnet workload update (verify SDK 10.0.100)<br />
Mac> open /Users/admin/Library/Caches/Xamarin (**Obsolete**)<br />
Mac> open /Users/admin/Library/Caches/maui (**new location** .NET 10.0)<br />
Mac> open /usr/local/share/dotnet/library-packs <br />(local store to put **Ajour.EditorLib.nupkg**)<br />

#### <ins>v1.8.60</ins>
- Cross-platform support for Windows, MacOS, iOS, and Android.<br />
- File menu with options for new, open, save, save as, and export.<br
- Using local storage folder for opening and saving documents.<br />
- Open and save .rtf file format.<br />
- Send document via email as .html, .rtf and .txt attachment.<br />
- Print document to connected printer or print to pdf.<br />
- Style text using predefined paragraph stylesheets and text styles, as well as bold, italic, and underline.<br />
- Apply text styles (Heading 1, Heading 2, Heading 3) to selected paragraphs.<br />
- Apply text formatting (bold, italic, underline) to selected text.<br />
- Responsive design for different screen sizes and orientations.<br />
- Touch and mouse input support for text editing.<br />
- Basic text navigation using arrow keys, page up/down, home/end, and mouse clicks.
- Basic error handling for file operations and unsupported formats.<br />
- Preliminary localization support for English, Spanish and Norwegian languages.<br />
- Basic user interface with toolbar buttons for common actions.<br />
#### <ins>v1.8.63</ins>
- Copy, cut, and paste text within the document.<br />
#### <ins>v1.8.65</ins>
- Preliminary Undo and redo text changes.<br />
- Localization support for English, Spanish and Norwegian languages.<br />
#### <ins>v1.8.86</ins>
- App-to-App Deep Link support for opening documents from other apps, or from other instances within the same project. Currently supports the RTF file type. All known file types will be added gradually.<br />
#### <ins>v1.8.91</ins>
- Preliminary read .docx Office Open XML word processing documents.
#### <ins>v1.8.110</ins>
- Bug fixes and stability improvements based on initial user feedback.<br />
<br />

##### <ins>Windows 11</ins>
![Windows Desktop](https://github.com/AjourMedia/TestAjourEditor/blob/master/reporter_windows.png)

##### <ins>Android 16.0</ins>
![Android Mobile](https://github.com/AjourMedia/TestAjourEditor/blob/master/android_mobile.png)

##### <ins>MacOS Tahoe 26.1</ins>
![MacOS Desktop](https://github.com/AjourMedia/TestAjourEditor/blob/master/reporter_macintosh.png)

##### <ins>iPhone 17</ins>
![iPhone Mobile](https://github.com/AjourMedia/TestAjourEditor/blob/master/reporter_iPhone.png)


##### <ins>Project: Test Ajour Editor Library</ins>
1. Create a new MAUI Application
2. Add Nuget package [Ajour.EditorLib.1.x.xx.nupkg]()<br/>
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


#### <ins>Customize your own appearance:</ins>
```xhtml
<Color x:Key="editor_background">#C8C8C8</Color>
<Color x:Key="editor_background_dark">#ACACAC</Color>
<Color x:Key="editor_background_selected">#E1E1E1</Color>
<Color x:Key="editor_forground">#141414</Color>
<Color x:Key="Greenish">#339933</Color>
<System:String x:Key="DefaultFontFamily">OpenSansRegular</System:String>
<System:String x:Key="ReporterFontFamily">OpenSansRegular</System:String>
```

#### <ins>MacCatalyst/Sandbox problems:</ins>
```
- One possibility might be to create a shortcut of the document folder on the desktop.
- Una posibilidad podría ser crear un acceso directo a la carpeta de documentos en el escritorio.
iCloud is closed:
terminal % open /Users/admin/Library/Containers/no.ajourmedia.reporter/Data/Documents
iCloud maybe sync:
terminal % open ~/Library/Mobile\ Documents/iCloud~no~ajourmedia~reporter
terminal % open ~/Library/Mobile\ Documents/iCloud~no~ajourmedia~storage
```


[^1]: Copyright © 1991 - 2025 Ajour Media AS.

##### <ins>MauiProgram.cs setup:</ins>
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

##### <ins>MainPage.xaml setup:</ins>
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


##### <ins>Android requirements:</ins>
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
<uses-permission android:name="android.permission.RECORD_AUDIO" />
<queries>
<intent>
<action android:name="android.media.action.IMAGE_CAPTURE" />
<action android:name="android.intent.action.SENDTO" />
<data android:scheme="mailto" />
</intent>
</queries>
```


##### <ins>iOS/Mac Catalyst requirements:</ins>
UIRequiresFullScreen $${\color{orange} Deprecated}$$
```plist
Info.plist
<key>LSApplicationQueriesSchemes</key>
<array>
<string>mailto</string>
<key>NSCameraUsageDescription</key>
<string>Do you allow the app to take a picture?</string>
<key>NSMicrophoneUsageDescription</key>
<string>SpeechToText requires microphone usage</string>
<key>NSSpeechRecognitionUsageDescription</key>
<string>SpeechToText requires speech recognition usage</string>
<key>NSPhotoLibraryAddUsageDescription</key>
<string>Do you allow the app to insert an image or video?</string>
<key>NSPhotoLibraryUsageDescription</key>
<string>Do you allow the app to insert an image or video?</string>
<key>UISupportsDocumentBrowser</key>
<true/>
<key>NSExtensionActivationSupportsText</key>
<true/>
<key>UIFileSharingEnabled</key>
<true/>
<key>LSSupportsOpeningDocumentsInPlace</key>
<true/>
</array>
```


##### <ins>Mac Catalyst configuration:</ins>
```plist
Info.plist
<key>UIDeviceFamily</key>
<array>
<integer>6</integer>
</array>
<key>UISupportsPrinting</key>
<true/>
<key>UIApplicationSupportsPrintCommand</key>
<true/>
```


##### <ins>Mac Catalyst requirements:</ins>
```plist
Entitlements.plist
<key>com.apple.security.app-sandbox</key>
<true/>
<key>com.apple.security.network.client</key>
<true/>
<key>com.apple.security.files.user-selected.read-write</key>
<true/>
<key>com.apple.security.assets.movies.read-only</key>
<true/>
<key>com.apple.security.assets.music.read-only</key>
<true/>
<key>com.apple.security.assets.pictures.read-write</key>
<true/>
<key>com.apple.security.files.downloads.read-write</key>
<true/>
<key>com.apple.security.device.camera</key>
<true/>
<key>com.apple.security.personal-information.photos-library</key>
<true/>
<key>com.apple.security.device.audio-input</key>
<true/>
<key>com.apple.security.device.usb</key>
<true/>
<key>com.apple.security.print</key>
<true/>
```


##### <ins>Windows requirements:</ins>
```
>= SDK-version 10.0.22621.0
- No setup is required for debugging.
```

##### <ins>Optional: MacCatalyst and Windows</ins>
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


##### <ins>App.xaml.cs: App-to-App Deep Link support.</ins>
```cs
/// <summary>
/// App-to-App Deep Link support. Imports registered file types: 
/// - from operating system to the app.
/// - from other apps to the app.
/// - from other instances within the same app.
/// </summary>
protected override async void OnAppLinkRequestReceived(Uri uri)
{
	base.OnAppLinkRequestReceived(uri);

	await Dispatcher.DispatchAsync(async () =>
	{
		try
		{
			// Application.Current.SendOnAppLinkRequestReceived(Uri uri) method.
			// The Application.Current.SendOnAppLinkRequestReceived method is part
			// of the Microsoft.Maui.Controls namespace and is used to send an
			// app link request to this application.

			if (uri.IsFile)
			{
				var ajourEditorViewModel = Microsoft.Maui.Controls.Application.Current.Handler.GetService<Ajour.EditorLib.ViewModels.AjourEditorViewModel>();
				ajourEditorViewModel.ExecuteDeepLinkingCommand.Execute(uri.LocalPath);
			}
		}
		catch { }
	});
}
```

##### <ins>Android: App-to-App Deep Link support.</ins>
- Verify exist else create: Android/Resources/layout/main.xml
```xhtml
<activity android:name=".FileLauncher" android:exported="true">
	<intent-filter>
		<action android:name="android.intent.action.VIEW" />
		<category android:name="android.intent.category.DEFAULT" />
		<data android:scheme="file" />
		<data android:scheme="content" />
		<data android:host="*" />
		<data android:pathPattern=".*\\.rtf" />
		<data android:mimeType="text/rtf" />
	</intent-filter>
</activity>
</queries>
```
```cs
MainActivity.cs
[Activity(MainLauncher = true,
LaunchMode = LaunchMode.SingleTask,
Exported = true,
...]
FileLauncher.cs
[Activity(MainLauncher = false,
LaunchMode = LaunchMode.SingleTop,
AllowTaskReparenting = true,
Exported = true)
]
```
