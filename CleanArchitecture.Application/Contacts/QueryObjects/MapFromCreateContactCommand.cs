using CleanArchitecture.Application.Contacts.Commands.CreateContact;
using CleanArchitecture.Domain.Entities;
using System.Linq;

namespace CleanArchitecture.Application.Contacts.QueryObjects
{
    public static class MapFromCreateContactCommand
    {
        public static Contact FromCreateContactCommand(this CreateContactCommand contact)
        {
            return new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                DateOfBirth = contact.DateOfBirth
            };
        }

        public static IQueryable<Contact> FromCreateContactCommand(this IQueryable<CreateContactCommand> contacts)
        {
            return contacts.Select(x => x.FromCreateContactCommand());
        }
    }
}
