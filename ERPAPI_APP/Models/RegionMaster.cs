using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class RegionMaster
{
    public int Id { get; set; }

    public string? Slug { get; set; }

    public string? CountryName { get; set; }

    public string? Region { get; set; }

    public string? States { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? RegionTranId { get; set; }
}
