using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class ItemCategory
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Category { get; set; }

    public decimal? FactoryMinimumLinePrice { get; set; }

    public decimal? ProductionMinimumLinePrice { get; set; }

    public int? ParentCategory { get; set; }

    public string? CommodityCode { get; set; }

    public string? CountryOfOrigin { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CategoryTranId { get; set; }
}
