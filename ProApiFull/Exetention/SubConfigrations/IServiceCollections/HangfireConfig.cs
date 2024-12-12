using Hangfire;
using HangfireBasicAuthenticationFilter;

namespace ProApiFull.Api.ExetentionServives.SubConfigrations.IServiceCollections;

public static class HangfireConfig
{
    //Hangfire.SqlServer
    //Hangfire.Core
    //Hangfire.AspNetCore
    //Hangfire.Dashboard.Basic.Authentication
    public static IServiceCollection AddHangfireConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(config => config
         .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
       .UseSimpleAssemblyNameTypeSerializer()
       .UseRecommendedSerializerSettings()
       .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));


        services.AddHangfireServer();
        return services;
    }
    public static WebApplication AddHangfirePipeLine(this WebApplication app)
    {
        app.UseHangfireDashboard("/jobs", new DashboardOptions
        {
            Authorization =
            [
                new HangfireCustomBasicAuthenticationFilter{
                    User =app.Configuration.GetValue<string>("HangFireSettings:UserName"),
                    Pass =app.Configuration.GetValue<string>("HangFireSettings:Password")
                }
            ],
            DashboardTitle = "App Api Full",
            // IsReadOnlyFunc = (DashboardContext context) => true
        });
        return app;
    }

}
