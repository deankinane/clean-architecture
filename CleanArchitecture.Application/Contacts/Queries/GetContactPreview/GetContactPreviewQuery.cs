using CleanArchitecture.Application.Contacts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Contacts.Queries.GetContactPreview
{
    public class GetContactPreviewQuery : IRequest<ContactPreviewDto>
    {
        public int ContactId { get; set; }
    }
}
