using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.Models;

public partial class Order
{
    [Display(Name = "訂單編號")]
    public long OrderId { get; set; }

    [Display(Name = "客戶姓名")]
    public string CustomerName { get; set; } = null!;

    [Display(Name = "信箱")]
    public string Email { get; set; } = null!;

    [Display(Name = "訂單日期")]
    public DateTime OrderDate { get; set; }

    [Display(Name = "付款方式")]
    public string PaymentMethod { get; set; } = null!;

    [Display(Name = "訂單地址")]
    public string ShippingAddress { get; set; } = null!;

    [Display(Name = "總金額")]
    public int TotalAmount { get; set; }

    [Display(Name = "訂單狀態")]
    public string OrderStatus { get; set; } = null!;
}
