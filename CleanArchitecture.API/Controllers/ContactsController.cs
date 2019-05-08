using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contacts.Queries.GetAllContactPreview;
using CleanArchitecture.Application.Contacts.Queries.GetContactPreview;
using CleanArchitecture.Application.Contacts.Queries.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    public class ContactsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContactPreviewDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllContactPreviewQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactPreviewDto>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetContactPreviewQuery() { ContactId = id }));
        }
    }
}