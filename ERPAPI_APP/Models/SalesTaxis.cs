using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class SalesTaxis
{
    public int Id { get; set; }

    public string TaxCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public decimal? TaxRate { get; set; }

    public int? GeneralLedgerAccountId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? SalesTaxesTranId { get; set; }
}
