using Taxually.TechnicalTest.VatRegistrator.VatRegistrationWriters;

namespace Taxually.TechnicalTest.VatRegistrator
{
    public interface IVatRegistrationWriterFactory
    {
        IVatRegistrationWriter? GetOrCreateRegistrationWriter(string countryCode);
    }
}