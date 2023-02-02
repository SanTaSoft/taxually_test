using Taxually.TechnicalTest.VatRegistrator;
using Taxually.TechnicalTest.Requests;

namespace Taxually.TechicalTest.Tests
{
    public class VatRegistrationValidatorTests
    {
        [Theory]
        [MemberData(nameof(Test_Data))]
        public void ValidVatRequest_ReturnsVatValidationSuccess(VatRegistrationRequest request)
        {
            // Arrange
            var validator = new VatRegistrationValidator();

            // Act
            var result = validator.ValidateVatRegistration(request);

            // Assert
            result.Should().Be(VatValidationResult.Success);
        }

        [Theory]
        [MemberData(nameof(Invalid_Test_Data))]
        public void InvalidVatRequest_ReturnsVatCalidationError(VatRegistrationRequest request, VatValidationResult expectedResult)
        {
            // Arrange
            var validator = new VatRegistrationValidator();

            // Act
            var result = validator.ValidateVatRegistration(request);

            // Assert
            result.Should().Be(expectedResult);
        }

        private static IEnumerable<object[]> Invalid_Test_Data()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new VatRegistrationRequest
                    {
                        CompanyId = null,
                        CompanyName = "MyCompany",
                        Country = "DE"
                    },
                    VatValidationResult.BadCompanyId
                },
                new object[]
                {
                    new VatRegistrationRequest
                    {
                        CompanyName = null,
                        CompanyId = "1234",
                        Country = "GB"
                    },
                    VatValidationResult.BadCompanyName
                },
                new object[]
                {
                    new VatRegistrationRequest
                    {
                        CompanyId = "",
                        CompanyName = "MyCompany",
                        Country = "FR"
                    },
                    VatValidationResult.BadCompanyId
                },
                new object[]
                {
                    new VatRegistrationRequest
                    {
                        CompanyId = "12345",
                        CompanyName = "",
                        Country = "FR"
                    },
                    VatValidationResult.BadCompanyName
                },
                new object[]
                {
                    new VatRegistrationRequest
                    {
                        CompanyId = "2345",
                        CompanyName = "MyCompany",
                        Country = "HU"
                    },
                    VatValidationResult.UnknownCountry
                }
            };
        }


        private static IEnumerable<object[]> Test_Data()
        {
            return new List<object[]>
            {
                new object[] {
                    new VatRegistrationRequest
                    {
                        CompanyId = "12345",
                        CompanyName = "MyCompany",
                        Country = "DE"
                    }
                },
                new object[] {
                    new VatRegistrationRequest
                    {
                        CompanyId = "1",
                        CompanyName = "MyCompany",
                        Country = "GB"
                    }
                },
                new object[] {
                    new VatRegistrationRequest
                    {
                        CompanyId = "123451212121928078976kjhds897faskj324",
                        CompanyName = "M",
                        Country = "FR"
                    }
                }
            };
        }
    }
}