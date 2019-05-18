using CleanArchitecture.Adapters.SmsService.Providers;
using System;
using Xunit;

namespace CleanArchitecture.Adapters.Tests.SmsService
{
    public class EsendexSmsProviderTests
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
            var result = EsendexSmsProvider.SendMessage(accountNumber, fromNumber, toNumber, message);

            Assert.True(result);
        }
    }
}
