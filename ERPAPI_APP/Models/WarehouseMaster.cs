using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class WarehouseMaster
{
    public int WarehouseId { get; set; }

    public int? WarehouseTransId { get; set; }

    public string? WarehouseName { get; set; }

    public string? WarehouseCode { get; set; }

    public string? Attention { get; set; }

    public bool? IsExternal { get; set; }

    public bool? IsWeb { get; set; }

    public string? Slug { get; set; }

    public string? Email { get; set; }

    public string? TransferShipViaAccount { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Postal { get; set; }

    public string? Phone { get; set; }

    public bool? IsResidential { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public int? WarehouseTranId { get; set; }
}
