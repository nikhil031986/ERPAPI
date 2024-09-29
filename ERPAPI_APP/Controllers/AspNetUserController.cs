using ERPAPI_APP.DataBaseAccess;
using ERPAPI_APP.JSONDataMigration;
using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Formats.Asn1;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;

        public UserController(ILogger<UserController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("GetUsers")]
        public async Task<List<AspNetUserList>> GetUsers()
            => await DataBaseAccess.DBAUser.getUser();

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string EmailId, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EmailId) || string.IsNullOrWhiteSpace(password))
                {
                    return new JsonResult(new { message = "UserName and password not allow null or empty." })
                    {
                        StatusCode = StatusCodes.Status400BadRequest // Status code here 
                    };
                }
                //BMS.Models.Login loginData = await DataAccessModel.SingInProcess(userEmailId,password);
                var login = await DBAUser.Login(EmailId, password);
                if (login == null || string.IsNullOrWhiteSpace(login))
                {
                    return new JsonResult(new { message = "Usesr not found.." })
                    {
                        StatusCode = StatusCodes.Status400BadRequest // Status code here 
                    };
                }
                else
                {
                    if (login.ToString().ToUpper() == "CREATE NEW PASSWORD.")
                    {
                        return new JsonResult(new { message = "Create new password." })
                        {
                            StatusCode = StatusCodes.Status200OK, // Status code here ,
                        };
                    }
                    else if (login.ToString().ToUpper() == "USESR NOT FOUND..")
                    {
                        return new JsonResult(new { message = "Usesr not found.." })
                        {
                            StatusCode = StatusCodes.Status400BadRequest // Status code here 
                        };
                    }
                    else if (login.ToString().ToUpper() == "PASSWORD NOT MATCH.")
                    {
                        return new JsonResult(new { message = "Password not match." })
                        {
                            StatusCode = StatusCodes.Status400BadRequest // Status code here 
                        };
                    }
                    else
                    {
                        return new JsonResult(new { accessToken = login.ToString(),
                            user = new { EmailId = EmailId, roles ="Admin"}
                        })
                        {
                            StatusCode = StatusCodes.Status200OK, // Status code here ,
                        };
                    }
                }
            }
            catch (System.Exception)
            {
                //Response.StatusCode=StatusCodes.Status400BadRequest;
                return new JsonResult(new { message = "Not Allow" })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }
        }

        [HttpPost("SingUpUser")]
        public async Task<JsonResult> SingUpUser(SingUp singUp)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(singUp.emailId) || string.IsNullOrWhiteSpace(singUp.password))
                {
                    return new JsonResult(new { message = "UserName and password not allow null or empty." })
                    {
                        StatusCode = StatusCodes.Status400BadRequest // Status code here 
                    };
                }

                var UserExists = await UtilObject.erpDbContext.AspNetUsers.Where(x => x.EmailId == singUp.emailId).FirstOrDefaultAsync();

                if (UserExists != null)
                {
                    return new JsonResult(new { message = "EmailId already exists into the system." })
                    {
                        StatusCode = StatusCodes.Status400BadRequest // Status code here 
                    };
                }

                var newUser = await DBAUser.singUpUser(singUp);
                if (newUser != null)
                {
                    return new JsonResult(JsonConvert.SerializeObject(newUser))
                    {
                        StatusCode = StatusCodes.Status200OK, // Status code here ,
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Not Allow" })
                    {
                        StatusCode = StatusCodes.Status400BadRequest // Status code here 
                    };
                }
            }
            catch (Exception)
            {
                return new JsonResult(new { message = "Not Allow" })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<JsonResult> ChangePassword(UserDetails userDetails)
        {
            try
            {
                var login = await DBAUser.PasswordUpdate(userDetails.UserEmailId, userDetails.password);
                return new JsonResult(new { message = login})
                {
                    StatusCode = StatusCodes.Status200OK // Status code here 
                };

            }
            catch (Exception)
            {
                return new JsonResult(new { message = "Not Allow" })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }
        }
    }
}