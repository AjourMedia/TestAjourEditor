using CommunityToolkit.Maui;
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
