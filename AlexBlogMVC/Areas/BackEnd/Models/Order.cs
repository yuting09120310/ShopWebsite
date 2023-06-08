using System;
using System.Collections.Generic;

namespace AlexBlogMVC.Areas.BackEnd.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string ShippingAddress { get; set; } = null!;

    public int TotalAmount { get; set; }

    public string OrderStatus { get; set; } = null!;
}
