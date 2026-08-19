# ![Ajour Media](https://github.com/AjourMedia/TestAjourEditor/blob/master/logo64.png) Maui Cross platform Editor-library.[^1]

## Editorial tool to produce articles and reportage for use in newspapers, online newspapers, TV or radio.

### The main goal is similarity in working methods. To create the same recognizability and optimal production efficiency regardless of platform and devices. Speech To Text is an effective method we prioritize, especially regarding typing on mobile phones.

#### Supported platforms: Windows, MacOS, iOS and Android. Default languages: Norwegian, English y Español.

###### <ins>Reporter:</ins> Text editor. Has two primary purposes. Ease of use and recognisability on all types of mobile and desktop devices on large or small monitors.
###### <ins>Text catalog:</ins> Your folder structure where you organize your different documents and which images and videos are linked to each of them.
###### <ins>Image editing:</ins> Uses soft cropping tool to crop the image area you are interested in. Correct resolution, brightness, and contrast. Update XMP metadata. Images and videos are linked to your document from here.
###### <ins>Planner:</ins> Advanced graphic tools to produce layout for publishing to multiple publishing channels, pdf, rtf, html, social media and different types of xml formatting adapted to the editorial team you are associated with.

#### <ins>TODO:</ins>
Xcode Version **26.5** (17F42)<br />
Xcode->Settings->Components:<br />
Verify installed = macOS 26.5 (**25F70**) SDK (Built-in)<br />
If not installed, install iOS 26.5 (**23F73**) SDK + iOS 26.5 (23F77) Simulator.<br />
Android simulator API **36.1.69**, arm64 v8a, **16KB** Page Size.<br />
Mac> sudo dotnet workload update (verify MAUI **10.0.301**)<br />
Windows> dotnet workload update (verify MAUI **10.0.301.1**)<br />
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
- Localization support for English, Spanish and Norwegian languages.<br />
- Basic user interface with toolbar buttons for common actions.<br />
#### <ins>v1.8.63</ins>
- Copy, cut, and paste text within the document.<br />
#### <ins>v1.8.65</ins>
- Undo and redo text changes.<br />
- Localization support for English, Spanish and Norwegian languages.<br />
#### <ins>v1.8.86</ins>
- App-to-App Deep Link support for opening documents from other apps, or from other instances within the same project. Currently supports the RTF file type. All known file types will be added gradually.<br />
#### <ins>v1.8.91</ins>
- Read .docx Office Open XML word processing documents.
#### <ins>v2.0.2</ins>
- Bug fixes and stability improvements based on initial user feedback.<br />
#### <ins>v2.0.42</ins>
- Preliminary Speech To Text support. Implemented for iOS.<br />
#### <ins>v2.0.50</ins>
- Speech To Text support. Implemented for all platforms.<br />
#### <ins>v2.1.0</ins>
- Cut, copy and paste improvements.<br />
- Edit text improvements.<br />
- Text styles improvements.<br />
#### <ins>v3.0.300</ins>
- Insert image into text.<br />
- Send email with picture.<br />
- Printing with photos.<br />
- Speech To Text all platforms.<br />
- Fixed Sandbox problems.<br />
#### <ins>v3.0.311</ins>
- Fixed Speech To Text gives up too early.<br />
#### <ins>v3.0.312</ins>
- Fixed A4 margins may disappear under certain conditions.<br />
#### <ins>v3.0.316</ins>
- Fixed Speech To Text refresh problem on some devices.<br />
#### <ins>v3.0.317</ins>
- Fixed .docx problem.<br />
#### <ins>v3.1.321</ins>
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

[^1]: Copyright © 1991 - 2026 Ajour Media AS.

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
<!-- Required for printer and email -->
<uses-permission android:name="android.permission.READ_MEDIA_IMAGES" />
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
<key>NSMicrophoneUsageDescription</key>
<string>SpeechToText requires microphone usage</string>
<key>NSSpeechRecognitionUsageDescription</key>
<string>SpeechToText requires speech recognition usage</string>
<key>NSPhotoLibraryAddUsageDescription</key>
<string>PhotosAddOnly</string>
<key>NSPhotoLibraryUsageDescription</key>
<string>This app needs access to your photo library to attach images to emails.</string>
<key>NSDocumentsFolderUsageDescription</key>
<string>This app needs access to your documents to attach files to emails.</string>
<key>UISupportsDocumentBrowser</key>
<true/>
<key>LSSupportsOpeningDocumentsInPlace</key>
<true/>
<key>NSExtensionActivationSupportsText</key>
<true/>
<key>UIFileSharingEnabled</key>
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
<key>com.apple.security.device.camera</key>
<true/>
<key>com.apple.security.device.audio-input</key>
<true/>
<key>com.apple.security.print</key>
<true/>
```


##### <ins>App-to-App Deep Link support.</ins>
```cs
Now implemented automatically. No further action required.
```

##### <ins>Android: App-to-App Deep Link support.</ins>
- Verify exist else create: Android/Resources/layout/main.xml
```xhtml
<activity android:name=".FileLauncher" android:exported="true">
	<intent-filter>
		<action android:name="android.intent.action.VIEW" />
		<category android:name="android.intent.category.DEFAULT" />
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
