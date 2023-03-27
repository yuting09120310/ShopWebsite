using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.BackEnd.Models;

public partial class Banner
{
    [Display(Name = "廣告編號")]
    public long BannerNum { get; set; }

    public string? Lang { get; set; }

    [Display(Name = "分類")]
    public int? ProductClass { get; set; }

    [Display(Name = "排序")]
    public int? BannerSort { get; set; }

    [Display(Name = "標題")]
    public string? BannerTitle { get; set; }

    [Display(Name = "簡述")]
    public string? BannerDescription { get; set; }

    [Display(Name = "內容")]
    public string? BannerContxt { get; set; }

    [Display(Name = "圖片")]
    public string? BannerImg1 { get; set; }

    [Display(Name = "連結")]
    public string? BannerImgUrl { get; set; }

    public string? BannerImgAlt { get; set; }

    [Display(Name = "狀態")]
    public int? BannerPublish { get; set; }

    [Display(Name = "上架日期")]
    public DateTime? BannerPutTime { get; set; }

    [Display(Name = "建立日期")]
    public DateTime? CreateTime { get; set; }

    [Display(Name = "建立人")]
    public int? Creator { get; set; }

    [Display(Name = "編輯日期")]
    public DateTime? EditTime { get; set; }

    [Display(Name = "編輯人")]
    public int? Editor { get; set; }

    public string? Ip { get; set; }

    [Display(Name = "下架日期")]
    public DateTime? BannerOffTime { get; set; }
}
