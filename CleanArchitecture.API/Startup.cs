using System.Reflection;
using CleanArchitecture.API.Filters;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Application.Contacts.Queries.GetContact;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.Interfaces.SmsService;
using CleanArchitecture.Adapters.SmsService;

namespace CleanArchitecture.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Mediatr
            services.AddMediatR(typeof(GetContactHandler).GetTypeInfo().Assembly);  
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetContactValidator>());

            // Add DbContext via extension method in application layer
            services.ConfigureDBContext(Configuration);

            // Initialise AutoMapper mappings
            services.ConfigureAutoMapper();

            // Add Adapters
            services.AddTransient<ISmsService, SmsService>();

            // Add Swagger Document
            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "v1";
                //document.ApiGroupNames = new[] { "1" };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger(settings =>
            {
                settings.PostProcess = (document, request) =>
                {
                    document.Info.Title = "Clean Architecture API";
                };
            });
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
            });
        }
    }
}
