

using Microsoft.AspNetCore.RateLimiting;

namespace ProApiFull.Api.ExetentionServives.SubConfigrations.IServiceCollections;

public static class RateLimitingConfig
{
    public static IServiceCollection AddRateLimitingConfig(this IServiceCollection services)
    {
        ///////    [EnableRateLimiting("concurrency")]
        //////// Rate Limiter
        //services.AddRateLimiter(RateLimiterOptions =>
        //{
        //    RateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

        //    RateLimiterOptions.AddConcurrencyLimiter("concurrency", options =>
        //    {
        //        options.PermitLimit = 2;
        //        options.QueueLimit = 1;
        //        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
        //    });
        //});


        //services.AddRateLimiter(RateLimiterOptions =>
        //{
        //    RateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

        //    RateLimiterOptions.AddTokenBucketLimiter("tokens", options =>
        //    {
        //        options.TokenLimit = 2;
        //        options.QueueLimit = 1;
        //        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
        //        options.ReplenishmentPeriod = TimeSpan.FromSeconds(60);
        //        options.TokensPerPeriod = 2;
        //        options.AutoReplenishment = true;
        //    });
        //});

        services.AddRateLimiter(RateLimiterOptions =>
        {
            RateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            RateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
            {
                options.PermitLimit = 2;
                options.Window = TimeSpan.FromSeconds(30);
                options.QueueLimit = 1;
                options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
            });
        });
        return services;
    }
    public static WebApplication AddRateLimitingPipeLine(this WebApplication app)
    {
        app.UseRateLimiter();
        return app;
    }
}
