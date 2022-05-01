using Lila.BLL.Extensions;

namespace Lila.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.ConfigureBllService(Configuration.GetConnectionString("DefaultConnection")!);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
 
        app.UseHttpsRedirection();
        app.UseStaticFiles();
 
        app.UseRouting();
 
        app.UseAuthorization();
 
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
}