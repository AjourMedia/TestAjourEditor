TODO: TEST AJOUR EDITOR Library

1. Create a new MAUI Application

2. Add "Ajour.EditorLib.1.4.xx.nupkg"

- copy to your offline packages folder, then add to your project.

3. Open MauiProgram.cs

3a. Add "using Ajour.EditorLib;"

3b. Add "builder.UseAjourEditor();"

4. Open MainPage.xaml

4a. Add xmlns:ajourlib="clr-namespace:Ajour.EditorLib;assembly=Ajour.EditorLib"

4b. Replace sample content with "<ajourlib:AjourEditor />"

5. Open MainPage.xaml.cs

- remove sample source

6. Build and run

7. Skriv noe tekst og klikk på B, I eller U



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



<?xml version="1.0" encoding="utf-8" ?>

<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"

             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"

             x:Class="TestAjourEditor.MainPage"

			 xmlns:ajourlib="clr-namespace:Ajour.EditorLib;assembly=Ajour.EditorLib"

			 >

	<!-- Editor -->

	<ajourlib:AjourEditor />

</ContentPage>

