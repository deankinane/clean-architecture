using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contacts.Commands.SendSmsToContact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/Contacts/{contactId}/[controller]")]
    [Authorize]
    public class SmsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> SendSmsToContact(SendSmsToContactCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}