using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class OrderShipment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? State { get; set; }

    public string? Contry { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual OrderMaster Order { get; set; } = null!;
}
