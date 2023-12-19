namespace SingerSong.WebAPI.Extensions;

public static class ServiceConfigurationExtension
{
    public static void AddDBContextService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationService(configuration.GetValue<string>("ConnectionString"));
    }
}

