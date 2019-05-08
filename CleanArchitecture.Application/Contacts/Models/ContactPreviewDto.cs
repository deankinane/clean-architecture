using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CleanArchitecture.Application.Contacts.Models
{
    public class ContactPreviewDto
    {
        public int ContactId { get; set; }
        public string DisplayName { get; set; }
        public string DateOfBirth { get; set; }
        public int NumTasks { get; set; }

        public static Expression<Func<Contact, ContactPreviewDto>> Projection
        {
            get
            {
                return c => new ContactPreviewDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    Products = c.Products.AsQueryable()
                        .Select(ProductPreviewDto.Projection)
                        .Take(5)
                        .OrderBy(p => p.ProductName)
                        .ToList()
                };
            }
        }
    }
}
