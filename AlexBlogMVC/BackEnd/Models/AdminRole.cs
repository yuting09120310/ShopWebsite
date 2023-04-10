using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class AdminRole
{
    public long RoleNum { get; set; }

    public long? GroupNum { get; set; }

    public long? MenuSubNum { get; set; }

    public string? Role { get; set; }

    public DateTime? CreateTime { get; set; }

    public long? Creator { get; set; }

    public string? Ip { get; set; }
}
