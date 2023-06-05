using AlexBlogMVC.Areas.BackEnd.Models;

namespace AlexBlogMVC.Areas.ViewModel
{
    public class OrderViewModel
    {

        public Order order { get; set; }

        public List<OrderProductViewModel> orderProduct { get; set;}

    }
}
