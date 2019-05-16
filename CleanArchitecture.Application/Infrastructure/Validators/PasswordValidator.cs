using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Application.Infrastructure.Validators
{
    public static class PasswordValidator
    {
        public static IRuleBuilderOptions<T, string> MustBeStrongPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            HashSet<char> specialCharacters = new HashSet<char>() { '%', '$', '#', '!', '£', '*', '&', '<', '>', '?' };

            return ruleBuilder
                .MinimumLength(8)
                .Must(x => x.Any(char.IsLower))
                .Must(x => x.Any(char.IsUpper))
                .Must(x => x.Any(char.IsDigit))
                .Must(x => x.Any(specialCharacters.Contains))
                .WithMessage("Password is not strong enough");
        }
    }
}
