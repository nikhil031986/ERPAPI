using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class MigrationConfig
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string Apidetails { get; set; } = null!;

    public string? Apitokan { get; set; }

    public string? TokanType { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? Description { get; set; }

    public string? MethodName { get; set; }

    public string Httpmethod { get; set; } = null!;
}
