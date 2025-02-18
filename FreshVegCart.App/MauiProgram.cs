using FreshVegCart.App.Apis;
using Microsoft.Extensions.Logging;
using Refit;

namespace FreshVegCart.App;

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
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif


        builder.AddRefit();


        return builder.Build();
    }


    private static MauiAppBuilder AddRefit(this MauiAppBuilder builder)
    {
        const string baseApiUrl = "https://qjsrvfbc-7214.usw3.devtunnels.ms";
        builder.Services.AddRefitClient<IProductApi>().ConfigureHttpClient(SetHttpClient);
        builder.Services.AddRefitClient<IAuthApi>().ConfigureHttpClient(SetHttpClient);
        builder.Services.AddRefitClient<IOrderApi>(GetRefitSettings).ConfigureHttpClient(SetHttpClient);
        builder.Services.AddRefitClient<IUserApi>(GetRefitSettings).ConfigureHttpClient(SetHttpClient);

        static void SetHttpClient(HttpClient httpClient) => httpClient.BaseAddress = new Uri(baseApiUrl);

        static RefitSettings GetRefitSettings(IServiceProvider serviceProvider)
        {
            var settings = new RefitSettings();
            settings.AuthorizationHeaderValueGetter = (_, __) => Task.FromResult("Bearer ");
            return settings;
        };

        return builder;
    }
}