using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.DbContext;

public class ApplicationContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<City> Cities { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Title = "Lion" },
            new City { Id = 2, Title = "Varanasi" },
            new City { Id = 3, Title = "Rama" }
        );
    }
}