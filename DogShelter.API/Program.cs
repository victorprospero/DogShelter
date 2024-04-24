using Autofac.Extensions.DependencyInjection;
using DogShelter.API;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureWebHostDefaults(webBuilder =>
{
    // error here
    webBuilder.UseStartup<Startup>();
});

var app = builder.Build();

//app.MapControllers();
app.Run();