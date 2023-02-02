using Taxually.TechnicalTest.Requests;

namespace Taxually.TechnicalTest.VatRegistrator.VatRegistrationWriters
{
    public interface IVatRegistrationWriter
    {
        Task<VatResult> WriteVatRegistration(VatRegistrationRequest request);
    }
}
