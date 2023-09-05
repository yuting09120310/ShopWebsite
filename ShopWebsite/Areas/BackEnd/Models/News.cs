using System;
using System.Collections.Generic;

namespace ShopWebsite.Areas.BackEnd.Models;

public partial class News
{
    public long NewsNum { get; set; }

    public string? Lang { get; set; }

    public long NewsClass { get; set; }

    public long? NewsSort { get; set; }

    public string? NewsTitle { get; set; }

    public string? NewsDescription { get; set; }

    public string? NewsContxt { get; set; }

    public string? NewsImg1 { get; set; }

    public string? NewsImgUrl { get; set; }

    public string? NewsImgAlt { get; set; }

    public bool? NewsPublish { get; set; }

    public long? NewsViews { get; set; }

    public DateTime? NewsPutTime { get; set; }

    public DateTime? CreateTime { get; set; }

    public long? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public long? Editor { get; set; }

    public string? Ip { get; set; }

    public DateTime? NewsOffTime { get; set; }

    public string? Tag { get; set; }
}
