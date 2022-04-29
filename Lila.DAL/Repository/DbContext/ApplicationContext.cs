using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.DbContext;

public sealed class ApplicationContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<City> Cities => Set<City>();
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<City>().ToTable("City");
    }
}