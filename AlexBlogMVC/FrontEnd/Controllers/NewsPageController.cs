using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using static AlexBlogMVC.FrontEnd.ViewModel.NewsPageViewModel;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class NewsPageController : GenericController
    {

        public NewsPageController(BlogMvcContext context) : base(context) { }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetBanner();
            GetNewsType();
        }


        /// <summary>
        /// 最新消息首頁
        /// </summary>
        /// <param name="ClassType">消息類別</param>
        /// <param name="Page">當前頁數</param>
        /// <param name="searchValue">搜尋內容</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string ClassType, string Page, string searchValue)
        {

            DateTime today = DateTime.Today;

            int itemsPerPage = 5;

            // 根據 ClassType 過濾資料
            IQueryable<NewsPageViewModel> query = from n in _context.News
                                                  where n.NewsPublish == true && n.NewsPutTime < today && n.NewsOffTime > today
                                                  orderby n.NewsNum descending
                                                  select new NewsPageViewModel
                                                  {
                                                      NewsId = n.NewsNum,
                                                      Title = n.NewsTitle,
                                                      Description = n.NewsDescription,
                                                      NewsImg1 = n.NewsImg1,
                                                      CreateTime = n.CreateTime,
                                                      ClassId = n.NewsClass,
                                                      NewsTypeName = (from creator in _context.NewsClasses    
                                                                      where creator.NewsClassNum == n.NewsClass
                                                                      select creator.NewsClassName).FirstOrDefault()!,
                                                      Tag = n.Tag
                                                  };


            if (string.IsNullOrEmpty(ClassType))
            {
                ClassType = "0";
            }
            else
            {
                query = query.Where(x => x.ClassId == Convert.ToInt64(ClassType));
            }


            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(x => x.Tag.Contains(searchValue));
            }


            // 計算總頁數
            int totalPages = (int)Math.Ceiling((double)query.Count() / itemsPerPage);

            // 根據 Page 參數進行分頁
            int currentPage = string.IsNullOrEmpty(Page) ? 1 : Convert.ToInt32(Page);
            query = query.Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage);

            // 傳遞資料到檢視
            ViewBag.ClassType = ClassType;
            ViewBag.Page = currentPage;
            ViewBag.TotalPages = totalPages;

            return View(await query.ToListAsync());
        }


        /// <summary>
        /// 消息文章
        /// </summary>
        /// <param name="id">消息編號</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(long? id)
        {
            GetBanner();

            if (id == null || _context.News == null)
            {
                return NotFound();
            }


            //進入DB搜尋資料
            var newsViewModel = (
                from n in _context.News
                where n.NewsNum == id && n.NewsPublish == true
                select new NewsPageViewModel
                {
                    NewsId = n.NewsNum,
                    Title = n.NewsTitle,
                    Description = n.NewsDescription,
                    NewsImg1 = n.NewsImg1,
                    CreateTime = n.CreateTime,
                    NewsTypeName = (from creator in _context.NewsClasses
                                where creator.NewsClassNum == n.NewsClass
                                select creator.NewsClassName).FirstOrDefault()!,
                    contxt = n.NewsContxt,
                    Tag = n.Tag
                }
            ).FirstOrDefault();


            newsViewModel.getCommants = (
                from c in _context.Comments
                where c.NewsId == id
                select new UserComment
                {
                    UserName= c.UserName,
                    Email= c.Email,
                    Message= c.Message,
                }
            ).ToList();

            if (newsViewModel == null)
            {
                return NotFound();
            }

            return View(newsViewModel);
        }


        /// <summary>
        /// 新增留言
        /// </summary>
        /// <param name="newsPageViewModel">文章 + 留言</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Comments(NewsPageViewModel newsPageViewModel)
        {
            Comment comment = new Comment()
            {
                NewsId = newsPageViewModel.NewsId,
                UserName = newsPageViewModel.postComment.UserName,
                Email = newsPageViewModel.postComment.Email,
                Message = newsPageViewModel.postComment.Message,
            };


            _context.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Details", "NewsPage", new { id = newsPageViewModel.NewsId });
        }
    }
}
