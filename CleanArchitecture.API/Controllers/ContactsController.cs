using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contacts.Queries.GetContact;
using CleanArchitecture.Application.Contacts.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Contacts.Queries.GetAllContacts;
using CleanArchitecture.Application.Contacts.Commands.CreateContact;
using CleanArchitecture.Application.Contacts.Commands.UpdateCommand;
using CleanArchitecture.Application.Contacts.Commands.DeleteCommand;
using CleanArchitecture.Application.Contacts.Commands.SendSmsToContact;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ContactsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllContactsQuery()));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ContactDto>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetContactQuery() { ContactId = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateContact(CreateContactCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateContact(UpdateContactCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteContact(int id)
        {
            return Ok(await Mediator.Send(new DeleteContactCommand() { ContactId = id }));
        }
    }
}