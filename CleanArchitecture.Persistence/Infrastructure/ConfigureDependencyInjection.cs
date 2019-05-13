using CleanArchitecture.Persistence.DbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence.Infrastructure
{
    public static class ConfigureDependencyInjection
    {
        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
        {
            var connString = config["ConnectionString"];
            services.AddDbContext<IDatabaseDbContext, DatabaseDbContext>(o => o.UseSqlServer(connString));
            services.AddTransient<IDbAccess, DbAccess.DbAccess>();
        }
    }
}
