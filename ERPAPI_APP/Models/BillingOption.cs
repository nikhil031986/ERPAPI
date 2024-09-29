using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class BillingOption
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Value { get; set; }

    public string? AddToInvoice { get; set; }

    public string? Slug { get; set; }

    public bool? IsRequireBillingAccount { get; set; }

    public bool? IsUseCompanyAccount { get; set; }

    public int? BillingOptionTranId { get; set; }
}
