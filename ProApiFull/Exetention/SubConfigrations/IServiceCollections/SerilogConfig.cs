using Microsoft.AspNetCore.Builder;

namespace ProApiFull.Service.Dependences.SubConfigrations.IServiceCollections;

public static class SerilogConfig
{
    public static WebApplicationBuilder AddSerilogConfig(this WebApplicationBuilder builder)
    {
        //if (builder.Environment.IsDevelopment())
        //{
        //    builder.Host.UseSerilog((context, configration) =>
        //    {
        //        configration.MinimumLevel.Information().WriteTo.Console();
        //    });
        //}

        builder.Host.UseSerilog((context, configration) =>
        {
            configration.ReadFrom.Configuration(context.Configuration);
        });

        return builder;
    }

    public static WebApplication AddSerilogPipeLine(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        return app;
    }
}
