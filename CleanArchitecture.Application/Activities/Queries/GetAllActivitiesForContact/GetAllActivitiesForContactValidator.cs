using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetAllActivitiesForContactValidator : AbstractValidator<GetAllActivitiesForContactQuery>
    {
        public GetAllActivitiesForContactValidator()
        {
            RuleFor(x => x.ContactId)
                .NotEmpty();
        }
    }
}
