namespace ProApiFull.Service.Dependences.SubConfigrations.IServiceCollections.Caching;

public static class MemoryCaching
{
    public static IServiceCollection AddMemoryCachingConfig(this IServiceCollection services)
    {
        services.AddMemoryCache();
        return services;
    }
}
