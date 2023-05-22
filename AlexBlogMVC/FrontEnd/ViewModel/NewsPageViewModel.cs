using AlexBlogMVC.Areas.Models;

namespace AlexBlogMVC.FrontEnd.ViewModel
{
    public class NewsPageViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string NewsType { get; set; }

        public DateTime CreateTime { get; set; }


        public string NewsImg1 { get; set; }

        public string contxt { get; set; }
    }
}
