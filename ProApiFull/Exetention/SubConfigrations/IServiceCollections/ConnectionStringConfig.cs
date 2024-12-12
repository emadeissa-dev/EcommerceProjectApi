namespace ProApiFull.Service.Dependences.SubConfigrations.IServiceCollections;

public static class ConnectionStringConfig
{
    public static IServiceCollection AddConnectionStringConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection Not Fount With 'DefaultConnection'");

        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(connection);
        });
        return services;
    }
}
