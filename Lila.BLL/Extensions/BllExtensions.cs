using Lila.BLL.Services;
using Lila.DAL.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lila.BLL.Extensions;

public static class BllExtensions
{
    public static void ConfigureBllService(this IServiceCollection services, string connectionString)
    {
        services.ConfigureDalServices(connectionString);
        services.AddScoped<LoginManager>();
    }
}