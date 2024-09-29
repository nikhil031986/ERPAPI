using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTermsController : ControllerBase
    {
        private readonly ILogger<PaymentTermsController> _logger;
        private readonly IConfiguration _configuration;

        public PaymentTermsController(ILogger<PaymentTermsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "PaymentTerms")]
        public async Task<List<PaymentTerm>> PaymentTerms()
           => await DataBaseAccess.DAPaymentTerms.GetPaymentTerms();
    }
}
