using Taxually.TechnicalTest.Requests;
using Taxually.TechnicalTest.VatRegistrator.VatRegistrationDataFactories;

namespace Taxually.TechnicalTest.VatRegistrator.VatRegistrationWriters
{
    public class XmlVatRegistrationWriter : IVatRegistrationWriter
    {
        private readonly XmlVatRegistrationDataFactory _xmlVatRegistrationDataFactory;

        public XmlVatRegistrationWriter()
        {
            _xmlVatRegistrationDataFactory = new XmlVatRegistrationDataFactory();
        }

        public async Task<VatResult> WriteVatRegistration(VatRegistrationRequest request)
        {
            try
            {
                var xml = _xmlVatRegistrationDataFactory.CreateVatRegistrationData(request);
                var xmlQueueClient = new TaxuallyQueueClient();
                // Queue xml doc to be processed
                await xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);
                return VatResult.Success;
            }
            catch (Exception)
            {
                return VatResult.Error;
            }

        }
    }
}
