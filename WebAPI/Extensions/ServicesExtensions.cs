using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contrats;
using Repositories.EFCore;
using Services;
using Services.Contrats;

namespace WebAPI.Extensions;

public static class ServicesExtensions
{
    public static void ConfigurePSQLContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("psqlConnection"));
        });

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
}