using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class OrderPayment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int? PaymentType { get; set; }

    public int? PaymentTerm { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual OrderMaster Order { get; set; } = null!;
}
