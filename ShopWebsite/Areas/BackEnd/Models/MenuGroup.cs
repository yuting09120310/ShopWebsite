namespace ShopWebsite.Areas.BackEnd.Models;

public partial class MenuGroup
{
    public long MenuGroupNum { get; set; }

    public long? MenuGroupSort { get; set; }

    public string? MenuGroupId { get; set; }

    public string? MenuGroupName { get; set; }

    public string? MenuGroupIcon { get; set; }

    public string? MenuGroupInfo { get; set; }

    public string? MenuGroupUrl { get; set; }

    public bool? MenuGroupPublish { get; set; }

    public DateTime? CreateTime { get; set; }

    public long? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public long? Editor { get; set; }

    public string? Ip { get; set; }
}
