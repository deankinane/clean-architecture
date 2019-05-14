using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;

namespace CleanArchitecture.Application.Infrastructure
{
    public static class ConfigureDependencyInjection
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
        }
    }
}
