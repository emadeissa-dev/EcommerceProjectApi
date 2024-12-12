using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace ProApiFull.Api.Exetentions;

public static class LocalizerServicesConfig
{
    public static IServiceCollection AddLocalizerServicesConfig(this IServiceCollection services)
    {
        services.AddLocalization(opt =>
        {
            opt.ResourcesPath = "";
        });

        services.Configure<RequestLocalizationOptions>(options =>
        {
            List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
    };

            options.DefaultRequestCulture = new RequestCulture("en-US");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
        return services;
    }
    public static WebApplication AddLocalizeMiddelWare(this WebApplication app)
    {
        //app.UseRequestLocalization(new RequestLocalizationOptions
        //{
        //    ApplyCurrentCultureToResponseHeaders = true
        //});

        var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);
        return app;
    }
}
