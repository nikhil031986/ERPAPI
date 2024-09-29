using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingOptionController : Controller
    {
        private readonly ILogger<BillingOptionController> _logger;
        private readonly IConfiguration _configuration;

        public BillingOptionController(ILogger<BillingOptionController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetBilling_Option")]
        public async Task<List<Models.BillingOption>> GetBilling_Option()
           => await DataBaseAccess.DABillingOption.GetBilling_Option();
    }
}
