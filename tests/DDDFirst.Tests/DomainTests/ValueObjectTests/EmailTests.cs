using CSharpFunctionalExtensions;
using DDDFirst.Domain.Errors;
using DDDFirst.Domain.ValueObjects;

namespace DDDFirst.Tests.DomainTests.ValueObjectTests
{

    public class EmailTests
    {
        [Fact(DisplayName = "應該返回失敗，當值為空或空白時")]
        public void Create_ShouldReturnFailure_WhenValueIsNullOrEmpty()
        {
            // Arrange
            string email = "";

            // Act
            Result<Email> result = Email.Create(email);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CommonErrors.ValueIsNullOrEmpty, result.Error);
        }

        [Fact(DisplayName = "應該返回失敗，當值為無效的電子郵件時")]
        public void Create_ShouldReturnFailure_WhenValueIsInvalidEmail()
        {
            // Arrange
            string email = "invalid-email";

            // Act
            Result<Email> result = Email.Create(email);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CommonErrors.EmailError, result.Error);
        }

        [Fact(DisplayName = "應該返回成功，當值為有效的電子郵件時")]
        public void Create_ShouldReturnSuccess_WhenValueIsValidEmail()
        {
            // Arrange
            string email = "test@example.com";

            // Act
            Result<Email> result = Email.Create(email);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(email, result.Value.Value);
        }
    }
}
