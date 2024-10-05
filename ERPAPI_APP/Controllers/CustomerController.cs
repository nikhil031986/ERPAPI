using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly IConfiguration _configuration;

        public CustomerController(ILogger<CustomerController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("GetCustomer")]
        public async Task<List<GetCustomer>> GetCustomer()
            => await DataBaseAccess.DBACustomer.GetCustomer();

        [HttpGet("GetCustomerById")]
        public async Task<GetCustomer> GetCustomerById(int customerId)
            => await DataBaseAccess.DBACustomer.GetCustomerById(customerId);
    }
}
