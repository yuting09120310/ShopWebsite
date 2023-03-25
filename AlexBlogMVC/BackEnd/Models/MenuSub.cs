using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class MenuSub
{
    public long MenuSubNum { get; set; }

    public string? MenuGroupId { get; set; }

    public int? MenuSubSort { get; set; }

    public string? MenuSubId { get; set; }

    public string? MenuSubName { get; set; }

    public string? MenuSubRole { get; set; }

    public string? MenuSubIcon { get; set; }

    public string? MenuSubInfo { get; set; }

    public string? MenuSubUrl { get; set; }

    public bool? MenuSubPublish { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }
}
