using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Application.Interfaces.SmsService;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.DbAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contacts.Commands.SendSmsToContact
{
    public class SendSmsToContactHandler : RequestHandlerBase<SendSmsToContactCommand, bool>
    {
        private ISmsService _smsService;

        public SendSmsToContactHandler(IDbAccess db, IMapper mapper, ISmsService smsService) : base(db, mapper)
        {
            _smsService = smsService;
        }

        public override async Task<bool> Handle(SendSmsToContactCommand request, CancellationToken cancellationToken)
        {
            // Check contact id is valid
            var contact = await _db.Contacts.GetContactById(request.ContactId);

            // Get sms account detials from database
            var account = new SmsAccountDetials()
            {
                AccountNumber = "123456",
                Provider = SmsServiceProvider.Esendex
            };

            var sent = _smsService.SendMessage(account, request.fromNumber, request.toNumber, request.message);

            if (sent)
            {
                return false;
            }

            var activity = new Activity()
            {
                ContactId = request.ContactId,
                Notes = request.message,
                ActivityTypeId = 4
            };

            await _db.Activities.CreateActivty(activity);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
