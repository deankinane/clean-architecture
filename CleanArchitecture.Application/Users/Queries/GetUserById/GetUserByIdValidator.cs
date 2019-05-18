using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Users.Queries.GetUserById
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}
