using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Infrastructure.Validators
{
    public static class EmailValidator
    {
        public static IRuleBuilderOptions<T, string> MustHaveValidEmailAddressFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

            return ruleBuilder
                .Matches(emailPattern)
                .WithMessage("Email address format is not valid");
        }
    }
}
