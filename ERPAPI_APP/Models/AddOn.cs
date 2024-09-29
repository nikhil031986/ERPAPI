using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class AddOn
{
    public int Id { get; set; }

    public decimal? Amount { get; set; }

    public string? OrderInvoice { get; set; }

    public bool? TaxFlag { get; set; }

    public bool? TaxOverride { get; set; }

    public string? TaxCode { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal? TaxAmount { get; set; }

    public string? PurchaseOrderBill { get; set; }

    public int? AddOnTranId { get; set; }
}
