using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Contacts.Queries.GetAllContacts;
using CleanArchitecture.Application.Contacts.QueryObjects;
using CleanArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Queries.GetAllContactPreview
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactPreviewDto>>
    {
        private DatabaseDbContext _context;

        public GetAllContactsHandler(DatabaseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactPreviewDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contacts
                .AsNoTracking()
                .ToContactPreviewDto()
                .ToListAsync(cancellationToken);
        }
    }
}
