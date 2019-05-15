using CleanArchitecture.Persistence.DbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence.Infrastructure
{
    public static class ConfigureDependencyInjection
    {
        public static void ConfigureDBContext(this IServiceCollection services, string connString)
        {
            services.AddDbContext<DatabaseDbContext>(o => o.UseSqlServer(connString));
            services.AddTransient<IDbAccess, DbAccess.DbAccess>();
        }
    }
}
