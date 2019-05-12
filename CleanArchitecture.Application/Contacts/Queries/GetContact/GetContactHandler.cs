using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Persistence;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using AutoMapper;
using CleanArchitecture.Application.Infrastructure;

namespace CleanArchitecture.Application.Contacts.Queries.GetContact
{
    public class GetContactHandler : RequestHandlerBase<GetContactQuery, ContactDto>
    {
        public GetContactHandler(DatabaseDbContext context) : base(context) { }

        public override async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts
                .FindAsync(request.ContactId);

            if (contact == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            return Mapper.Map<ContactDto>(contact);
        }
    }
}