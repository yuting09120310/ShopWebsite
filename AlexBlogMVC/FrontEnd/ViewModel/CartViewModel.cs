namespace AlexBlogMVC.FrontEnd.ViewModel
{
    public class CartViewModel
    {
        public  List<SingleProductViewModel> singleProductViewModels { get; set; }

        public int Total { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
