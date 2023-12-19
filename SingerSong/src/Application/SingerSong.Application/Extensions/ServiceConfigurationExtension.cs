using SingerSong.Application.Security.Abstracts;
using SingerSong.Application.Security.Concretes;

namespace SingerSong.Application.Extensions;

public static class ServiceConfigurationExtension
{
    public static void AddApplicationService(this IServiceCollection services,string connectionString)
    {
        services.AddDbContext<SingerSongDbContext>(opt => opt.UseSqlite(connectionString));
        services.AddScoped<IUnitOfWorkQuery, UnitOfWorkQuery>();
        services.AddScoped<IUnitOfWorkCommand, UnitOfWorkCommand>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IJwtHandler, JwtHandler>();
    }
}

