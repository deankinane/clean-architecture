using CleanArchitecture.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using AutoMapper;
using CleanArchitecture.Application.Infrastructure;

namespace CleanArchitecture.Application.Contacts.Commands.UpdateCommand
{
    public class UpdateContactHandler : RequestHandlerBase<UpdateContactCommand>
    {
        public UpdateContactHandler(DatabaseDbContext context) : base(context) { }

        public override async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contactToUpdate = await _context.Contacts.FindAsync(request.ContactId);

            if (contactToUpdate == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            var contact = Mapper.Map<Contact>(request);

            _context.Entry(contactToUpdate).CurrentValues.SetValues(contact);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
