using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Contacts.DTOs
{
    public class ContactPreviewDto
    {
        public int ContactId { get; set; }
        public string DisplayName { get; set; }
        public string DateOfBirth { get; set; }
        public int NumTasks { get; set; }
    }
}
