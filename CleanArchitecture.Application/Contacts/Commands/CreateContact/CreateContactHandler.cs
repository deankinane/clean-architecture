using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Commands.CreateContact
{
    public class CreateContactHandler : RequestHandlerBase, IRequestHandler<CreateContactCommand, int>
    {
        public CreateContactHandler(DatabaseDbContext context) : base(context) { }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var newContact = await _context.Contacts.AddAsync(Mapper.Map<Contact>(request), cancellationToken);
            await _context.SaveChangesAsync();
            return newContact.Entity.ContactId;
        }
    }
}
