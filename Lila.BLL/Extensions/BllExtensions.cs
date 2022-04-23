using Lila.BLL.Services;
using Lila.BLL.Services.Interfaces;
using Lila.DAL.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lila.BLL.Extensions;

public static class BllExtensions
{
    public static void ConfigureCllService(this IServiceCollection services, string connectionString)
    {
        services.ConfigureDalServices(connectionString);
        services.AddScoped(typeof(ICityManager), typeof(CityManager));
    }
}