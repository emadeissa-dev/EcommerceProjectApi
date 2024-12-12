namespace ProApiFull.Api.MiddleWare;
//    services.AddExceptionHandler< GlobalExceptionHangler>();
//  app.UseExceptionHandler(_ => { });
public class GlobalExceptionHangler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHangler> _logger;
    public GlobalExceptionHangler(ILogger<GlobalExceptionHangler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError("Your Error Is {Message}", exception.Message);
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = exception.Message,
            Type = "rfc",
        };
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemDetails);

        return true;
    }
}
