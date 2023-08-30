using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using static ShopWebsite.FrontEnd.ViewModel.NewsPageViewModel;

namespace ShopWebsite.FrontEnd.Controllers
{
    public class NewsPageController : GenericController
    {


        /// <summary>
        /// NewsPageController 的建構函式。
        /// </summary>
        /// <param name="context">資料庫操作的環境。</param>
        public NewsPageController(BlogMvcContext context) : base(context)
        {
            // 調用基底類別的建構函式，並傳遞 BlogMvcContext 上下文對象。
        }


        /// <summary>
        /// 在執行動作之前執行的方法。
        /// </summary>
        /// <param name="context">資料庫操作的環境。</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 執行需要在執行動作之前進行的操作，例如獲取橫幅和新聞類型資訊。
            GetBanner();
            GetNewsType();
        }


        /// <summary>
        /// 根據指定的分類、頁碼和搜尋值檢索相應的新聞資訊並進行分頁顯示。
        /// </summary>
        /// <param name="ClassType">新聞分類的標識。</param>
        /// <param name="Page">當前的頁碼。</param>
        /// <param name="searchValue">用於搜尋的關鍵字。</param>
        /// <returns>表示操作結果的視圖。</returns>
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

            // 根據提供的分類進行資料過濾
            if (string.IsNullOrEmpty(ClassType) || ClassType == "0")
            {
                ClassType = "0";
            }
            else
            {
                query = query.Where(x => x.ClassId == Convert.ToInt64(ClassType));
            }

            // 如果有搜尋條件，進行資料過濾
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
        /// 根據提供的新聞ID檢索相關詳細資訊並顯示於視圖中。
        /// </summary>
        /// <param name="id">要檢索詳細資訊的新聞ID。</param>
        /// <returns>表示操作結果的視圖或錯誤頁面。</returns>
        public async Task<IActionResult> Details(long? id)
        {
            GetBanner();

            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            // 根據提供的新聞ID進行資料庫查詢
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

            // 根據新聞ID檢索相關評論
            newsViewModel.getCommants = (
                from c in _context.Comments
                where c.NewsId == id
                select new UserComment
                {
                    UserName = c.UserName,
                    Email = c.Email,
                    Message = c.Message,
                }
            ).ToList();

            if (newsViewModel == null)
            {
                return NotFound();
            }

            return View(newsViewModel);
        }


        /// <summary>
        /// 接收用戶提交的評論並將其新增至資料庫。
        /// </summary>
        /// <param name="comment">要新增的評論物件。</param>
        /// <returns>表示操作結果的 JSON 訊息。</returns>
        [HttpPost]
        public async Task<IActionResult> Comments([FromBody] Comment comment)
        {
            _context.Add(comment);
            _context.SaveChanges();

            return Json("新增成功");
        }
    }
}
