using AutoMapper;
using CleanArchitecture.Application.Contacts.Commands.CreateContact;
using CleanArchitecture.Persistence.DbAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Tests.Contacts
{
    public static class ContactHelpers
    {
        public static async Task SeedContacts(DbAccess dbAccess, IMapper mapper)
        {
            var createClient1 = new CreateContactCommand()
            {
                FirstName = "Joe",
                LastName = "Bloggs",
                DateOfBirth = DateTime.Parse("01/01/1980")
            };

            var createClient2 = new CreateContactCommand()
            {
                FirstName = "Sally",
                LastName = "Bloggs",
                DateOfBirth = DateTime.Parse("01/01/1980")
            };

            var createHandler = new CreateContactHandler(dbAccess, mapper);
            await createHandler.Handle(createClient1, CancellationToken.None);
            await createHandler.Handle(createClient2, CancellationToken.None);
        }
    }
}
