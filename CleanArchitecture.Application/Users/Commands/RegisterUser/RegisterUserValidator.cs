using FluentValidation;
using CleanArchitecture.Application.Infrastructure.Validators;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Users.Commands.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.Username)
                .MustHaveValidEmailAddressFormat();

            RuleFor(x => x.Password)
                .MustBeStrongPassword();
        }
    }
}
