using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class OrderSourceMaster
{
    public int Id { get; set; }

    public string? Slug { get; set; }

    public string? Code { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? OrderSourceTranId { get; set; }
}
