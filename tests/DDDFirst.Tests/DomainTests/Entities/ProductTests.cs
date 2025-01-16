using DDDFirst.ValueObjects.Product;

namespace DDDFirst.Tests.DomainTests.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateCurrency()
        {
            // Arrange
            string code = "USD";
            decimal rate = 1.2m;

            // Act
            var currency = new Currency(code, rate);

            // Assert
            Assert.Equal(code, currency.Code);
            Assert.Equal(rate, currency.Rate);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidCode_ShouldThrowArgumentException(string invalidCode)
        {
            // Arrange
            decimal rate = 1.2m;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Currency(invalidCode, rate));
            Assert.Equal("代碼不能為空", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidRate_ShouldThrowArgumentException(decimal invalidRate)
        {
            // Arrange
            string code = "USD";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Currency(code, invalidRate));
            Assert.Equal("匯率必須大於0", exception.Message);
        }
    }
}
