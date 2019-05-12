using CleanArchitecture.Domain.Lookups;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Notes { get; set; }
        public bool SoftDeleted { get; set; }

        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get;set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
