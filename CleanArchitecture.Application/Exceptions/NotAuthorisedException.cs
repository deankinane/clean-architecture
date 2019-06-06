using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Exceptions
{
    public class NotAuthorisedException : Exception
    {
        public NotAuthorisedException() : base("Username or password is incorrect")
        {

        }
    }
}
