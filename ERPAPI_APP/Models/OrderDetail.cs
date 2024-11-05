using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string ItemCode { get; set; } = null!;

    public decimal ItemPrice { get; set; }

    public string Unit { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public decimal Qty { get; set; }

    public virtual OrderMaster Order { get; set; } = null!;
}
