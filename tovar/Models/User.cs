﻿using System;
using System.Collections.Generic;

namespace tovar.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronomic { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
