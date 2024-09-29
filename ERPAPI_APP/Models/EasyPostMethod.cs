using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class EasyPostMethod
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? EsyPostMethodTranId { get; set; }
}
