using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Contacts.Models
{
    public class ContactUpdateDto
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
