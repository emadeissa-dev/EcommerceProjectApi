namespace ProApiFull.Api.ExetentionServives.SubConfigrations.IServiceCollections;

public static class AspVersioningConfig
{
    public static IServiceCollection AddAspVersioningConfig(this IServiceCollection services, IConfiguration configuration)
    {
        //Asp.Versioning.Http
        services.AddApiVersioning();
        return services;
    }
}
