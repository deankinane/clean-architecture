using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public class ContactDbAccess : EntityDbAccessBase<Contact>
    {
        public ContactDbAccess(DatabaseDbContext context) : base(context)
        {
        }

        public override Task<List<Contact>> GetAll()
        {
            return _context.Contacts
                .AsNoTracking()
                .Include(x => x.Activities)
                .ToListAsync();
        }

        public async override Task Delete(int contactId)
        {
            var contactToDelete = await _context.Contacts.FindAsync(contactId);
            contactToDelete.SoftDeleted = true;
        }        
    }
}
