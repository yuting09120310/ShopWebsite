namespace ShopWebsite.Areas.ViewModel
{

    public class OrderProductViewModel
    {
        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImg { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
    }
}
