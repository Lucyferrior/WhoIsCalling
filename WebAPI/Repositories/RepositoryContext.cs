using Entities;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repositories.Config;

namespace WebAPI.Repositories;

public class RepositoryContext:DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContactConfig());
    }
}