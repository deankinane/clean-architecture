using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Activities.Commands.CreateActivity;
using CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/Contacts/{contactId}/Activities")]
    [ApiController]
    public class ActivitiesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Activity>>> GetAllActivities([FromRoute] int contactId)
        {
            return Ok(await Mediator.Send(new GetAllActivitiesForContactQuery() { ContactId = contactId }));
        }

        [HttpGet("{activityId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivity([FromRoute] int contactId, [FromRoute] int activityId)
        {
            return Ok(await Mediator.Send(new GetActivityForContactQuery() {
                ContactId = contactId,
                ActivityId = activityId
            }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateActivity([FromRoute] int contactId, [FromBody] CreateActivityCommand command)
        {
            command.ContactId = contactId;
            return Ok(await Mediator.Send(command));
        }
    }
}