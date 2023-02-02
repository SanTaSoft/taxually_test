using System.Configuration;

using Taxually.TechnicalTest.VatRegistrator;

namespace Taxually.TechicalTest.Tests
{
    public class VatRegistrationWriterFactoryTests
    {
        [Theory]
        [InlineData(new object[] { "DE" })]
        [InlineData(new object[] { "GB" })]
        [InlineData(new object[] { "FR" })]
        [InlineData(new object[] { "de" })]
        [InlineData(new object[] { "Gb" })]
        [InlineData(new object[] { "fR" })]
        public void ValidCountry_ReturnsValidWriter(string countryCode)
        {
            // Arrange
            var vatRegistrationFactory = new VatRegistrationFactory();

            // Act
            var result = vatRegistrationFactory.GetOrCreateRegistrationWriter(countryCode);

            // Assert
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData(new object[] { "" })]
        [InlineData(new object[] { null })]
        public void InvalidCountry_ReturnsNull(string countryCode)
        {
            // Arrange 
            var vatRegistrationFactory = new VatRegistrationFactory();

            // Act
            var result = vatRegistrationFactory.GetOrCreateRegistrationWriter(countryCode);

            // Assert
            result.Should().BeNull();
        }
    }
}
