using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Contacts.QueryObjects;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using System.Linq;

namespace CleanArchitecture.Application.Contacts.Queries.GetContact
{
    public class GetContactHandler : IRequestHandler<GetContactQuery, ContactDto>
    {
        private DatabaseDbContext _context;

        public GetContactHandler(DatabaseDbContext context)
        {
            _context = context;
        }

        public async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts
                .AsNoTracking()
                .Include(c => c.Tasks)
                .Where(x => x.ContactId == request.ContactId)
                .DefaultIfEmpty(null)
                .FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            return contact.ToContactDto();
        }
    }
}
