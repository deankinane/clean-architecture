using AutoMapper;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Contacts.Queries.GetAllContacts;
using CleanArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Queries.GetAllContactPreview
{
    public class GetAllContactsHandler : RequestHandlerBase, IRequestHandler<GetAllContactsQuery, IEnumerable<ContactPreviewDto>>
    {
        public GetAllContactsHandler(DatabaseDbContext context) : base(context) { }

        public async Task<IEnumerable<ContactPreviewDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _context.Contacts
                .AsNoTracking()
                .Include(x => x.Activities)
                .ToListAsync(cancellationToken);

            return Mapper.Map<List<ContactPreviewDto>>(contacts);
        }
    }
}
