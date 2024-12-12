namespace ProApiFull.Service.Dependences.SubConfigrations.IServiceCollections.Caching;

public static class ResponseCaching
{
    //  [ResponseCache(Duration = 60)]
    //will work with only status code 200 ok()
    public static IServiceCollection AddResponseCachingConfig(this IServiceCollection services)
    {

        services.AddResponseCaching();
        return services;
    }
    public static WebApplication AddResponseCachingPipeLine(this WebApplication app)
    {
        // add caching after cors and authrizations
        app.UseResponseCaching();
        return app;
    }
}
