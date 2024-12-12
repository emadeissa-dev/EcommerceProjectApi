

namespace ProApiFull.Api.MiddleWare.CustomeMiddelWare;

public class AddMiddleWareForApp(
    ILogger<AddMiddleWareForApp> logger,
    RequestDelegate next)
{
    private readonly Microsoft.Extensions.Logging.ILogger logger = logger;

    private readonly RequestDelegate next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            await next(context);
            stopwatch.Stop();
            logger.LogInformation("Logging Time" + stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {

        }

    }
}
