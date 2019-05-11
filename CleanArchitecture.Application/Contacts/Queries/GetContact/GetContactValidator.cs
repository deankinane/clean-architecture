using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CleanArchitecture.Application.Contacts.Queries.GetContact
{
    public class GetContactValidator : AbstractValidator<GetContactQuery>
    {
        public GetContactValidator()
        {
            RuleFor(q => q.ContactId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
