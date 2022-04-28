using Lila.BLL.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Lila.Desktop;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureService(IServiceCollection services)
    {
        services.ConfigureBllService(Configuration.GetConnectionString("DefaultConnection"));
    }
}