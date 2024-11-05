using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class OrderPaymentDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentThrow { get; set; }

    public string? CardNumber { get; set; }

    public string? CvcCheck { get; set; }

    public string? ExpMonth { get; set; }

    public string? ExpYear { get; set; }

    public string? Funding { get; set; }

    public string? Last4 { get; set; }

    public string? EmailId { get; set; }

    public string? ClientIp { get; set; }

    public string? TokenValue { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual OrderMaster Order { get; set; } = null!;
}
