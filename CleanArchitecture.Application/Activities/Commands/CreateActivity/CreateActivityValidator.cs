using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityValidator()
        {
            RuleFor(x => x.ContactId)
                .NotEmpty();

            RuleFor(x => x.Notes)
                .NotEmpty();

            RuleFor(x => x.ActivityTypeId)
                .NotEmpty();
        }
    }
}
