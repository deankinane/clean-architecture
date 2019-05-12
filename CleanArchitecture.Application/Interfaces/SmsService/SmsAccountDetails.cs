using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces.SmsService
{
    public class SmsAccountDetials
    {
        public string AccountNumber { get; set; }
        public SmsServiceProvider Provider { get; set; }
    }
}
