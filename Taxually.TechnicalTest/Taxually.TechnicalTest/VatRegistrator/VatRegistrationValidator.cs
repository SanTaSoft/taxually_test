using Taxually.TechnicalTest.Requests;

namespace Taxually.TechnicalTest.VatRegistrator
{
    public class VatRegistrationValidator
    {
        private readonly string[] _validCountries = new string[] { "DE", "GB", "FR" };

        public VatValidationResult ValidateVatRegistration(VatRegistrationRequest? request)
        {
            if (request is null)
                return VatValidationResult.EmptyRequest;

            if (string.IsNullOrWhiteSpace(request.CompanyId))
                return VatValidationResult.BadCompanyId;

            if (string.IsNullOrWhiteSpace(request.CompanyName))
                return VatValidationResult.BadCompanyName;

            if (string.IsNullOrWhiteSpace(request.Country) ||
                !_validCountries.Contains(request.Country))
                return VatValidationResult.UnknownCountry;


            return VatValidationResult.Success;
        }
    }
}
