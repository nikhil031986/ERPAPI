using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class PaymentTerm1
{
    public int Id { get; set; }

    public string? Slug { get; set; }

    public string? Description { get; set; }

    public int? DiscountDays { get; set; }

    public int? DueDays { get; set; }

    public double? TotalDiscountPercent { get; set; }

    public string? TermsCode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? PaymentTermTranId { get; set; }
}
