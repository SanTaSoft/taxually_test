using System.Xml.Serialization;

using Taxually.TechnicalTest.Requests;

namespace Taxually.TechnicalTest.VatRegistrator.VatRegistrationWriters
{
    public class XmlVatRegistrationWriter : IVatRegistrationWriter
    {
        public async Task<VatResult> WriteVatRegistration(VatRegistrationRequest request)
        {
            try
            {
                using (var stringwriter = new StringWriter())
                {
                    var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                    serializer.Serialize(stringwriter, request);
                    var xml = stringwriter.ToString();
                    var xmlQueueClient = new TaxuallyQueueClient();
                    // Queue xml doc to be processed
                    await xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);
                    return VatResult.Success;
                }
            }
            catch (Exception)
            {
                return VatResult.Error;
            }

        }
    }
}
