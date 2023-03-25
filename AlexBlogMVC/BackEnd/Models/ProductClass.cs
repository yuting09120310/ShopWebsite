using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class ProductClass
{
    public long ProductClassNum { get; set; }

    public int? ProductClassSort { get; set; }

    public string? ProductClassId { get; set; }

    public string? ProductClassName { get; set; }

    public int? ProductClassLevel { get; set; }

    public int? ProductClassPre { get; set; }

    public bool? ProductClassPublish { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }
}
