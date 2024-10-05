using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class UnitMaster
{
    public int UnitId { get; set; }

    public string? UnitName { get; set; }

    public string? UnitSymbol { get; set; }

    public int? UnitTranId { get; set; }

    public string GroupLabel { get; set; } = null!;

    public bool Visible { get; set; }

    public bool IsCustomUnit { get; set; }

    public decimal ConversionFactor { get; set; }

    public string UpcCode { get; set; } = null!;

    public decimal Length { get; set; }

    public decimal Width { get; set; }

    public decimal Height { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
