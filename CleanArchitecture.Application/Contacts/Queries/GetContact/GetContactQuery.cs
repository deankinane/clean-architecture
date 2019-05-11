using CleanArchitecture.Application.Contacts.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Contacts.Queries.GetContact
{
    public class GetContactQuery : IRequest<ContactDto>
    {
        public int ContactId { get; set; }
    }
}
