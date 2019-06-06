using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Lookups;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    public class DatabaseDbContext : IdentityDbContext<User>
    {
        // Entities
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Activity> Activities { get; set; }

        // Lookups
        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseDbContext).Assembly);
        }
    }
}
