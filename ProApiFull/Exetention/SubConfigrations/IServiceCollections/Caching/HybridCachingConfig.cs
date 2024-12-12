using Microsoft.Extensions.Caching.Hybrid;

namespace ProApiFull.Api.ExetentionServives.SubConfigrations.IServiceCollections;

public static class HybridCachingConfig
{
    public static IServiceCollection AddHybridCachingConfig(this IServiceCollection services)
    {
        services.AddHybridCache();
        return services;
    }
}
