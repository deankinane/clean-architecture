using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using System.Linq;
using AutoMapper;

namespace CleanArchitecture.Application.Contacts.Queries.GetContact
{
    public class GetContactHandler : RequestHandlerBase, IRequestHandler<GetContactQuery, ContactDto>
    {

        public GetContactHandler(DatabaseDbContext context) : base(context) { }

        public async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
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