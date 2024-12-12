namespace ProApiFull.Api.ExetentionServives.SubConfigrations.IServiceCollections.Mapping;

public static class MapsterConfig
{
    public static IServiceCollection AddMapsterConfig(this IServiceCollection services)
    {

        var mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton<MapsterMapper.IMapper>(new MapsterMapper.Mapper(mappingConfig));
        return services;
    }
}
