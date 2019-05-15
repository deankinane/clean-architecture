using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Users.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
