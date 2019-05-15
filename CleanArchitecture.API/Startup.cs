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
using CleanArchitecture.Adapters;
using CleanArchitecture.Persistence.Infrastructure;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CleanArchitecture.Persistence.DbAccess;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using CleanArchitecture.API.Settings;

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

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            // Add DbContext via extension method in application layer
            services.ConfigureDBContext(appSettings.ConnectionString);

            // Initialise AutoMapper mappings
            services.ConfigureAutoMapper();

            // Add Adapters
            services.RegisterAdapters();

            // Add Swagger Document
            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "v1";
                //document.ApiGroupNames = new[] { "1" };
            });

            // Add Authentication
            // configure jwt authentication
            var secret = appSettings.Secret;
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IDbAccess>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.Users.GetUserById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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
            app.UseAuthentication();

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
