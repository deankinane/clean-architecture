using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contacts.DTOs;
using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Persistence.DbAccess;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contacts.Queries.GetContact
{
    public class GetContactHandler : RequestHandlerBase<GetContactQuery, ContactDto>
    {
        public GetContactHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _db.Contacts.GetById(request.ContactId);

            if (contact == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            return _mapper.Map<ContactDto>(contact);
        }
    }
}