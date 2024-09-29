using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class AddOnDetail
{
    public int Id { get; set; }

    public int AddonId { get; set; }

    public string? TotCd { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? AddOnDetailTranId { get; set; }
}
