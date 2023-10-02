namespace ShopWebsite.Areas.BackEnd.Models;

public partial class OrderProduct
{
    public long OrderProductId { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public long Quantity { get; set; }

    public long Price { get; set; }

    public long? Discount { get; set; }
}
