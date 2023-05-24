using AlexBlogMVC.Areas.BackEnd.Models;

namespace AlexBlogMVC.FrontEnd.ViewModel
{
    public class NewsPageViewModel
    {
        public long NewsId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long ClassId { get; set; }

        public string NewsTypeName { get; set; }

        public DateTime CreateTime { get; set; }

        public string NewsImg1 { get; set; }

        public string contxt { get; set; }



        ////留言
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
