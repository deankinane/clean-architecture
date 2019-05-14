using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public class ContactDbAccess : EntityDbAccessBase
    {
        public ContactDbAccess(DatabaseDbContext context) : base(context)
        {
        }

        public Task<List<Contact>> GetAllContacts()
        {
            return _context.Contacts
                .AsNoTracking()
                .Include(x => x.Activities)
                .ToListAsync();
        }

        public async Task<Contact> GetContactById(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);

            if (contact == null)
            {
                throw new NotFoundException(nameof(Contact), contact.ContactId);
            }

            return contact;
        }

        public async Task AddContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            var contactToUpdate = await _context.Contacts
                .AsNoTracking()
                .Where(x => x.ContactId == contact.ContactId)
                .DefaultIfEmpty(null)
                .FirstOrDefaultAsync();

            if (contactToUpdate == null)
            {
                throw new NotFoundException(nameof(Contact), contact.ContactId);
            }

            _context.Contacts.Update(contact);
        }

        public async Task DeleteContact(int contactId)
        {
            var contactToDelete = await _context.Contacts.FindAsync(contactId);

            if (contactToDelete == null)
            {
                throw new NotFoundException(nameof(Contact), contactId);
            }

            contactToDelete.SoftDeleted = true;
        }

        
    }
}
