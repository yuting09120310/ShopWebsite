using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.BackEnd.Models;

public partial class NewsClass
{
    [Display(Name = "類別編號")]
    public long NewsClassNum { get; set; }

    [Display(Name = "順序")]
    public int? NewsClassSort { get; set; }

    public string? NewsClassId { get; set; }

    [Display(Name = "名稱")]
    public string? NewsClassName { get; set; }

    public int? NewsClassLevel { get; set; }

    public int? NewsClassPre { get; set; }

    [Display(Name = "狀態")]
    public bool? NewsClassPublish { get; set; }

    [Display(Name = "建立時間")]
    public DateTime? CreateTime { get; set; }

    [Display(Name = "建立人")]
    public int? Creator { get; set; }

    [Display(Name = "編輯時間")]
    public DateTime? EditTime { get; set; }

    [Display(Name = "編輯人")]
    public int? Editor { get; set; }

    public string? Ip { get; set; }
}
