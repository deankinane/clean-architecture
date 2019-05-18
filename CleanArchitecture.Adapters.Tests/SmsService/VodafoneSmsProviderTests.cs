using CleanArchitecture.Adapters.SmsService.Providers;
using Xunit;

namespace CleanArchitecture.Adapters.Tests.SmsService
{
    public class VodafoneSmsProviderTests
    {
        [Fact]
        public void SendMessage_Should_return_true()
        {
            // Arrange
            var accountNumber = string.Empty;
            var fromNumber = string.Empty;
            var toNumber = string.Empty;
            var message = string.Empty;

            // Act
            var result = VodafoneSmsProvider.SendMessage(accountNumber, fromNumber, toNumber, message);

            Assert.True(result);
        }
    }
}
