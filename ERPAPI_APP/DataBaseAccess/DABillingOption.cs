using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;
namespace ERPAPI_APP.DataBaseAccess
{
    internal class DABillingOption
    {
        private static readonly ErpDbContext erpDbContext = new ErpDbContext();
        internal static async Task<List<BillingOption>> GetBilling_Option()
            => await erpDbContext.BillingOptions.ToListAsync();
    }
}
