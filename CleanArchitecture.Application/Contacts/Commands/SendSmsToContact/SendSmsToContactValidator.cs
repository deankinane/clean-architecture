using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Contacts.Commands.SendSmsToContact
{
    public class SendSmsToContactValidator : AbstractValidator<SendSmsToContactCommand>
    {
        public SendSmsToContactValidator()
        {
            RuleFor(x => x.ContactId)
                .NotEmpty();

            // ToDo Add custom validator for mobile phone numbers
            RuleFor(x => x.fromNumber)
                .NotEmpty();

            RuleFor(x => x.toNumber)
                .NotEmpty();

            RuleFor(x => x.message)
                .NotEmpty();
        }
    }
}
