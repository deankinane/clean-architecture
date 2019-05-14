using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contacts.DTOs;
using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Persistence.DbAccess;

namespace CleanArchitecture.Application.Contacts.Queries.GetContact
{
    public class GetContactHandler : RequestHandlerBase<GetContactQuery, ContactDto>
    {
        public GetContactHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _db.Contacts.GetContactById(request.ContactId);

            return _mapper.Map<ContactDto>(contact);
        }
    }
}