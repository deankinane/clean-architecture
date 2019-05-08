using CleanArchitecture.Application.Contacts.Models;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Application.Contacts.QueryObjects
{
    public static class MapToContactPreviewDto
    {
        public static IQueryable<ContactPreviewDto> ToContactPreviewDto(this IQueryable<Contact> contacts)
        {
            return contacts.Select(c => new ContactPreviewDto()
            {
                ContactId = c.ContactId,
                DisplayName = $"{c.FirstName} {c.LastName}",
                DateOfBirth = c.DateOfBirth.ToString("dd/MM/yyyy"),
                NumTasks = c.Tasks.Count()
            });
        }
    }
}
