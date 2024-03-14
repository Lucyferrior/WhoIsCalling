using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

namespace WebAPI.Extensions;

public static class ServicesExtensions
{
    public static void ConfigurePSQLContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("psqlConnection"));
        });
}