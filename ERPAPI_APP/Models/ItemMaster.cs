using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class ItemMaster
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? ItemCode { get; set; }

    public string? Sku { get; set; }

    public int? CategoryId { get; set; }

    public string? ItemDescription { get; set; }

    public string? WebDescription { get; set; }

    public decimal? ItemPrice { get; set; }

    public decimal? Weight { get; set; }

    public decimal? ShipWidth { get; set; }

    public decimal? ShipHeight { get; set; }

    public decimal? ShipLength { get; set; }

    public string? CommodityCode { get; set; }

    public string? DefaultCountryOfOrigin { get; set; }

    public string? CustomAttributes { get; set; }

    public int? PrimaryVendorId { get; set; }

    public int? MainImageFileId { get; set; }

    public string? ProductLine { get; set; }

    public int? UnitId { get; set; }

    public int? DisplayUnitId { get; set; }

    public string? Files { get; set; }

    public int? ItemTranId { get; set; }
}
