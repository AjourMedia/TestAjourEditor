# ![Ajour Media](logo64.png) Maui Cross platform Editor-library<br/>for HTML, XML and RTF.[^1]

## Editorial tool to produce articles and reportage for use in newspapers, online newspapers, TV or radio.

#### This is a very early phase of a project that is planned to run throughout 2025. Input and ideas will be gratefully received.


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

![Printscreen](android.png)

### TODO:
- [x] Text Styles: Type some text and click **B**, **I** eller **U** (v1.4.21)
- [x] Click the Open File button **testfil2 med bilder**.html (v1.4.30)

**Task 1:** 
- Open an html page in the editor as an editable document.
- Save the document to your local hard drive as **html** or **rtf** file format.

**Task 2:** 
- Load a web page from your web browser. **Highlight** the content you are interested in and **copy** it to the clipboard.
- Click the **Paste** button in the editor to **edit the content** from the web page as an **editable document**.
- The document is now completely independent of the web page you copied it from. You can edit it as you wish and save the result to your local hard drive as **html** or **rtf** file format.

[^1]: Copyright © 1991 - 2025 Ajour Media AS.

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
```js
C#
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadMediaAudio)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadMediaImages)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadMediaVideo)]
```
```xhtml
XML
<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" android:maxSdkVersion="32" />
<!-- Required only if your app needs to access images or photos that other apps created -->
<uses-permission android:name="android.permission.READ_MEDIA_IMAGES" />
<!-- Required only if your app needs to access videos that other apps created -->
<uses-permission android:name="android.permission.READ_MEDIA_VIDEO" />
<!-- Required only if your app needs to access audio files that other apps created -->
<uses-permission android:name="android.permission.READ_MEDIA_AUDIO" />
```


**iOS/Mac Catalyst Required:**
```plist
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


**Windows Required:**
```
SDK-version 10.0.22621.0
- No setup is required.
```
