using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class AspNetUser
{
    public int UserId { get; set; }

    public string EmailId { get; set; } = null!;

    public string PasswordHas { get; set; } = null!;

    public int CustomerId { get; set; }

    public int CompanyId { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public bool IsFirstTimeLogin { get; set; }

    public bool IsActive { get; set; }
}
