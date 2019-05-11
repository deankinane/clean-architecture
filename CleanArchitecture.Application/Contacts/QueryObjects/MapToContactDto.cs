using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Application.Contacts.QueryObjects
{
    public static class MapToContactDto
    {
        public static ContactDto ToContactDto(this Contact contact)
        {
            return new ContactDto()
            {
                ContactId = contact.ContactId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                DateOfBirth = contact.DateOfBirth
            };
        }

        public static IQueryable<ContactDto> ToContactDto(this IQueryable<Contact> contacts)
        {
            return contacts.Select(c => c.ToContactDto());
        }
    }
}
