using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class News
{
    public long NewsNum { get; set; }

    public string? Lang { get; set; }

    public int? NewsClass { get; set; }

    public int? NewsSort { get; set; }

    public string? NewsTitle { get; set; }

    public string? NewsDescription { get; set; }

    public string? NewsContxt { get; set; }

    public string? NewsImg1 { get; set; }

    public string? NewsImgUrl { get; set; }

    public string? NewsImgAlt { get; set; }

    public int? NewsPublish { get; set; }

    public int? NewsViews { get; set; }

    public DateTime? NewsPutTime { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }

    public DateTime? NewsOffTime { get; set; }
}
