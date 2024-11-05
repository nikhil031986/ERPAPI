using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class UserConfig
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string ConfigName { get; set; } = null!;

    public string ConfigValue { get; set; } = null!;

    public string ValueType { get; set; } = null!;

    public DateTime? CreatAt { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
