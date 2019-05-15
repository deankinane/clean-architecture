using CleanArchitecture.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Users.Commands
{
    public class AuthenticateUserCommand : IRequest<UserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
