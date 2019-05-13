﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Persistence.DbAccess;

namespace CleanArchitecture.Application.Contacts.Commands.UpdateCommand
{
    public class UpdateContactHandler : RequestHandlerBase<UpdateContactCommand>
    {
        public UpdateContactHandler(IDbAccess db) : base(db) { }

        public override async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = Mapper.Map<Contact>(request);

            await _db.Contacts.UpdateContact(contact);
            await _db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
