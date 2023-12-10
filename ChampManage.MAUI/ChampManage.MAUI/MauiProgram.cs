using ChampManage.MAUI.Services;
using ChampManage.MAUI.ViewModels;
using ChampManage.MAUI.Views;
using Microsoft.Extensions.Logging;

namespace ChampManage.MAUI
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
                });
            builder.Services.AddSingleton<NewsService>();
            builder.Services.AddSingleton<ChampionshipService>();

            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<NewsDetailsViewModel>();
            builder.Services.AddSingleton<ChampionshipsViewModel>();
            builder.Services.AddTransient<ChampionshipDetailsViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<NewsDetailsPage>();
            builder.Services.AddSingleton<ChampionshipsPage>();
            builder.Services.AddTransient<ChampionshipDetailsPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}