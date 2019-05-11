using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistence
{
    public class ContextFactoryForMigrations : IDesignTimeDbContextFactory<DatabaseDbContext>
    {
        public DatabaseDbContext CreateDbContext(string[] args)
        {
            var devConnString = "Server=localhost;Database=CleanArchitectureDB;Trusted_Connection=True;";
            //var devConnString = "Server=DESKTOP-DC5S096\\SQLEXPRESS;Database=CleanArchitectureDB;Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseDbContext>();
            optionsBuilder.UseSqlServer(devConnString,
                b => b.MigrationsAssembly("CleanArchitecture.Persistence"));

            return new DatabaseDbContext(optionsBuilder.Options);
        }
    }
}