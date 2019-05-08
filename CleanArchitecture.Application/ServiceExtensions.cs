using CleanArchitecture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
        {
            var connString = config["ConnectionString"];
            services.AddDbContext<DatabaseDbContext>(o => o.UseSqlServer(connString));
        }
    }
}
