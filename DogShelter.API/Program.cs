using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using DogShelter.Application;
using DogShelter.Infrastructure.Contexts;
using DogShelter.Infrastructure;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Reflection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using Microsoft.EntityFrameworkCore;
using DogShelter.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(config =>
{
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterMediatR(MediatRConfigurationBuilder.Create(Assembly.GetExecutingAssembly()).Build());
    containerBuilder.RegisterAutoMapper(Assembly.GetExecutingAssembly());
    containerBuilder.RegisterModule<DogShelterApplicationModule>();
    containerBuilder.RegisterModule<DogShelterInfrastructureModule>();
    containerBuilder.RegisterType<DogShelterContext>().WithParameter("options", new DbContextOptionsBuilder<DogShelterContext>().UseInMemoryDatabase("DogShelter").Options).InstancePerLifetimeScope();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
//TODO: Implement security
//app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();