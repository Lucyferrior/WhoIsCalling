using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories;

public class RepositoryContext:DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Contact> Contacts { get; set; }
}