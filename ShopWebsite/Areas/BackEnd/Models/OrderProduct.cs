using System;
using System.Collections.Generic;

namespace ShopWebsite.Areas.BackEnd.Models;

public partial class OrderProduct
{
    public int OrderProductId { get; set; }

    public long OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public int? Discount { get; set; }
}
