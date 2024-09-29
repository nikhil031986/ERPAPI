using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemShipViaController : ControllerBase
    {
        private readonly ILogger<SystemShipViaController> _logger;
        private readonly IConfiguration _configuration;

        public SystemShipViaController(ILogger<SystemShipViaController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "System_Ship_Vias")]
        public async Task<List<GetSystemShipVium>> System_Ship_Vias()
           => await DataBaseAccess.DASystemShipVia.GetSystemShipVias();
    }
}
