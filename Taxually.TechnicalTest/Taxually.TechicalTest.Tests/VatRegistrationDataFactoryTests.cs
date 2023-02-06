using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Taxually.TechnicalTest.Requests;
using Taxually.TechnicalTest.VatRegistrator.VatRegistrationDataFactories;

namespace Taxually.TechicalTest.Tests
{
    public class VatRegistrationDataFactoryTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ValidDERequest_CreatesCorrespondingData(string country, string companyId, string companyName)
        {
            // Arrange
            var xmlDataCreator = new XmlVatRegistrationDataFactory();
            var vatRegistrationRequest = new VatRegistrationRequest { CompanyId = companyId, CompanyName = companyName, Country = country };

            // Act
            var xml = xmlDataCreator.CreateVatRegistrationData(vatRegistrationRequest);
            using var stringReader = new StringReader(xml);
            var xmlObj = new XmlSerializer(typeof(VatRegistrationRequest)).Deserialize(stringReader);
            // Assert
            xmlObj.Should().BeEquivalentTo(vatRegistrationRequest);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ValidFRRequest_CreatesCorrespondingData(string country, string companyId, string companyName)
        {
            // Arrange
            var csvDataCreator = new CsvVatRegistrationDataFactory();
            var vatRegistrationRequest = new VatRegistrationRequest { CompanyId = companyId, CompanyName = companyName, Country = country };
            var expectedValue = $"CompanyName,CompanyId\r\n{companyName},{companyId}\r\n";

            // Act
            var csv = csvDataCreator.CreateVatRegistrationData(vatRegistrationRequest);

            // Assert
            csv.Should().BeEquivalentTo(Encoding.UTF8.GetBytes(expectedValue));
        }


        private static IEnumerable<object[]> TestData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    "DE",
                    "12345",
                    "MyCompany"
                }
            };
        }
    }
}
