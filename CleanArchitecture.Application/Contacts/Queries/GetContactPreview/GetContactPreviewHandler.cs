using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contacts.Models;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
using MediatR;
using CleanArchitecture.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Contacts.QueryObjects;
using System.Linq;

namespace CleanArchitecture.Application.Contacts.Queries.GetContactPreview
{
    public class GetContactPreviewHandler : IRequestHandler<GetContactPreviewQuery, ContactPreviewDto>
    {
        private DatabaseDbContext _context;

        public GetContactPreviewHandler(DatabaseDbContext context)
        {
            _context = context;
        }

        public async Task<ContactPreviewDto> Handle(GetContactPreviewQuery request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts
                .AsNoTracking()
                .Include(c => c.Tasks)
                .ToContactPreviewDto()
                .FirstAsync(x => x.ContactId == request.ContactId);

            if(contact == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            return contact;
        }
    }
}
