using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool SoftDeleted { get; set; }

        // Declare related collections with a private set 
        public ICollection<Activity> Activities { get; private set; }

        // Initialise all collections in constructor so we never have to worry if 
        // they've been intialised or not elsehwhere in the code
        public Contact()
        {
            Activities = new HashSet<Activity>();
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public int GetNumberOfActivities()
        {
            return Activities.Count;
        }
    }
}
