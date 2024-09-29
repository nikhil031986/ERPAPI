using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;
namespace ERPAPI_APP.DataBaseAccess
{
    internal class DABillingOption
    {
        internal static async Task<List<BillingOption>> GetBilling_Option()
            => await UtilObject.erpDbContext.BillingOptions.ToListAsync();
    }
}
