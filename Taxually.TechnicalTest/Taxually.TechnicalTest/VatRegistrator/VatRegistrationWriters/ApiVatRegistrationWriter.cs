using Taxually.TechnicalTest.Requests;

namespace Taxually.TechnicalTest.VatRegistrator.VatRegistrationWriters
{
    public class ApiVatRegistrationWriter : IVatRegistrationWriter
    {
        public async Task<VatResult> WriteVatRegistration(VatRegistrationRequest request)
        {
            try
            {
                var httpClient = new TaxuallyHttpClient();
                await httpClient.PostAsync("https://api.uktax.gov.uk", request);
                return VatResult.Success;
            }
            catch (Exception)
            {
                return VatResult.Error;
            }
        }
    }
}
