using Taxually.TechnicalTest.VatRegistrator.VatRegistrationDataFactories;
using Taxually.TechnicalTest.VatRegistrator.VatRegistrationWriters;

namespace Taxually.TechnicalTest.VatRegistrator
{
    public class VatRegistrationFactory : IVatRegistrationWriterFactory
    {
        private readonly Dictionary<string, Func<IVatRegistrationWriter>> _vatRegistrationFuncs = new Dictionary<string, Func<IVatRegistrationWriter>>
        {
            ["DE"] = () => new XmlVatRegistrationWriter(),
            ["GB"] = () => new ApiVatRegistrationWriter(),
            ["FR"] = () => new ExcelVatRegistrationWriter()
        };

        public IVatRegistrationWriter? GetOrCreateRegistrationWriter(string countryCode)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
            {
                return null;
            }

            return _vatRegistrationFuncs.TryGetValue(countryCode.ToUpper(), out var vatRegistrationWriterFunc) ? vatRegistrationWriterFunc() : null;
        }
    }
}
