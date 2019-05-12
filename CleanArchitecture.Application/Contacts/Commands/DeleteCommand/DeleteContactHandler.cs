using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
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
        public DeleteContactHandler(IDatabaseDbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contactToDelete = await _context.Contacts.FindAsync(request.ContactId);

            if (contactToDelete == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            contactToDelete.SoftDeleted = true;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
