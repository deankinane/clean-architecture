using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CleanArchitecture.Application.Contacts.Queries.Models
{
    public class ContactPreviewDto
    {
        public int ContactId { get; set; }
        public string DisplayName { get; set; }
        public string DateOfBirth { get; set; }
        public int NumTasks { get; set; }
    }
}
