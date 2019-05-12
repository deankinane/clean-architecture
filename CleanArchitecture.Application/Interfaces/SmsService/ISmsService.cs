using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces.SmsService
{
    public interface ISmsService
    {
        bool SendMessage(SmsAccountDetials account, string fromNumber, string toNumber, string message);
    }
}
