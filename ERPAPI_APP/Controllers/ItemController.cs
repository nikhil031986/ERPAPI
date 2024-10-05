using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly ILogger<ItemController> _logger;
        private readonly IConfiguration _configuration;

        public ItemController(ILogger<ItemController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("GetItemCategory")]
        public async Task<List<ItemCategory>> GetItemCategory()
          => await DataBaseAccess.DAItems.GetItemCategory();
    }
}
