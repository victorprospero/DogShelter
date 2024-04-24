using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using DogShelter.Application;
using DogShelter.Infrastructure;
using DogShelter.Infrastructure.Contexts;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Globalization;
using System.Text;

namespace DogShelter.API
{
    public class Startup(IConfiguration configuration)
    {
        public readonly IConfiguration configuration = configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(config =>
            {
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddOptions();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMvc();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            
            //TODO: Resolve the mediator registration
            //builder.RegisterMediatR(GetType().Assembly);
            builder.RegisterAutoMapper(GetType().Assembly);
            builder.RegisterModule<DogShelterApplicationModule>();
            builder.RegisterModule<DogShelterInfrastructureModule>();
            //TODO: Resolve context as inmemory database
            //builder.RegisterType<DogShelterContext>().WithParameter("options", Configuration.GetMongoOptions("DefaultConnection")).InstancePerLifetimeScope();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseForwardedHeaders();
            List<CultureInfo> supportedCultures = new()
            {
                new CultureInfo("pt-BR"),
                new CultureInfo("en-US")
            };
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseHttpsRedirection();

            //TODO: Implement security
            //app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}