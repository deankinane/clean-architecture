using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DbAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddSignInManager<SignInManager<User>>()
                .AddEntityFrameworkStores<DatabaseDbContext>();
                
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
            });
        }
    }
}
