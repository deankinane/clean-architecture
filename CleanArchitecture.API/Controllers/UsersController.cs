using System.Threading.Tasks;
using CleanArchitecture.Application.Users.Commands.AuthenticateUser;
using CleanArchitecture.Application.Users.Commands.RegisterUser;
using CleanArchitecture.Application.Users.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UsersController : BaseController
    {
        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Authenticate([FromBody] AuthenticateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}