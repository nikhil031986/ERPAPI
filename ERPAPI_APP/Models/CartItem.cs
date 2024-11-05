using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class CartItem
{
    public int Id { get; set; }

    public string ItemCode { get; set; } = null!;

    public decimal Quantity { get; set; }

    public string RefKey { get; set; } = null!;

    public string? Unit { get; set; }

    public DateTime? CreateDate { get; set; }
}
