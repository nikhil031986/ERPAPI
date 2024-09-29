using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataMigrationOthersourcesController : ControllerBase
    {
        private readonly ILogger<DataMigrationOthersourcesController> _logger;
        private readonly IConfiguration _configuration;

        public DataMigrationOthersourcesController(ILogger<DataMigrationOthersourcesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "DataMigration")]
        public async Task<JsonResult> DataMigration()
        => await UtilObject.DataMigration();
    }
}
