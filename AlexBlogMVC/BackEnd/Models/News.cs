using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.BackEnd.Models;

public partial class News
{
    [Display(Name = "新聞編號")]
    public long NewsNum { get; set; }

    public string? Lang { get; set; }

    [Display(Name = "新聞類別")]
    public int? NewsClass { get; set; }

    public int? NewsSort { get; set; }

    [Display(Name = "標題")]
    public string? NewsTitle { get; set; }

    [Display(Name = "簡述")]
    public string? NewsDescription { get; set; }

    [Display(Name = "內文")]
    public string? NewsContxt { get; set; }

    [Display(Name = "圖片")]
    public string? NewsImg1 { get; set; }

    [Display(Name = "連結")]
    public string? NewsImgUrl { get; set; }

    public string? NewsImgAlt { get; set; }

    [Display(Name = "狀態")]
    public int? NewsPublish { get; set; }

    public int? NewsViews { get; set; }

    [Display(Name = "上架時間")]
    public DateTime? NewsPutTime { get; set; }

    [Display(Name = "建立時間")]
    public DateTime? CreateTime { get; set; }

    [Display(Name = "建立人")]
    public int? Creator { get; set; }

    [Display(Name = "編輯時間")]
    public DateTime? EditTime { get; set; }

    [Display(Name = "編輯人")]
    public int? Editor { get; set; }

    public string? Ip { get; set; }

    [Display(Name = "下架時間")]
    public DateTime? NewsOffTime { get; set; }
}
