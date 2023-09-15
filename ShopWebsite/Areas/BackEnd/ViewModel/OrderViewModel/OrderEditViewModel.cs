using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.OrderViewModel
{
    public class OrderEditViewModel
    {
        [Display(Name = "編號")]
        public long OrderID { get; set; }

        [Display(Name = "姓名")]
        public string? CustomerName { get; set; }

        [Display(Name = "信箱")]
        public string? Email { get; set; }

        [Display(Name = "訂單日期")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "付款方式")]
        public string? PaymentMethod { get; set; }

        [Display(Name = "訂單地址")]
        public string? ShippingAddress { get; set; }

        [Display(Name = "訂單總額")]
        public int TotalAmount { get; set; }

        [Display(Name = "訂單狀態")]
        public string? OrderStatus { get; set; }


        public List<OrderProductViewModel> orderProductViewModels { get; set; }
    }

    public class OrderProductViewModel
    {
        public string? ProductName { get; set; }
        public string? ProductImg { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
