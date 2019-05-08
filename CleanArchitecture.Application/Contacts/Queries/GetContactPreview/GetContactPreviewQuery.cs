using CleanArchitecture.Application.Contacts.Queries.Models;
using MediatR;

namespace CleanArchitecture.Application.Contacts.Queries.GetContactPreview
{
    public class GetContactPreviewQuery : IRequest<ContactPreviewDto>
    {
        public int ContactId { get; set; }
    }
}
