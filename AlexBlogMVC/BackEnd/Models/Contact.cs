using System;
using System.Collections.Generic;

namespace AlexBlogMVC.BackEnd.Models;

public partial class Contact
{
    public long ContactNum { get; set; }

    public string? ContactName { get; set; }

    public string? ContactPhone { get; set; }

    public string? ContactMail { get; set; }

    public string? ContactTxt { get; set; }

    public string? ContactReTxt { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }
}
