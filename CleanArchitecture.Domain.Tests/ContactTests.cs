using CleanArchitecture.Domain.Entities;
using System;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class ContactTests
    {
        [Fact]
        public void GetFullName_ShouldReturnFirstNameAndLastName()
        {
            var contact = new Contact()
            {
                FirstName = "Joe",
                LastName = "Bloggs"
            };

            var result = contact.GetFullName();

            Assert.Equal("Joe Bloggs", result);
        }

        [Fact]
        public void GetNumberOfActivities_ShouldReturnActivityCount()
        {
            var contact = new Contact();
            contact.Activities.Add(new Activity());

            var count = contact.GetNumberOfActivities();

            Assert.Equal(1, count);
        }

    }
}
