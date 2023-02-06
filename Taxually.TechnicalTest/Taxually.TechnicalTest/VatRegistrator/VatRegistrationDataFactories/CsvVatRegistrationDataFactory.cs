using System.Text;

using Taxually.TechnicalTest.Requests;

namespace Taxually.TechnicalTest.VatRegistrator.VatRegistrationDataFactories
{
    public class CsvVatRegistrationDataFactory : IVatRegistrationDataFactory<IEnumerable<byte>>
    {
        public IEnumerable<byte> CreateVatRegistrationData(VatRegistrationRequest request)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{request.CompanyName},{request.CompanyId}");
            return Encoding.UTF8.GetBytes(csvBuilder.ToString());
        }
    }
}
