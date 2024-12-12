namespace ProApiFull.Service.Dependences.SubConfigrations.IServiceCollections;

public static class DefaultConfig
{
    public static IServiceCollection AddDefaultConfig(this IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}
