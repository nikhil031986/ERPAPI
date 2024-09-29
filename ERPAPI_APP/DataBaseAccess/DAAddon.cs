using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI_APP.DataBaseAccess
{
    internal static class DAAddon
    {
        internal static async Task<List<GetAddOnData>> GetAddOnDetails()
            => await UtilObject.erpDbContext.AddOns.Select(x => new GetAddOnData
            {
                Id = x.Id,
                Amount = x.Amount,
                OrderInvoice = x.OrderInvoice,
                TaxFlag = x.TaxFlag,
                TaxOverride = x.TaxOverride,
                TaxCode = x.TaxCode,
                TaxRate = x.TaxRate,
                TaxAmount = x.TaxAmount,
                PurchaseOrderBill = x.PurchaseOrderBill,
                AddOnTranId = x.AddOnTranId,
                AddonDetails = UtilObject.erpDbContext.AddOnDetails.Where(m => m.AddonId == x.Id).ToList()
            }).ToListAsync();
    }
}
