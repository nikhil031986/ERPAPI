using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class LogoMaster
{
    public int Id { get; set; }

    public string? Size { get; set; }

    public string? ETag { get; set; }

    public string? ContentType { get; set; }

    public string? FileName { get; set; }

    public string? Key { get; set; }

    public string? Description { get; set; }

    public int? FileOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? LogoTranId { get; set; }
}
