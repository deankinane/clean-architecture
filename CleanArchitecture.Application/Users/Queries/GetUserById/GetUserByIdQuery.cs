using CleanArchitecture.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }
    }
}
