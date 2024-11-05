using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ERPAPI_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost("SaveOrderDetail")]
        public async Task<JsonResult> SaveOrderDetail([FromBody] OrderMasterEntry orderMaster)
        {
            var ordermsg = await DataBaseAccess.DaOrder.SaveOrder(orderMaster);
            if (ordermsg != null)
            {
                return new JsonResult(new { message = ordermsg.OrderId })
                {
                    StatusCode = StatusCodes.Status200OK // Status code here 
                };
            }
            else
            {
                return new JsonResult(new { message = "Order not added /n Please try agen." })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }
        }

        [HttpGet("GetOrderDetail")]
        public async Task<List<GetOrderMaster>> GetOrderDetail(string orderId)
        => await DataBaseAccess.DaOrder.GetOrderDetail(orderId);

        [HttpPost("CalCulationOfTax")]
        public async Task<JsonResult> CalCulationOfTax([FromBody] TaxCalulation taxCalulation)
            => await DataBaseAccess.DaTaxJar.CalCulationOfTax(taxCalulation);

        [HttpPost("PaymentDetail")]
        public async Task<JsonResult> PaymentDetail([FromBody] paymentDetailsEntry paymentDetail)
            => await DataBaseAccess.DaOrder.PaymentDetail(paymentDetail);

        [HttpPut("OrderPut")]
        public async Task<JsonResult> OrderPut(string paymenttranId,string orderId)
        //=> await UtilImage.putOrder(paymenttranId,orderId);
        {
            return (null);
          }
    }


}
