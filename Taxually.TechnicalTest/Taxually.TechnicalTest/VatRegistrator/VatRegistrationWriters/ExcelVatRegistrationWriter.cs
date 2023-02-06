using System.Text;

using Taxually.TechnicalTest.Requests;
using Taxually.TechnicalTest.VatRegistrator.VatRegistrationDataFactories;

namespace Taxually.TechnicalTest.VatRegistrator.VatRegistrationWriters
{
    public class ExcelVatRegistrationWriter : IVatRegistrationWriter
    {
        private readonly CsvVatRegistrationDataFactory _csvVatRegistrationDataFactory;

        public ExcelVatRegistrationWriter()
        {
            _csvVatRegistrationDataFactory = new CsvVatRegistrationDataFactory();
        }

        public async Task<VatResult> WriteVatRegistration(VatRegistrationRequest request)
        {
            try
            {
                var csv = _csvVatRegistrationDataFactory.CreateVatRegistrationData(request);
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
