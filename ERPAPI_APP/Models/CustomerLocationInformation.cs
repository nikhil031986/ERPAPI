using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class CustomerLocationInformation
{
    public int CustomerLocationId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? Dob { get; set; }

    public string? Location { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Postal { get; set; }

    public string? Phone { get; set; }

    public bool? BlindShip { get; set; }

    public string? Name { get; set; }

    public string? ShipViaAccount { get; set; }

    public string? Slug { get; set; }

    public string? ShipAttention { get; set; }

    public bool? HasConsolidatedShipments { get; set; }

    public bool? IsResidential { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CustomerLocationTranId { get; set; }

    public int RegionId { get; set; }
}
