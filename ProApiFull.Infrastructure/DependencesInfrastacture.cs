using Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using ProApiFull.Infrastructure.UnitOfWork;

namespace ProApiFull.Infrastructure;
public static class DependencesInfrastacture
{
    public static IServiceCollection AddDependencesInfrastacture(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        return services;
    }
}


