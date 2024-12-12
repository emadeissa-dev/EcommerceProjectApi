

namespace ProApiFull.Service.Dependences.SubConfigrations.IServiceCollections;

public static class ApiEndpointConfig
{
    public static IServiceCollection AddApiEndpointConfig(this IServiceCollection services)
    {
        services.AddIdentityApiEndpoints<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
    public static WebApplication AddMapIdentityApiPipeLine(this WebApplication app)
    {
        app.MapIdentityApi<ApplicationUser>();
        return app;
    }
}
