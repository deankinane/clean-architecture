using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CleanArchitecture.Application.Contacts.Queries.GetContactPreview
{
    public class GetContactPreviewValidator : AbstractValidator<GetContactPreviewQuery>
    {
        public GetContactPreviewValidator()
        {
            RuleFor(q => q.ContactId).NotEmpty();
        }
    }
}
