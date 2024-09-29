using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class AspNetUserRole
{
    public int Id { get; set; }

    public int AspNetUserId { get; set; }

    public int AspNetRoleId { get; set; }
}
