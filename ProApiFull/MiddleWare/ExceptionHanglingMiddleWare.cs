namespace ProApiFull.Api.MiddleWare;
// app.UseMiddleware<ExceptionHanglingMiddleWare>();
public class ExceptionHanglingMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHanglingMiddleWare> _logger;

    public ExceptionHanglingMiddleWare(
        RequestDelegate next,
        ILogger<ExceptionHanglingMiddleWare> logger
        )
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError("Your Error Is {Message}", ex.Message);
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = ex.Message,
                Type = "rfc",
            };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
