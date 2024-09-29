using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class ItemPriceInformation
{
    public int ItemPriceId { get; set; }

    public int? ItemId { get; set; }

    public int? QuantityInDisplayUnit { get; set; }

    public int? CustomerId { get; set; }

    public int? UnitId { get; set; }

    public int? DisplayUnitId { get; set; }

    public decimal? FinalPricePerUnit { get; set; }

    public decimal? FinalPricePerDisplayUnit { get; set; }

    public string? QuantityBreaksPerDispalyUnit { get; set; }

    public string? PriceBreaks { get; set; }
}
