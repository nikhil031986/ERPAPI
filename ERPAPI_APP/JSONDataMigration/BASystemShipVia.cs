using Microsoft.EntityFrameworkCore;

namespace ERPAPI_APP.JSONDataMigration
{
    internal static class BASystemShipVia
    {
        internal static async Task GetSystemShipVias<T>()
            => await UtilObject.erpDbContext.SystemShipVia.Select(x => new
            {
                Id = x.Id,
                Slug = x.Slug,
                ShipViaCode = x.ShipViaCode,
                Description = x.Description,
                PackageType = x.PackageType,
                WebDescription = x.WebDescription,
                SaturdayDeliveryOption = x.SaturdayDeliveryOption,
                CreditCardPreAuthOption = x.CreditCardPreAuthOption,
                FreeShip = x.FreeShip,
                Web = x.Web,
                EasyPostMethod = UtilObject.erpDbContext.EasyPostMethods.Where(m => m.Id == x.EasyPostMethodId).ToList(),
                Expedite = x.Expedite,
                FreeFreightAllowed = x.FreeFreightAllowed,
                International = x.International,
                Collect = x.Collect,
                Carrier = UtilObject.erpDbContext.Carriers.Where(m => m.Id == x.CarrierId).ToList(),
                IsReturnMethod = x.IsReturnMethod,
                BillingOptions = x.BillingOptions,
                HandlingChargeAmount = x.HandlingChargeAmount,
                HandlingChargePercent = x.HandlingChargePercent,
                IsPickup = x.IsPickup,
                IsDelivery = x.IsDelivery,
                EdiServiceLevelCode = x.EdiServiceLevelCode,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                SystemShipViaTranId = x.SystemShipViaTranId
            }).ToListAsync();
    }
}
