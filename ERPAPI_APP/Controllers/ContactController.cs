using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IConfiguration _configuration;

        public ContactController(ILogger<ContactController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "Contacts")]
        public async Task<List<ContactDetails>> Contacts()
           => await DataBaseAccess.DAContact.Contacts();
    }
}
