namespace ProApiFull.Service.Dependences.SubConfigrations.WebApplicationPipeLine;

public static class GlobalExceptionHandlerPipeLine
{
    public static WebApplication AddGlobalExceptionHandlerPipeLine(this WebApplication app)
    {
        var logger = app.Logger;
        app.Use(async (context, next) =>
        {
            try
            {
                logger.LogInformation($"end Point LogInformation ");
                await next(context);
            }
            catch (Exception ex)
            {
                var endpoint = context.GetEndpoint();
                logger.LogError($"end Point {endpoint}");
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
        });
        return app;
    }
}
