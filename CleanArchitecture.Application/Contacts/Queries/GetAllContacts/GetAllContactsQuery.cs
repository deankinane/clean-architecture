using CleanArchitecture.Application.Contacts.DTOs;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Contacts.Queries.GetAllContacts
{
    public class GetAllContactsQuery : IRequest<IEnumerable<ContactPreviewDto>>
    {
    }
}
