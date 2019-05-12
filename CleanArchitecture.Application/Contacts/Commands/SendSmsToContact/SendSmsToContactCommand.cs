using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Contacts.Commands.SendSmsToContact
{
    public class SendSmsToContactCommand : IRequest<bool>
    {
        public int ContactId { get; set; }
        public string fromNumber { get; set; }
        public string toNumber { get; set; }
        public string message { get; set; }
    }
}
