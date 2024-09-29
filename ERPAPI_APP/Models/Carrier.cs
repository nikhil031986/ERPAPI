using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class Carrier
{
    public int Id { get; set; }

    public string? Slug { get; set; }

    public string? Carrier1 { get; set; }

    public string? ShipViaAccount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CarrierTranId { get; set; }
}
