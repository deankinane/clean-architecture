﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CleanArchitecture.Persistence
{
    public class ContextFactoryForMigrations : IDesignTimeDbContextFactory<DatabaseDbContext>
    {
        public DatabaseDbContext CreateDbContext(string[] args)
        {
            var devConnString = "Server=localhost\\sqlexpress;Database=CleanArchitectureDB;Trusted_Connection=True;";
            
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseDbContext>();
            optionsBuilder.UseSqlServer(devConnString,
                b => b.MigrationsAssembly(typeof(ContextFactoryForMigrations).GetTypeInfo().Assembly.GetName().Name));

            return new DatabaseDbContext(optionsBuilder.Options);
        }
    }
}