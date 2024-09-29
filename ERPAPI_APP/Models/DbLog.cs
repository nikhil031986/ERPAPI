using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class DbLog
{
    public int Id { get; set; }

    public DateTime LogDate { get; set; }

    public DateTime RequestDate { get; set; }

    public string RequestApi { get; set; } = null!;

    public DateTime ResponseDate { get; set; }

    public string ResponseValue { get; set; } = null!;

    public string ErrorMsg { get; set; } = null!;

    public DateTime? ErrorDateTime { get; set; }
}
