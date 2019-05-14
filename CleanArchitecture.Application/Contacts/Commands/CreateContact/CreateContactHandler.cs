using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DbAccess;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Commands.CreateContact
{
    public class CreateContactHandler : RequestHandlerBase<CreateContactCommand, int>
    {
        public CreateContactHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Contact>(request);

            await _db.Contacts.AddContact(contact);
            await _db.SaveChangesAsync();

            return contact.ContactId;
        }
    }
}
