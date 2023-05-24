using System;
using System.Collections.Generic;

namespace AlexBlogMVC.Areas.BackEnd.Models;

public partial class ProductClass
{
    public long ProductClassNum { get; set; }

    public long? ProductClassSort { get; set; }

    public string? ProductClassId { get; set; }

    public string? ProductClassName { get; set; }

    public long? ProductClassLevel { get; set; }

    public long? ProductClassPre { get; set; }

    public bool? ProductClassPublish { get; set; }

    public DateTime? CreateTime { get; set; }

    public long? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public long? Editor { get; set; }

    public string? Ip { get; set; }
}
