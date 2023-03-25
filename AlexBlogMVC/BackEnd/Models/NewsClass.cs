using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class NewsClass
{
    public long NewsClassNum { get; set; }

    public int? NewsClassSort { get; set; }

    public string? NewsClassId { get; set; }

    public string? NewsClassName { get; set; }

    public int? NewsClassLevel { get; set; }

    public int? NewsClassPre { get; set; }

    public bool? NewsClassPublish { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }
}
