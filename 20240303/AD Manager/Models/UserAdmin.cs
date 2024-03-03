using System;
using System.Collections.Generic;

namespace AD_Manager.Models;

public partial class UserAdmin
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;
}
