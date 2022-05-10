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
        services.AddAuthentication("MyCookieAuth")
            .AddCookie("MyCookieAuth", options =>
            {
                options.Cookie.Name = "MyCookieAuth";
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("ForCourier",
                policy => policy.RequireClaim("Courier"));
            options.AddPolicy("ForDirector",
                policy => policy.RequireClaim("Director"));
            options.AddPolicy("ForOperator",
                policy => policy.RequireClaim("Operator"));
            options.AddPolicy("ForCustomer",
                policy => policy.RequireClaim("Customer"));
        });
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.Cookie.Name = ".MyApp.Session";
            options.IdleTimeout = TimeSpan.FromDays(7);
            options.Cookie.IsEssential = true;
        });
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
        app.UseSession();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
 
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
}