using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Contacts.Queries.Models;
using CleanArchitecture.Application.Contacts.Queries.QueryObjects;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
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
                .Where(x => x.ContactId == request.ContactId)
                .DefaultIfEmpty(null)
                .FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            return contact.ToContactPreviewDto();
        }
    }
}
