using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class MenuGroup
{
    public long MenuGroupNum { get; set; }

    public int? MenuGroupSort { get; set; }

    public string? MenuGroupId { get; set; }

    public string? MenuGroupName { get; set; }

    public string? MenuGroupIcon { get; set; }

    public string? MenuGroupInfo { get; set; }

    public string? MenuGroupUrl { get; set; }

    public bool? MenuGroupPublish { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }
}
