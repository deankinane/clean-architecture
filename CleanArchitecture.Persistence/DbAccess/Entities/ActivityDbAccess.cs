using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public class ActivityDbAccess : EntityDbAccessBase<Activity>
    {
        public ActivityDbAccess(DatabaseDbContext context) : base(context)
        {
        }

        public async override Task Create(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public override Task<Activity> GetById(int activityId)
        {
            return _context.Activities
                .FindAsync(activityId);
        }

        public override Task<List<Activity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public override Task Update(Activity entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Activity>> GetActivitiesForContact(int contactId)
        {
            if (await _context.Contacts.FindAsync(contactId) == null)
            {
                return null;
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
