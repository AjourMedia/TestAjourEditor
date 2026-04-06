using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
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
			.UseMauiCommunityToolkitMediaElement(isAndroidForegroundServiceEnabled: true, static options =>
			{
				options.SetDefaultAndroidViewType(AndroidViewType.TextureView);
			})
			.ConfigureFonts(fonts =>
            {
				fonts.AddFont("Arial.ttf", "Arial");
				fonts.AddFont("Arial Italic.ttf", "Arial Italic");
				fonts.AddFont("Arial Bold.ttf", "Arial Bold");
				fonts.AddFont("Arial Bold Italic.ttf", "Arial Bold Italic");
				fonts.AddFont("Courier New.ttf", "Courier New");
				fonts.AddFont("Courier New Italic.ttf", "Courier New Italic");
				fonts.AddFont("Courier New Bold.ttf", "Courier New Bold");
				fonts.AddFont("Courier New Bold Italic.ttf", "Courier New Bold Italic");
				fonts.AddFont("Times New Roman.ttf", "Times New Roman");
				fonts.AddFont("Times New Roman Italic.ttf", "Times New Roman Italic");
				fonts.AddFont("Times New Roman Bold.ttf", "Times New Roman Bold");
				fonts.AddFont("Times New Roman Bold Italic.ttf", "Times New Roman Bold Italic");
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
