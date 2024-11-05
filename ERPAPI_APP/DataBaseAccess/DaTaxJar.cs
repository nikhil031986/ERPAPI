using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Mvc;
using Taxjar;
namespace ERPAPI_APP.DataBaseAccess
{
    internal static class DaTaxJar
    {
        internal static string taxJArAPIToken = "447062b8736fe41949ee346bee3984fe";

        internal static async Task<JsonResult> CalCulationOfTax(TaxCalulation taxCalulation)
        {
            try
            {
                if (taxCalulation == null)
                {
                    return new JsonResult(new { amount = 0.0, rate = 0.0 })
                    {
                        StatusCode = StatusCodes.Status400BadRequest // Status code here 
                    };
                }
                var client = new TaxjarApi(taxJArAPIToken, new { apiUrl = "https://api.sandbox.taxjar.com" });
                //var client = new TaxjarApi(taxJArAPIToken);
                var objlineItems = taxCalulation?.line_items?.Select(x => new {
                    quantity = x.quantity,
                    unit_price = x.unit_price,
                    product_tax_code = x.product_tax_code
                }).ToArray();
                var tax = await client.TaxForOrderAsync(new
                {
                    from_country = taxCalulation?.from_country,
                    from_zip = taxCalulation?.from_zip,
                    from_state = taxCalulation?.from_state,
                    from_city = taxCalulation?.from_city,
                    to_country = taxCalulation?.to_country,
                    to_zip = taxCalulation?.to_zip,
                    to_state = taxCalulation?.to_state,
                    to_city = taxCalulation?.to_city,
                    amount = taxCalulation?.amount,
                    shipping = taxCalulation?.shipping,
                    line_items = objlineItems,
                });
                var amount = tax.AmountToCollect;
                var rate = tax.Rate;
                return new JsonResult(new { amount = amount, rate = rate })
                {
                    StatusCode = StatusCodes.Status200OK // Status code here 
                };
            }
            catch (Exception)
            {
                return new JsonResult(new { message = "Record Not remove from the cart." })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }
        }
    }
}
