using Microsoft.AspNetCore.Mvc;

using Taxually.TechnicalTest.Requests;

namespace Taxually.TechnicalTest.VatRegistrator
{
    public class VatRegistrationService
    {
        private readonly IVatRegistrationWriterFactory _vatRegistrationWriterFactory;
        private readonly VatRegistrationValidator _vatRegistrationValidator;

        public VatRegistrationService(
            IVatRegistrationWriterFactory vatRegistrationWriterFactory,
            VatRegistrationValidator vatRegistrationValidator)
        {
            _vatRegistrationWriterFactory = vatRegistrationWriterFactory;
            _vatRegistrationValidator = vatRegistrationValidator;
        }

        public async Task<ActionResult> Invoke(VatRegistrationRequest request)
        {
            var validationResult = _vatRegistrationValidator.ValidateVatRegistration(request);
            if (validationResult is not VatValidationResult.Success)
            {
                return new BadRequestObjectResult(validationResult.ToString());
            }

#pragma warning disable CS8604 // Possible null reference argument.
            var vatRegistrationWriter = _vatRegistrationWriterFactory.GetOrCreateRegistrationWriter(request.Country);
#pragma warning restore CS8604 // Possible null reference argument.
            if (vatRegistrationWriter is null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            var vatResult = await vatRegistrationWriter.WriteVatRegistration(request);
            return vatResult == VatResult.Success ? new OkResult() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
