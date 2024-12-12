namespace ProApiFull.Service.Dependences.SubConfigrations.IServiceCollections;

public static class ExceptionHandlerConfig
{

    public static IServiceCollection AddExceptionHandlerConfig(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHangler>();
        return services;
    }
    public static WebApplication AddGlobalExceptionPipeLine(this WebApplication app)
    {
        //  app.UseMiddleware<AddMiddleWareForApp>();
        // app.UseMiddleware<ExceptionHanglingMiddleWare>();

        app.UseExceptionHandler(_ => { });

        return app;
    }
}
