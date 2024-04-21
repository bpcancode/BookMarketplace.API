using BookMarketplace.App.Services;
using BookMarketplace.App.View;
using BookMarketplace.App.ViewModel;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Refit;
using UraniumUI;
using Xamarin.Android.Net;

namespace BookMarketplace.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<DashboardView>()
            .AddTransient<DashboardViewModel>()
            .AddTransient<LoginView>()
            .AddTransient<AuthViewModel>()
            .AddTransient<SingupView>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        ConfigureRefit(builder.Services);
        return builder.Build();
    }
    private static void ConfigureRefit(IServiceCollection services)
    {
        var refitSettings = new RefitSettings
        {
            HttpMessageHandlerFactory = () =>
            {
                return new AndroidMessageHandler
                {
                    ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                    {
                        return certificate?.Issuer == "CN=localhost" || sslPolicyErrors == System.Net.Security.SslPolicyErrors.None;
                    }
                };
            }
        };
        services.AddRefitClient<IAuthService>(refitSettings)
            .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri("http://10.0.2.2:5140"));
    }


}

