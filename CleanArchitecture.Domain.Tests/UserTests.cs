using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class UserTests
    {
        [Fact]
        public void CreatePasswordHash_Should_throw_argument_exception_when_string_empty()
        {
            // Arrange
            var password = string.Empty;
            byte[] passwordBytes;
            byte[] saltBytes;

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => User.CreatePasswordHash(password, out passwordBytes, out saltBytes));
        }

        [Fact]
        public void CreatePasswordHash_Should_return_password_and_salt()
        {
            // Arrange
            var password = "password123";
            byte[] passwordBytes;
            byte[] saltBytes;

            // Act
            User.CreatePasswordHash(password, out passwordBytes, out saltBytes);

            // Assert
            Assert.NotNull(passwordBytes);
            Assert.Equal(64, passwordBytes.Length);

            Assert.NotNull(saltBytes);
            Assert.Equal(128, saltBytes.Length);
        }

        [Fact]
        public void VerifyPasswordHash_Should_throw_argument_exception_when_data_not_valid()
        {
            // Arrange
            var password = "password123";
            byte[] bytes128 = new byte[128];
            byte[] bytes64 = new byte[64];
            byte[] bytes1 = new byte[1];

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => User.VerifyPasswordHash(string.Empty, bytes64, bytes128));
            Assert.Throws<ArgumentException>(() => User.VerifyPasswordHash(password, bytes1, bytes128));
            Assert.Throws<ArgumentException>(() => User.VerifyPasswordHash(password, bytes64, bytes1));
        }

        [Fact]
        public void VerifyPasswordHash_Should_return_true_if_password_correct()
        {
            // Arrange
            var password = "password123";
            byte[] passwordBytes;
            byte[] saltBytes;

            // Act
            User.CreatePasswordHash(password, out passwordBytes, out saltBytes);
            var result = User.VerifyPasswordHash(password, passwordBytes, saltBytes);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPasswordHash_Should_return_false_if_password_incorrect()
        {
            // Arrange
            var password = "password123";
            var passwordWrong = "wrongpassword";
            byte[] passwordBytes;
            byte[] saltBytes;

            // Act
            User.CreatePasswordHash(password, out passwordBytes, out saltBytes);
            var result = User.VerifyPasswordHash(passwordWrong, passwordBytes, saltBytes);

            // Assert
            Assert.False(result);
        }

    }
}
