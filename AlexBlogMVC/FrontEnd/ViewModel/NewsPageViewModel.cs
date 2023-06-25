using ShopWebsite.Areas.BackEnd.Models;

namespace ShopWebsite.FrontEnd.ViewModel
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

        public string? Tag { get; set; }


        //取得留言
        public List<UserComment> getCommants { get; set; }

        //送出留言
        public UserComment postComment { get; set; }


        
    }
}
