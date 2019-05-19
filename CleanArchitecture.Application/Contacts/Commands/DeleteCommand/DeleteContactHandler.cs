using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Persistence.DbAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Commands.DeleteCommand
{
    public class DeleteContactHandler : RequestHandlerBase<DeleteContactCommand>
    {
        public DeleteContactHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            await _db.Contacts.Delete(request.ContactId);
            await _db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
