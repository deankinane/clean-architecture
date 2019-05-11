using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Contacts.Commands.UpdateCommand
{
    public class UpdateContactValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactValidator()
        {
            RuleFor(x => x.ContactId)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(x => x.DateOfBirth)
                .NotNull()
                .Must(x => x > DateTime.Parse("01/01/1900"));
        }
    }
}
