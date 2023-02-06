using Taxually.TechnicalTest.Requests;

namespace Taxually.TechnicalTest.VatRegistrator.VatRegistrationDataFactories
{
    public interface IVatRegistrationDataFactory<T>
    {
        T CreateVatRegistrationData(VatRegistrationRequest request);
    }
}
