using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Contacts.Commands.DeleteCommand
{
    public class DeleteContactValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactValidator()
        {
            RuleFor(x => x.ContactId)
                .NotEmpty();
        }
    }
}
