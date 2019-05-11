using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Domain.Entities;
using System.Linq;

namespace CleanArchitecture.Application.Contacts.QueryObjects
{
    public static class MapToContactPreviewDto
    {
        public static ContactPreviewDto ToContactPreviewDto(this Contact contact)
        {
            return new ContactPreviewDto()
            {
                ContactId = contact.ContactId,
                DisplayName = $"{contact.FirstName} {contact.LastName}",
                DateOfBirth = contact.DateOfBirth.ToString("dd/MM/yyyy"),
                NumTasks = contact.Tasks.Count()
            };
        }

        public static IQueryable<ContactPreviewDto> ToContactPreviewDto(this IQueryable<Contact> contacts)
        {
            return contacts.Select(c => c.ToContactPreviewDto());
        }
    }
}
