using CleanArchitecture.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contacts.QueryObjects;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contacts.Commands.UpdateCommand
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand>
    {
        private DatabaseDbContext _context;

        public UpdateContactHandler(DatabaseDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contactToUpdate = await _context.Contacts.FindAsync(request.ContactId);

            if (contactToUpdate == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            var contact = request.FromUpdateContactCommand();

            _context.Entry(contactToUpdate).CurrentValues.SetValues(contact);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
