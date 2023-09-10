using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsViewModel;

namespace ShopWebsite.Areas.BackEnd.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private ShopWebsiteContext _context;

        public OrderRepository(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public List<NewsIndexViewModel> GetList()
        {
            List<NewsIndexViewModel> viewModel = _context.News
                                            .Select(n => new NewsIndexViewModel
                                            {
                                                NewsNum = n.NewsNum,
                                                NewsTitle = n.NewsTitle,
                                                NewsDescription = n.NewsDescription,
                                                NewsImg1 = n.NewsImg1,
                                                NewsPutTime = n.NewsPutTime,
                                                CreateTime = n.CreateTime,
                                                EditTime = n.EditTime,
                                                NewsOffTime = n.NewsOffTime,
                                                NewsPublish = n.NewsPublish
                                            }).ToList();

            return viewModel;
        }


        public NewsCreateViewModel Create()
        {
            NewsCreateViewModel viewModel = new NewsCreateViewModel();
            return viewModel;
        }


        public void Create(NewsCreateViewModel newsViewModel, long AdminNum)
        {
            News news = new News()
            {
                NewsClass = newsViewModel.NewsClass,
                NewsTitle = newsViewModel.NewsTitle,
                NewsDescription = newsViewModel.NewsDescription,
                NewsContxt = newsViewModel.NewsContxt,
                NewsImg1 = newsViewModel.NewsImg1.FileName,
                NewsPublish = newsViewModel.NewsPublish,
                NewsPutTime = newsViewModel.NewsPutTime,
                NewsOffTime = newsViewModel.NewsOffTime,
                Creator = AdminNum,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Tag = newsViewModel.Tag
            };

            _context.Add(news);
            _context.SaveChanges();
        }


        public NewsEditViewModel Edit(long? id)
        {
            //進入DB搜尋資料
            NewsEditViewModel newsViewModel = (
                from news in _context.News
                where news.NewsNum == id
                select new NewsEditViewModel
                {
                    NewsNum = news.NewsNum,
                    NewsTitle = news.NewsTitle,
                    NewsClass = news.NewsClass,
                    NewsDescription = news.NewsDescription,
                    NewsContxt = news.NewsContxt,
                    NewsPublish = news.NewsPublish,
                    NewsPutTime = news.NewsPutTime,
                    NewsOffTime = news.NewsOffTime,
                    NewsImg1 = new FormFile(new MemoryStream(), 0, 0, news.NewsImg1.ToString(), news.NewsImg1.ToString()),
                    Tag = news.Tag
                }
            ).FirstOrDefault()!;

            return newsViewModel;
        }

        
        public void Edit(NewsEditViewModel newsViewModel, long AdminNum)
        {
            News news = _context.News.Where(x => x.NewsNum == newsViewModel.NewsNum).FirstOrDefault()!;

            //將資料寫入db
            news.NewsTitle = newsViewModel.NewsTitle;
            news.NewsClass = newsViewModel.NewsClass;
            news.NewsDescription = newsViewModel.NewsDescription;
            news.NewsContxt = newsViewModel.NewsContxt;
            news.NewsPublish = newsViewModel.NewsPublish;
            news.NewsPutTime = newsViewModel.NewsPutTime;
            news.NewsOffTime = newsViewModel.NewsOffTime;
            news.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            news.Editor = AdminNum;

            if (newsViewModel.NewsImg1 != null)
            {
                news.NewsImg1 = newsViewModel.NewsImg1.FileName;
            }

            _context.Update(news);
            _context.SaveChanges();
        }


        public string Delete(long? id)
        {
            var news = _context.News
               .FirstOrDefault(m => m.NewsNum == id);

            string result = JsonConvert.SerializeObject(news);

            return result;
        }


        public void DeleteConfirmed(long? id, string path)
        {
            var news = _context.News.Find(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }

            _context.SaveChanges();

            //取得該篇文章的圖片並刪除
            var direPath = Path.Combine(path, "uploads", "News");
            var filePath = Path.Combine(direPath, news.NewsImg1);
            System.IO.File.Delete(filePath);
        }


        public void SaveFile(IFormFile file, string path)
        {
            var direPath = Path.Combine(path, "uploads", "News");
            if (!Directory.Exists(direPath))
            {
                Directory.CreateDirectory(direPath);
            }

            var filePath = Path.Combine(direPath, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }

        
        public List<SelectListItem> GetNewsClasseList()
        {
            return _context.NewsClasses
                           .Where(g => g.NewsClassPublish == true)
                           .Select(g => new SelectListItem { Text = g.NewsClassName, Value = g.NewsClassNum.ToString() })
                           .ToList();
        }
    }
}
