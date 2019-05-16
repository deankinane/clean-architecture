using CleanArchitecture.Application.Users.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserCommand : IRequest<UserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
