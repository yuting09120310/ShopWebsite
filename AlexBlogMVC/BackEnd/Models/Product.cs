using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.BackEnd.Models;

public partial class Product
{
    [Display(Name = "編號")]
    public long ProductNum { get; set; }

    public string? Lang { get; set; }

    [Display(Name = "類別")]
    public int? ProductClass { get; set; }

    [Display(Name = "順序")]
    public int? ProductSort { get; set; }

    public string? ProductDepartment { get; set; }

    public string? ProductId { get; set; }

    [Display(Name = "標題")]
    public string? ProductTitle { get; set; }

    [Display(Name = "簡述")]
    public string? ProductDescription { get; set; }

    [Display(Name = "內文")]
    public string? ProductContxt { get; set; }

    public string? ProductImg1 { get; set; }

    public string? ProductImgUrl { get; set; }

    public string? ProductImgAlt { get; set; }

    [Display(Name = "圖片路徑")]
    public string? ProductImgList { get; set; }

    public string? ProductImgListAlt { get; set; }

    public string? ProductVideo1 { get; set; }

    [Display(Name = "狀態")]
    public bool? ProductPublish { get; set; }

    [Display(Name = "上架日期")]
    public DateTime? ProductPutTime { get; set; }

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
    public DateTime? ProductOffTime { get; set; }
}
