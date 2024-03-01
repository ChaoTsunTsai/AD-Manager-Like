using System;
using System.Collections.Generic;

namespace AD_Manager.Models;

public partial class UserTechnician
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;
}
