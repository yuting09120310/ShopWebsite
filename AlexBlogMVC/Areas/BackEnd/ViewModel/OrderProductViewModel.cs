﻿namespace AlexBlogMVC.Areas.ViewModel
{

    public class OrderProductViewModel
    {
        public int OrderProductId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
    }
}