using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddOnController : ControllerBase
    {
        private readonly ILogger<AddOnController> _logger;
        private readonly IConfiguration _configuration;

        public AddOnController(ILogger<AddOnController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetAddOn")]
        public async Task<List<GetAddOnData>> GetAddOn()
            => await DataBaseAccess.DAAddon.GetAddOnDetails();
    }
}
