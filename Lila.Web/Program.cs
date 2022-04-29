using System.Text;
using Lila.BLL.DtoModels;
using Lila.BLL.Extensions;
using Lila.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();
builder.Services.AddMvc();
builder.Services.ConfigureBllService("Data source=/home/lila/RiderProjects/Lila/Db.sqlite");
var services = builder.Services;
 
var app = builder.Build();

app.Run(async context =>
{
    var loki = app.Services.GetService<ICityManager>(); 
    await context.Response.WriteAsync($": {loki?.Create(new CityDto() {Id = 5, Title = "Lion"})}");
});
 
app.Run();