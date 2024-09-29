using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLocationController : ControllerBase
    {
        private readonly ILogger<CustomerLocationController> _logger;
        private readonly IConfiguration _configuration;

        public CustomerLocationController(ILogger<CustomerLocationController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "Customer_Location")]
        public async Task<List<Models.GetCustomerLocation>> Customer_Location()
           => await DataBaseAccess.DACustomerLocation.GetCustomer_Location();
    }
}
