using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Ajour.EditorLib;
using TestAjourEditor.Views;

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

			#if MACCATALYST
			builder.Services.AddSingleton<AppTitleCatalyst>();
			#endif
			#if WINDOWS10_0_22621_0_OR_GREATER
			builder.Services.AddSingleton<AppTitleWinUI>();
			#endif

            return builder.Build();
        }
    }
}
