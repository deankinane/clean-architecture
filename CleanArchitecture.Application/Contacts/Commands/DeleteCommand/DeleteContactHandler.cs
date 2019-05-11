using CleanArchitecture.Application.Exceptions;
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
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand>
    {
        private DatabaseDbContext _context;

        public DeleteContactHandler(DatabaseDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
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
