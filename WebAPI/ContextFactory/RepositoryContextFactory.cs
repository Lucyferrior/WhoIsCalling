using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace WebAPI.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        //configurationBuilder
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        //dbContextOptionsBuilder
        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseNpgsql(configuration.GetConnectionString("psqlConnection"),
                prj=>prj.MigrationsAssembly("WebAPI"));

        return new RepositoryContext(builder.Options);
    }
}