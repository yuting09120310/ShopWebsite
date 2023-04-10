using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class AdminGroup
{
    public long GroupNum { get; set; }

    public string? GroupName { get; set; }

    public string? GroupInfo { get; set; }

    public bool? GroupPublish { get; set; }

    public DateTime? CreateTime { get; set; }

    public long? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public long? Editor { get; set; }

    public string? Ip { get; set; }
}
