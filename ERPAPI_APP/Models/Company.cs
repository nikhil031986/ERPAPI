using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class Company
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyCode { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }
}
