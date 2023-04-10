using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class Banner
{
    public long BannerNum { get; set; }

    public string? Lang { get; set; }

    public long? ProductClass { get; set; }

    public long? BannerSort { get; set; }

    public string? BannerTitle { get; set; }

    public string? BannerDescription { get; set; }

    public string? BannerContxt { get; set; }

    public string? BannerImg1 { get; set; }

    public string? BannerImgUrl { get; set; }

    public string? BannerImgAlt { get; set; }

    public long? BannerPublish { get; set; }

    public DateTime? BannerPutTime { get; set; }

    public DateTime? CreateTime { get; set; }

    public long? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public long? Editor { get; set; }

    public string? Ip { get; set; }

    public DateTime? BannerOffTime { get; set; }
}
