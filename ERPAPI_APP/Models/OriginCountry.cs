using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class OriginCountry
{
    public int Id { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public string? Slug { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CountryTranId { get; set; }
}
