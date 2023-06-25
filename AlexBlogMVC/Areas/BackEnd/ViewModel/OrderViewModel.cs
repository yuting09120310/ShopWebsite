using ShopWebsite.Areas.BackEnd.Models;

namespace ShopWebsite.Areas.ViewModel
{
    public class OrderViewModel
    {

        public Order order { get; set; }

        public List<OrderProductViewModel> orderProduct { get; set;}

    }
}
