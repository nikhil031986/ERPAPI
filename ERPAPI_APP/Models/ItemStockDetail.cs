using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class ItemStockDetail
{
    public int StockId { get; set; }

    public int? ItemId { get; set; }

    public int? WarehouseId { get; set; }

    public string? PurchaseOrders { get; set; }

    public int? QuantityOnPurchaseOrder { get; set; }

    public int? QuantityOnHand { get; set; }

    public int? QuantityCommitted { get; set; }

    public int? QuantityAvailable { get; set; }

    public int? UnitId { get; set; }

    public int? DisplayUnitId { get; set; }
}
