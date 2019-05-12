using CleanArchitecture.Adapters.SmsService.Providers;
using CleanArchitecture.Application.Interfaces.SmsService;

namespace CleanArchitecture.Adapters.SmsService
{
    public class SmsService : ISmsService
    {
        public bool SendMessage(SmsAccountDetials account, string fromNumber, string toNumber, string message)
        {
            bool result = false;

            switch (account.Provider)
            {
                case SmsServiceProvider.Esendex:
                    result = EsendexSmsProvider.SendMessage(account.AccountNumber, fromNumber, fromNumber, message);
                    break;
                case SmsServiceProvider.Vodafone:
                    result = VodafoneSmsProvider.SendMessage(account.AccountNumber, fromNumber, fromNumber, message);
                    break;
            }

            return true;
        }
    }
}
