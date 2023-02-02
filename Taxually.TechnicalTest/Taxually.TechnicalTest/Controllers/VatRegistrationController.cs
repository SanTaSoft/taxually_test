using Microsoft.AspNetCore.Mvc;

using Taxually.TechnicalTest.Requests;
using Taxually.TechnicalTest.VatRegistrator;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly VatRegistrationService registratrService;

        public VatRegistrationController(VatRegistrationService registratrService)
        {
            this.registratrService = registratrService;
        }
        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            return await registratrService.Invoke(request);
        }
    }
}
