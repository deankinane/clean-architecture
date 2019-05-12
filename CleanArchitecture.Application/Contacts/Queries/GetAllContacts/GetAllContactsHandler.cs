using AutoMapper;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Contacts.Queries.GetAllContacts;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Queries.GetAllContactPreview
{
    public class GetAllContactsHandler : RequestHandlerBase<GetAllContactsQuery, IEnumerable<ContactPreviewDto>>
    {
        public GetAllContactsHandler(DatabaseDbContext context) : base(context) { }

        public override async Task<IEnumerable<ContactPreviewDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _context.Contacts
                .AsNoTracking()
                .Include(x => x.Activities)
                .ToListAsync(cancellationToken);

            return Mapper.Map<List<ContactPreviewDto>>(contacts);
        }
    }
}
