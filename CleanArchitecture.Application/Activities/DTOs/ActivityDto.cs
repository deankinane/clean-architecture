using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Activities.DTOs
{
    public class ActivityDto
    {
        public int ActivityId { get; set; }
        public string Notes { get; set; }
        public int ActivityTypeId { get; set; }
        public int ContactId { get; set; }
    }
}
