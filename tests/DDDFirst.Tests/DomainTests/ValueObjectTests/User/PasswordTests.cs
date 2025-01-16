using DDDFirst.Domain.Interfaces.Utils;
using DDDFirst.Domain.ValueObjects.User;
using Moq;

namespace DDDFirst.Tests.DomainTests.ValueObjectTests.User
{
    public class PasswordTests
    {

        [Fact(DisplayName = "")]
        public void CreateHashedPassword_ShouldThrowArgumentException_WhenPasswordIsNullOrWhiteSpace()
        {
            // Arrange
            string password = string.Empty;
            var passwordHasherMock = new Mock<IPasswordHasher>();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Password.CreateHashedPassword(password, passwordHasherMock.Object));
            Assert.Equal("密碼不能為空", exception.Message);
        }

        [Fact]
        public void CreateHashedPassword_ShouldReturnPassword_WhenPasswordIsValid()
        {
            // Arrange
            string password = "validPa@ssword1";
            string hashedPassword = "hashedPa@ssword1";
            var passwordHasherMock = new Mock<IPasswordHasher>();
            passwordHasherMock.Setup(ph => ph.HashPassword(password)).Returns(hashedPassword);

            // Act
            var passwordObj = Password.CreateHashedPassword(password, passwordHasherMock.Object);

            // Assert
            Assert.Equal(hashedPassword, passwordObj.Value);
        }
    }
}
