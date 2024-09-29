using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class AspNetRole
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }
}
