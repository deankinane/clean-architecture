using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Contacts.DTOs
{
    public class ContactPreviewDto
    {
        public int ContactId { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public int NumberOfActivities { get; set; }
    }
}
