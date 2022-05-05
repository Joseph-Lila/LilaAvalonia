using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.DAL.Repository.Repositories;
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
        services.AddScoped<IRepository<City>, CityRepository>();
        services.AddScoped<IRepository<Customer>, CustomerRepository>();
        services.AddScoped<IRepository<CustomersCity>, CustomersCityRepository>();
        services.AddScoped<IRepository<Employee>, EmployeeRepository>();
        services.AddScoped<IRepository<Fleet>, FleetRepository>();
        services.AddScoped<IRepository<MyOrder>, MyOrderRepository>();
        services.AddScoped<IRepository<OrdersService>, OrdersServiceRepository>();
        services.AddScoped<IRepository<OrdersTransport>, OrdersTransportRepository>();
        services.AddScoped<IRepository<Role>, RoleRepository>();
        services.AddScoped<IRepository<Service>, ServiceRepository>();
        services.AddScoped<IRepository<Stage>, StageRepository>();
        services.AddScoped<IRepository<Status>, StatusRepository>();
        services.AddScoped<IRepository<Transport>, TransportRepository>();
        services.AddScoped<IRepository<TransportsKind>, TransportsKindRepository>();
        services.AddScoped<IRepository<User>, UserRepository>();
        services.AddScoped<IRepository<UsersRole>, UsersRoleRepository>();
    }
}