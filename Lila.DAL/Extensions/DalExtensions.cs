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
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    }
}