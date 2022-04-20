using Lila.DAL.Repository;
using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lila.DAL.Extensions;

public static class DalExtensions
{
    public static void ConfigureDalServices(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<DbContext, ApplicationContext>();

        services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IRepository<City>, EfRepository<City>>();
        services.AddScoped<IRepository<Customer>, EfRepository<Customer>>();
        services.AddScoped<IRepository<CustomersCity>, EfRepository<CustomersCity>>();
        services.AddScoped<IRepository<Employee>, EfRepository<Employee>>();
        services.AddScoped<IRepository<Fleet>, EfRepository<Fleet>>();
        services.AddScoped<IRepository<MyOrder>, EfRepository<MyOrder>>();
        services.AddScoped<IRepository<OrdersService>, EfRepository<OrdersService>>();
        services.AddScoped<IRepository<OrdersTransport>, EfRepository<OrdersTransport>>();
        services.AddScoped<IRepository<Role>, EfRepository<Role>>();
        services.AddScoped<IRepository<Service>, EfRepository<Service>>();
        services.AddScoped<IRepository<Stage>, EfRepository<Stage>>();
        services.AddScoped<IRepository<Status>, EfRepository<Status>>();
        services.AddScoped<IRepository<Transport>, EfRepository<Transport>>();
        services.AddScoped<IRepository<TransportsKind>, EfRepository<TransportsKind>>();
        services.AddScoped<IRepository<User>, EfRepository<User>>();
        services.AddScoped<IRepository<UsersRole>, EfRepository<UsersRole>>();
    }
}