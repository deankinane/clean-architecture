using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetActivityForContactValidator : AbstractValidator<GetActivityForContactQuery>
    {
        public GetActivityForContactValidator()
        {
            RuleFor(x => x.ContactId)
                .NotEmpty();
        }
    }
}
