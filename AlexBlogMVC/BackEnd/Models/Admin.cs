using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class Admin
{
    public long AdminNum { get; set; }

    public int? GroupNum { get; set; }

    public string? AdminAcc { get; set; }

    public string? AdminPwd { get; set; }

    public string? AdminName { get; set; }

    public bool? AdminPublish { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }
}
