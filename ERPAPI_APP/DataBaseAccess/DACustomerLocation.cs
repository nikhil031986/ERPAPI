using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DACustomerLocation
    {
        internal static async Task<List<GetCustomerLocation>> GetCustomer_Location()
            => await UtilObject.erpDbContext.CustomerLocationInformations
                .Join(UtilObject.erpDbContext.CustomerMasters, p => p.CustomerId, pc => pc.CustomerId, (p, pc) => new { p, pc })
            .Select(m => new GetCustomerLocation
                {
                    CustomerLocationId = m.p.CustomerLocationId,
                    City = m.p.City,
                    Country = m.p.Country,
                    Phone = m.p.Phone,
                    ShipAttention = m.p.ShipAttention,
                    Slug = m.p.Slug,
                    IsResidential = m.p.IsResidential,
                    Dob = m.p.Dob,
                    Customer = m.pc,
                    Location = m.p.Location,
                    Address1 = m.p.Address1,
                    Address2 = m.p.Address2,
                    Address3 = m.p.Address3,
                    State = m.p.State,
                    Postal = m.p.Postal,
                    BlindShip = m.p.BlindShip,
                    Name = m.p.Name,
                    ShipViaAccount = m.p.ShipViaAccount,
                    HasConsolidatedShipments = m.p.HasConsolidatedShipments,
                    CustomerLocationTranId = m.p.CustomerLocationTranId,
                    UpdatedAt = m.p.UpdatedAt,
                    CreatedAt = m.p.CreatedAt,
                    region = UtilObject.erpDbContext.RegionMasters.Where(x=> x.Id == m.p.RegionId).ToList(),
                }).ToListAsync();
    
       
    }
}
