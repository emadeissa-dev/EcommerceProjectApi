

namespace ProApiFull.Service.Dependences.SubConfigrations.IServiceCollections.Caching;

public static class OutPutCaching
{


    public static IServiceCollection AddOutPutCachingConfig(this IServiceCollection services)
    {
        // [OutputCache(Duration = 60)]
        // services.AddOutputCache();

        //Add In Controller
        // [OutputCache(PolicyName = OutPutCaching.policyName)]
        services.AddOutputCache(options =>
        {
            options.AddPolicy
            (ShareKeyword.policyName, x => x.Cache()
            .Expire(TimeSpan.FromSeconds(120))
            .Tag(ShareKeyword.Caching)
            );
        });
        return services;
    }
    public static WebApplication AddOutPutCachingPipeLine(this WebApplication app)
    {
        // add caching after cors and authrizations
        app.UseOutputCache();
        return app;
    }
}
