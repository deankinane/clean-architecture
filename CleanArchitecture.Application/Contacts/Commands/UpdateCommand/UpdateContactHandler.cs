using CleanArchitecture.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CleanArchitecture.Application.Contacts.Commands.UpdateCommand
{
    public class UpdateContactHandler : RequestHandlerBase<UpdateContactCommand>
    {
        public UpdateContactHandler(IDatabaseDbContext context) : base(context) { }

        public override async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contactToUpdate = await _context.Contacts
                .AsNoTracking()
                .Where(x => x.ContactId == request.ContactId)
                .DefaultIfEmpty(null)
                .FirstOrDefaultAsync();

            if (contactToUpdate == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            var contact = Mapper.Map<Contact>(request);

            _context.Contacts.Update(contact);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
