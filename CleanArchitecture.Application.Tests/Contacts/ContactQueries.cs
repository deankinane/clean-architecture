using CleanArchitecture.Application.Contacts.Commands.CreateContact;
using CleanArchitecture.Application.Contacts.Commands.DeleteCommand;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Contacts.Queries.GetAllContacts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.Tests.Contacts
{
    public class ContactQueries : UnitTest
    {
        [Fact]
        public async Task GetAllContacts_Should_return_type_List_of_ContactPreviewDto()
        {
            // Arrange
            var query = new GetAllContactsQuery();
            var handler = new GetAllContactsHandler(dbAccess, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsType<List<ContactPreviewDto>>(result);
        }

        [Fact]
        public async Task GetAllContacts_Should_return_all_contacts()
        {
            // Arrange
            await ContactHelpers.SeedContacts(dbAccess, mapper);

            var query = new GetAllContactsQuery();
            var handler = new GetAllContactsHandler(dbAccess, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Collection(result,
                a =>
                {
                    Assert.Equal(1, a.ContactId);
                    Assert.Equal("Joe Bloggs", a.FullName);
                },
                b =>
                {
                    Assert.Equal(2, b.ContactId);
                    Assert.Equal("Sally Bloggs", b.FullName);
                }
            );
        }

        [Fact]
        public async Task GetAllContacts_Should_not_return_soft_deleted_contacts()
        {
            // Arrange
            await ContactHelpers.SeedContacts(dbAccess, mapper);

            var deleteClient = new DeleteContactCommand()
            {
                ContactId = 2
            };
            var deleteHandler = new DeleteContactHandler(dbAccess, mapper);
            await deleteHandler.Handle(deleteClient, CancellationToken.None);

            var query = new GetAllContactsQuery();
            var handler = new GetAllContactsHandler(dbAccess, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Collection(result,
                a =>
                {
                    Assert.Equal(1, a.ContactId);
                    Assert.Equal("Joe Bloggs", a.FullName);
                }
            );
        }
    }
}
