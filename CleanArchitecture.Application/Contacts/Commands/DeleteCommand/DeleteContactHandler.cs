using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.DbAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Commands.DeleteCommand
{
    public class DeleteContactHandler : RequestHandlerBase<DeleteContactCommand>
    {
        public DeleteContactHandler(IDbAccess db) : base(db)
        {
        }

        public override async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            await _db.Contacts.DeleteContact(request.ContactId);
            await _db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
