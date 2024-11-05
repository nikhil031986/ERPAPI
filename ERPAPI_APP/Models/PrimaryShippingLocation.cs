using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class PrimaryShippingLocation
{
    public int Id { get; set; }

    public string? ShipingLocation { get; set; }

    public string? Location { get; set; }

    public string? Region { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? ShipViaAccount { get; set; }

    public string? Slug { get; set; }

    public string? Phone { get; set; }

    public bool? IsResidential { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreateAt { get; set; }
}
