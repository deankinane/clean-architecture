using CleanArchitecture.Application.Contacts.Commands.CreateContact;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.Tests.Contacts
{
    public class ContactCommands : UnitTest
    {
        [Fact]
        public async Task CreateContactCommand_Should_add_contact_and_return_id()
        {
            // Arrange
            var command = new CreateContactCommand()
            {
                FirstName = "Joe",
                LastName = "Bloggs",
                DateOfBirth = DateTime.Parse("01/01/1980")
            };

            var handler = new CreateContactHandler(dbAccess, mapper);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(1, result);
        }

       

    }
}
