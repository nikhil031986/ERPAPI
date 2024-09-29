using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly ILogger<WarehouseController> _logger;
        private readonly IConfiguration _configuration;

        public WarehouseController(ILogger<WarehouseController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWarehouses")]
        public async Task<List<WarehouseMaster>> GetWarehouses()
           => await DataBaseAccess.DAWarehouse.GetWarehouses();
    }
}
