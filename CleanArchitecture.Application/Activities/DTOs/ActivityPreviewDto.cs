using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Activities.DTOs
{
    public class ActivityPreviewDto
    {
        // These are mapped directly as the property name's match
        public int ActivityId { get; set; }
        public string Notes { get; set; }

        // This is flattened from ActivityType.Description property
        public string ActivityTypeDescription { get; set; }

        // This is flattened from Contact.GetFullName() method
        public string ContactFullName { get; set; }
    }
}
