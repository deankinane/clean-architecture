using CleanArchitecture.Application.Contacts.Queries.Models;
using CleanArchitecture.Application.Contacts.Queries.QueryObjects;
using CleanArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Queries.GetAllContactPreview
{
    public class GetAllContactPreviewHandler : IRequestHandler<GetAllContactPreviewQuery, IEnumerable<ContactPreviewDto>>
    {
        private DatabaseDbContext _context;

        public GetAllContactPreviewHandler(DatabaseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactPreviewDto>> Handle(GetAllContactPreviewQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contacts
                .AsNoTracking()
                .ToContactPreviewDto()
                .ToListAsync(cancellationToken);
        }
    }
}
