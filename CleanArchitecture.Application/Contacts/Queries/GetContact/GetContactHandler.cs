using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Persistence;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Persistence.DbAccess;

namespace CleanArchitecture.Application.Contacts.Queries.GetContact
{
    public class GetContactHandler : RequestHandlerBase<GetContactQuery, ContactDto>
    {
        public GetContactHandler(IDbAccess db) : base(db)
        {
        }

        public override async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _db.Contacts.GetContact(request.ContactId);

            return Mapper.Map<ContactDto>(contact);
        }
    }
}