using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class Banner
{
    public long BannerNum { get; set; }

    public string? Lang { get; set; }

    public int? ProductClass { get; set; }

    public int? BannerSort { get; set; }

    public string? BannerTitle { get; set; }

    public string? BannerDescription { get; set; }

    public string? BannerContxt { get; set; }

    public string? BannerImg1 { get; set; }

    public string? BannerImgUrl { get; set; }

    public string? BannerImgAlt { get; set; }

    public int? BannerPublish { get; set; }

    public DateTime? BannerPutTime { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }

    public DateTime? BannerOffTime { get; set; }
}
