using System.Text;

using Taxually.TechnicalTest.Requests;

namespace Taxually.TechnicalTest.VatRegistrator.VatRegistrationWriters
{
    public class ExcelVatRegistrationWriter : IVatRegistrationWriter
    {
        public async Task<VatResult> WriteVatRegistration(VatRegistrationRequest request)
        {
            try
            {
                var csvBuilder = new StringBuilder();
                csvBuilder.AppendLine("CompanyName,CompanyId");
                csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
                var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
                var excelQueueClient = new TaxuallyQueueClient();
                // Queue file to be processed
                await excelQueueClient.EnqueueAsync("vat-registration-csv", csv);
                return VatResult.Success;
            }
            catch (Exception) 
            {
                return VatResult.Error;
            }
        }
    }
}
