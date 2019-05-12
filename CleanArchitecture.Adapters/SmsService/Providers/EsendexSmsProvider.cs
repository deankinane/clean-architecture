using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Adapters.SmsService.Providers
{
    public static class EsendexSmsProvider
    {
        public static bool SendMessage(string accountNumber, string fromNumber, string toNumber, string message)
        {
            // Send the messag
            return true;
        }
    }
}
