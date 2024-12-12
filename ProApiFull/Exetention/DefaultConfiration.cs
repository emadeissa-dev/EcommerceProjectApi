using ProApiFull.Api.Exetentions;
using ProApiFull.Api.ExetentionServives.SubConfigrations.IServiceCollections;
using ProApiFull.Api.ExetentionServives.SubConfigrations.IServiceCollections.Authentications;

namespace ProApiFull.Service.Dependences;

public static class DefaultConfiration
{
    public static IServiceCollection AddDepenencesConfig(this IServiceCollection services, IConfiguration configuration)
    {

        //Controllers - EndpointsApiExplorer - AddSwaggerGen
        services.AddDefaultConfig();
        //Connection String 
        services.AddConnectionStringConfig(configuration);



        services.AddHttpContextUrlHelperConfig();

        services.AddLocalizerServicesConfig();


        //Add HybridCaching
        services.AddHybridCachingConfig();

        // Add Global Exception Handler
        services.AddExceptionHandlerConfig();

        //Add Authentication Identity User Identity Role
        services.AddAuthenticationJWTConfig(configuration);


        services.AddHangfireConfig(configuration);

        services.AddRateLimitingConfig();

        return services;
    }

    public static WebApplication AddMiddleWarePipeLine(this WebApplication app)
    {

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.AddSerilogPipeLine();
        app.UseStaticFiles();
        ////Custom MiddelWare Use 
        // app.AddCustomMiddelWareUse();
        app.AddGlobalExceptionPipeLine();

        // Add Identity EndPoints
        // app.AddMapIdentityApi();

        app.UseHttpsRedirection();
        // Add Authentication 
        app.UseAuthentication();


        app.UseAuthorization();



        // Add BackGround Jobs
        app.AddHangfirePipeLine();




        app.AddRateLimitingPipeLine();
        app.AddLocalizeMiddelWare();

        app.MapControllers();
        return app;
    }

}

