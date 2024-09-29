using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class UnitMaster
{
    public int UnitId { get; set; }

    public string? UnitName { get; set; }

    public string? UnitSymbol { get; set; }

    public int? UnitTranId { get; set; }
}
