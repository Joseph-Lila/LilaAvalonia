using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.DbContext;

internal sealed class ApplicationContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<City> Cities => Set<City>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomersCity> CustomersCities => Set<CustomersCity>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Fleet> Fleets => Set<Fleet>();
    public DbSet<MyOrder> MyOrders => Set<MyOrder>();
    public DbSet<OrdersService> OrdersServices => Set<OrdersService>();
    public DbSet<OrdersTransport> OrdersTransports => Set<OrdersTransport>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Stage> Stages => Set<Stage>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<Transport> Transports => Set<Transport>();
    public DbSet<TransportsKind> TransportsKinds => Set<TransportsKind>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UsersRole> UsersRoles => Set<UsersRole>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<City>().ToTable("City");
        modelBuilder.Entity<Customer>().ToTable("Customer");
        modelBuilder.Entity<CustomersCity>().ToTable("CustomersCity");
        modelBuilder.Entity<Employee>().ToTable("Employee");
        modelBuilder.Entity<Fleet>().ToTable("Fleet");
        modelBuilder.Entity<MyOrder>().ToTable("MyOrder");
        modelBuilder.Entity<OrdersService>().ToTable("OrdersService");
        modelBuilder.Entity<OrdersTransport>().ToTable("OrdersTransport");
        modelBuilder.Entity<Role>().ToTable("Role");
        modelBuilder.Entity<Service>().ToTable("Service");
        modelBuilder.Entity<Stage>().ToTable("Stage");
        modelBuilder.Entity<Status>().ToTable("Status");
        modelBuilder.Entity<Transport>().ToTable("Transport");
        modelBuilder.Entity<TransportsKind>().ToTable("TransportsKind");
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<UsersRole>().ToTable("UsersRole");
    }
}