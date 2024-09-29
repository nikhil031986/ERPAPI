using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class CustomerGroup
{
    public int Id { get; set; }

    public string? Value { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CustomerGroupTranId { get; set; }
}
