using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ProApiFull.Api.ExetentionServives.SubConfigrations.IServiceCollections;

public static class HttpContextUrlHelperConfig
{


    public static IServiceCollection AddHttpContextUrlHelperConfig(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddTransient<IUrlHelper>(x =>
        {
            var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
            var factory = x.GetRequiredService<IUrlHelperFactory>();
            return factory.GetUrlHelper(actionContext!);
        });
        return services;
    }

}
