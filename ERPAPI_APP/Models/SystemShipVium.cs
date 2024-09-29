using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class SystemShipVium
{
    public int Id { get; set; }

    public string? Slug { get; set; }

    public string? ShipViaCode { get; set; }

    public string? Description { get; set; }

    public string? PackageType { get; set; }

    public string? WebDescription { get; set; }

    public bool? SaturdayDeliveryOption { get; set; }

    public bool? CreditCardPreAuthOption { get; set; }

    public bool? FreeShip { get; set; }

    public bool? Web { get; set; }

    public int? EasyPostMethodId { get; set; }

    public bool? Expedite { get; set; }

    public bool? FreeFreightAllowed { get; set; }

    public bool? International { get; set; }

    public bool? Collect { get; set; }

    public int? CarrierId { get; set; }

    public bool? IsReturnMethod { get; set; }

    public string? BillingOptions { get; set; }

    public string? HandlingChargeAmount { get; set; }

    public string? HandlingChargePercent { get; set; }

    public bool? IsPickup { get; set; }

    public bool? IsDelivery { get; set; }

    public string? EdiServiceLevelCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? SystemShipViaTranId { get; set; }
}
