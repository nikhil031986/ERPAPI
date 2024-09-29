using ERPAPI_APP.JSONDataMigration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI_APP.DataBaseAccess
{
    internal static class DAItems
    {
        internal static async Task InsertItems(string itemModelData)
        {
            try
            {

                var item = ItemModule.FromJson(itemModelData);
                foreach (ItemModule itemModule in item)
                {
                    var ret = UtilObject.erpDbContext.Database.
                         ExecuteSqlRaw("EXEC INSERT_ITEM_MASTER @item_id, @warehouse_id, @purchase_orders, @quantity_on_purchase_order, " +
                         "@quantity_on_hand, @quantity_committed,  @quantity_available, @item_name, @warehouse_code, @unit_id, @unit_symbol, " +
                         "@display_unit_id, @display_unit_symbol",
                         parameters: new SqlParameter[]
                         {
                            new SqlParameter("item_id",itemModule.ItemId),
                            new SqlParameter("warehouse_id",itemModule.WarehouseId),
                            new SqlParameter("purchase_orders",string.Empty),
                            new SqlParameter("quantity_on_purchase_order",itemModule.QuantityOnPurchaseOrder),
                            new SqlParameter("quantity_on_hand",itemModule.QuantityOnHand),
                            new SqlParameter("quantity_committed",itemModule.QuantityCommitted),
                            new SqlParameter("quantity_available",itemModule.QuantityAvailable),
                            new SqlParameter("item_name",itemModule.ItemName),
                            new SqlParameter("warehouse_code",itemModule.WarehouseCode),
                            new SqlParameter("unit_id",itemModule.UnitId),
                            new SqlParameter("unit_symbol",itemModule.UnitSymbol),
                            new SqlParameter("display_unit_id",itemModule.DisplayUnitId),
                            new SqlParameter("display_unit_symbol",itemModule.DisplayUnitSymbol)
                         });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                GC.Collect();
            }

        }

    }
}
