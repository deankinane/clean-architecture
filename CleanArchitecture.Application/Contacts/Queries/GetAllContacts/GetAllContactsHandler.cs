using AutoMapper;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.DbAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Queries.GetAllContacts
{
    public class GetAllContactsHandler : RequestHandlerBase<GetAllContactsQuery, List<ContactPreviewDto>>
    {
        public GetAllContactsHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<List<ContactPreviewDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _db.Contacts.GetAll();

            return _mapper.Map<List<ContactPreviewDto>>(contacts);
        }
    }
}
