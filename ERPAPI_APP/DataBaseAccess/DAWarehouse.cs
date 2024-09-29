using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DAWarehouse
    {
        internal static async Task<List<WarehouseMaster>> GetWarehouses()
            => await UtilObject.erpDbContext.WarehouseMasters.ToListAsync();
    }
}
