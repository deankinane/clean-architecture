using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base()
        {
        }

        public BadRequestException(string principalName, object principalKey, string dependentName, object dependentKey)
            : base($"Dependent entity \"{dependentName}\" ({dependentKey}) does not belong to principal entity \"{principalName}\" ({principalKey}).")
        {
        }
    }
}
