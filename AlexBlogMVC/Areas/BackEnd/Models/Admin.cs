using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.Areas.Models;

public partial class Admin
{
    [Display(Name = "帳號編號")]
    public long AdminNum { get; set; }
    [Display(Name = "群組")]
    public long? GroupNum { get; set; }
    [Display(Name = "帳號")]
    public string? AdminAcc { get; set; }
    [Display(Name = "密碼")]
    public string? AdminPwd { get; set; }
    [Display(Name = "姓名")]
    public string? AdminName { get; set; }
    [Display(Name = "狀態")]
    public bool? AdminPublish { get; set; }
    [Display(Name = "最後登入")]
    public DateTime? LastLogin { get; set; }
    [Display(Name = "建立時間")]
    public DateTime? CreateTime { get; set; }
    [Display(Name = "建立人")]
    public long? Creator { get; set; }
    [Display(Name = "編輯時間")]
    public DateTime? EditTime { get; set; }
    [Display(Name = "編輯人")]
    public long? Editor { get; set; }

    public string? Ip { get; set; }
}
