using System;
using System.Collections.Generic;

namespace ShopWebsite.Areas.BackEnd.Models;

public partial class Product
{
    public long ProductNum { get; set; }

    public string? Lang { get; set; }

    public long ProductClass { get; set; }

    public long? ProductSort { get; set; }

    public string? ProductDepartment { get; set; }

    public string? ProductId { get; set; }

    public string? ProductTitle { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductContxt { get; set; }

    public string? ProductImg1 { get; set; }

    public string? ProductImgUrl { get; set; }

    public string? ProductImgAlt { get; set; }

    public string? ProductImgList { get; set; }

    public string? ProductImgListAlt { get; set; }

    public string? ProductVideo1 { get; set; }

    public int ProductPrice { get; set; }

    public bool? ProductPublish { get; set; }

    public DateTime? ProductPutTime { get; set; }

    public DateTime CreateTime { get; set; }

    public long? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public long? Editor { get; set; }

    public string? Ip { get; set; }

    public DateTime? ProductOffTime { get; set; }

    public string Tag { get; set; } = null!;
}
