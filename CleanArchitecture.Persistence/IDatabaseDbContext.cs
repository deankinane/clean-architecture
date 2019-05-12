using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Lookups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    public interface IDatabaseDbContext
    {
        // Entities
        DbSet<Contact> Contacts { get; set; }
        DbSet<Activity> Activities { get; set; }

        // Lookups
        DbSet<ActivityType> ActivityTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
