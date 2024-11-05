using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

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

        [HttpGet("GetItetmWiseCategory")]
        public async Task<List<ItemCategory>> GetItetmWiseCategory()
            => await DataBaseAccess.DAItems.GetItetmWiseCategory();

        [HttpGet("GetMenuItem")]
        public async Task<List<MasterMenu>> GetMenuItem()
        => await DataBaseAccess.DAItems.GetMenuItem();

        [HttpGet("ItemGetByCategory")]
        public async Task<List<ItemByCategory>> ItemGetByCategory(int categoryId)
            => await DataBaseAccess.DAItems.ItemGetByCategory(categoryId);

        [HttpGet("GetItemByItemCode")]
        public async Task<ItemByCategory> GetItemByItemCode(string ItemCode)
            => await DataBaseAccess.DAItems.GetItemByItemCode(ItemCode);

        [HttpGet("GetAllUnit")]
        public async Task<List<UnitMaster>> GetAllUnit()
            => await DataBaseAccess.DAItems.GetAllUnit();

        [HttpGet("GetIdFromCategoryName")]
        public async Task<JsonResult> GetIdFromCategoryName(string categoryName)
        {
            try
            {
                var id = await DataBaseAccess.DAItems.GetIdFromCategoryName(categoryName);
                if (id != null)
                {
                    return new JsonResult(new { message = Convert.ToString(id) })
                    {
                        StatusCode = StatusCodes.Status200OK, // Status code here ,
                    };
                }
                else
                {
                    return new JsonResult(new { message = "0" })
                    {
                        StatusCode = StatusCodes.Status200OK // Status code here 
                    };

                }
            }
            catch (Exception)
            {
                return new JsonResult(new { message = "Id not found.." })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }

        }

        [HttpPut("AddItemInCart")]
        public async Task<JsonResult> AddItemInCart(string Item_Code, decimal quntity, string refkey, string unit)
        => await DataBaseAccess.DAItems.AddItemInCart(Item_Code, quntity, refkey, unit);

        [HttpGet("GetCartItem")]
        public async Task<List<GetCartDetail>> GetCartItem(string refKey)
            => await DataBaseAccess.DAItems.GetCartItem(refKey);

        [HttpDelete("DeleteFromCart")]
        public async Task<JsonResult> DeleteFromCart(string ItemCode, string refKey)
            => await DataBaseAccess.DAItems.DeleteFromCart(ItemCode, refKey);

        [HttpPost("GetItemPrice")]
        public async Task<JsonResult> GetItemPrice(string Itemcode, int Qty)
            => await DataBaseAccess.DAItems.GetItemPrice(Itemcode, Qty);
    }
}
