namespace Taxually.TechnicalTest.VatRegistrator
{
    public enum VatValidationResult
    {
        UnknownCountry = 1,
        BadCompanyName = 2,
        BadCompanyId = 3,
        EmptyRequest = 4,
        Success = 5,
    }
}