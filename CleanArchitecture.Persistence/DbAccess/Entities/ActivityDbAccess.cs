using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public class ActivityDbAccess : EntityDbAccessBase
    {
        public ActivityDbAccess(DatabaseDbContext context) : base(context)
        {
        }

        public async Task CreateActivty(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public async Task<Activity> GetActivity(int activityId)
        {
            var activity = await _context.Activities
                .FindAsync(activityId);

            if (activity == null)
            {
                throw new NotFoundException(nameof(Activity), activityId);
            }

            return activity;
        }

        public async Task<List<Activity>> GetActivitiesForContact(int contactId)
        {
            if(await _context.Contacts.FindAsync(contactId) == null)
            {
                throw new NotFoundException(nameof(Contact), contactId);
            }

            return await _context.Activities
                .AsNoTracking()
                .Include(x => x.ActivityType)
                .Include(x => x.Contact)
                .Where(x => x.ContactId == contactId)
                .ToListAsync();
        }
    }
}
