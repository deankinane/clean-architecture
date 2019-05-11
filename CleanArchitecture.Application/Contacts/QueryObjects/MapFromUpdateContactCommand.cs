using CleanArchitecture.Application.Contacts.Commands.UpdateCommand;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Application.Contacts.QueryObjects
{
    public static class MapFromUpdateContactCommand
    {
        public static Contact FromUpdateContactCommand(this UpdateContactCommand contact)
        {
            return new Contact()
            {
                ContactId = contact.ContactId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                DateOfBirth = contact.DateOfBirth
            };
        }

        public static IQueryable<Contact> FromUpdateContactCommand(this IQueryable<UpdateContactCommand> contacts)
        {
            return contacts.Select(x => x.FromUpdateContactCommand());
        }
    }
}
