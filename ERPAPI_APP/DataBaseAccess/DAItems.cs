using ERPAPI_APP.JSONDataMigration;
using ERPAPI_APP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI_APP.DataBaseAccess
{
    internal static class DAItems
    {
        internal static async Task<List<ItemCategory>> GetItemCategory()
             => await UtilObject.erpDbContext.ItemCategories.ToListAsync();

    }
}
