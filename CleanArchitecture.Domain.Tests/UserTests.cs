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
            var user = new User()
            {
                PasswordHash = new byte[64],
                PasswordSalt = new byte[128]
            };

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => user.CreatePasswordHash(password));
        }

        [Fact]
        public void CreatePasswordHash_Should_return_password_and_salt()
        {
            // Arrange
            var password = "password123";
            var user = new User();

            // Act
            user.CreatePasswordHash(password);

            // Assert
            Assert.NotNull(user.PasswordHash);
            Assert.Equal(64, user.PasswordHash.Length);

            Assert.NotNull(user.PasswordSalt);
            Assert.Equal(128, user.PasswordSalt.Length);
        }

        [Fact]
        public void VerifyPasswordHash_Should_throw_argument_exception_when_data_not_valid()
        {
            // Arrange
            var user = new User()
            {
                PasswordHash = new byte[64],
                PasswordSalt = new byte[128]
            };

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => user.VerifyPasswordHash(string.Empty));
        }

        [Fact]
        public void VerifyPasswordHash_Should_return_true_if_password_correct()
        {
            // Arrange
            var password = "password123";
            var user = new User();

            // Act
            user.CreatePasswordHash(password);
            var result = user.VerifyPasswordHash(password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPasswordHash_Should_return_false_if_password_incorrect()
        {
            // Arrange
            var password = "password123";
            var passwordWrong = "wrongpassword";
            var user = new User();

            // Act
            user.CreatePasswordHash(password);
            var result = user.VerifyPasswordHash(passwordWrong);

            // Assert
            Assert.False(result);
        }

    }
}
