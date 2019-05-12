using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Adapters.SmsService.Providers
{
    public static class VodafoneSmsProvider
    {
        public static bool SendMessage(string accountNumber, string fromNumber, string toNumber, string message)
        {
            // Send the messag
            return true;
        }
    }
}
