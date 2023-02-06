using System.Xml.Serialization;

using Taxually.TechnicalTest.Requests;

namespace Taxually.TechnicalTest.VatRegistrator.VatRegistrationDataFactories
{
    public class XmlVatRegistrationDataFactory : IVatRegistrationDataFactory<string>
    {
        public string CreateVatRegistrationData(VatRegistrationRequest request)
        {
            string? xml = null;
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                serializer.Serialize(stringwriter, request);
                xml = stringwriter.ToString();
            }
            return xml;
        }
    }
}
