using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string PaymentMethod1 { get; set; } = null!;

    public string MethodDescription { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public bool IsAccountsPayableMethod { get; set; }

    public bool IsCreditCardPayment { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int PaymentMethodTranId { get; set; }
}
