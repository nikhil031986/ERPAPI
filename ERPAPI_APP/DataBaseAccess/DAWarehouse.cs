using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DAWarehouse
    {
        private static readonly ErpDbContext erpDbContext = new ErpDbContext();

        internal static async Task<List<WarehouseMaster>> GetWarehouses()
            => await erpDbContext.WarehouseMasters.ToListAsync();
    }
}
