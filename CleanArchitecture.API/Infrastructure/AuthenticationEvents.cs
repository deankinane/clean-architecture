using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Infrastructure
{
    public class AuthenticationEvents : JwtBearerEvents
    {
        public override async Task TokenValidated(TokenValidatedContext context)
        {
            var userId = int.Parse(context.Principal.Identity.Name);
            var mediator = context.HttpContext.RequestServices.GetRequiredService<IMediator>();

            try
            {
                var user = await mediator.Send(new GetUserByIdQuery() { UserId = userId });
            }
            catch(NotFoundException e)
            {
                context.Fail(e.Message);
            }
        }
    }
}
