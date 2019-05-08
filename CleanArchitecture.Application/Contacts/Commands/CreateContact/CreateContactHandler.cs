using CleanArchitecture.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Commands.CreateContact
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, int>
    {
        private DatabaseDbContext _context;

        public CreateContactHandler(DatabaseDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var newContact = await _context.Contacts.AddAsync(request, cancellationToken);
            return newContact.Entity.ContactId;
        }
    }
}
