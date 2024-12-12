namespace ProApiFull.Service.Dependences.SubConfigrations.IServiceCollections;

public static class CorsPolicyConfig
{
    public static IServiceCollection AddCorsPolicyConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();

        // [DisableCors]
        //[EnableCors(PolicyName = "MyPolicy1")]
        //services.AddCors(options =>
        //{
        //    options.AddPolicy("AllowAll", builder =>
        //    {
        //        builder.AllowAnyOrigin();
        //        builder.AllowAnyHeader();
        //        builder.AllowAnyMethod();
        //    });
        //});
        //services.AddCors(options =>
        //{
        //    options.AddPolicy("MyPolicy1", builder =>
        //    {
        //        builder.WithMethods("PUT", "GET", "POST", "DELETE");
        //        builder.WithHeaders(HeaderNames.ContentType, "application/json");
        //        builder.WithOrigins("xxx.com");
        //    });
        //});
        //services.AddCors(options =>
        //{
        //    options.AddPolicy("MyPolicy2", builder =>
        //    {
        //        builder.WithMethods("PUT", "GET", "POST", "DELETE");
        //        builder.WithHeaders(HeaderNames.ContentType, "application/json");
        //        builder.WithOrigins(allowedOrigins!);
        //    });
        //});

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.WithOrigins(allowedOrigins!);
            });
        });
        return services;
    }

    public static WebApplication AddUseCorsPolicyPipeLine(this WebApplication app)
    {
        //  app.UseCors("MyPolicy1");


        //Default Policy
        app.UseCors();

        return app;
    }

}
