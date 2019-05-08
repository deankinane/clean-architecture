using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CleanArchitecture.Application.Contacts.Queries.GetContactPreview
{
    public class GetContactPreviewValidation : AbstractValidator<GetContactPreviewQuery>
    {
        public GetContactPreviewValidation()
        {
            RuleFor(q => q.ContactId).NotEmpty();
        }
    }
}
