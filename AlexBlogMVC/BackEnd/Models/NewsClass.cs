using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class NewsClass
{
    public long NewsClassNum { get; set; }

    public long? NewsClassSort { get; set; }

    public string? NewsClassId { get; set; }

    public string? NewsClassName { get; set; }

    public long? NewsClassLevel { get; set; }

    public long? NewsClassPre { get; set; }

    public bool? NewsClassPublish { get; set; }

    public DateTime? CreateTime { get; set; }

    public long? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public long? Editor { get; set; }

    public string? Ip { get; set; }
}
