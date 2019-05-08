using CleanArchitecture.Application.Contacts.Queries.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Contacts.Queries.GetAllContactPreview
{
    public class GetAllContactPreviewQuery : IRequest<IEnumerable<ContactPreviewDto>>
    {
    }
}
