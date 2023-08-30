using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ShopWebsite.Areas.Controllers
{
    public class NewsClassController : GenericController
    {
        int menuSubNum = 6;

        public NewsClassController(BlogMvcContext context) : base(context) { }


        public async Task<IActionResult> Index()
        {
            GetMenu();

            IEnumerable<NewsClassViewModel> viewModel = from n in _context.NewsClasses
                                                   select new NewsClassViewModel
                                                   {
                                                       NewsClassNum = n.NewsClassNum,
                                                       NewsClassName = n.NewsClassName,
                                                       CreateTime = n.CreateTime,
                                                       NewsClassPublish = n.NewsClassPublish
                                                   };

            return View(viewModel);
        }


        public IActionResult Create()
        {
            GetMenu();

            NewsClassViewModel newsClassViewModel = new NewsClassViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName")
            };

            return View(newsClassViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsClassViewModel newsClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {

                NewsClass newsClass = new NewsClass
                {
                    NewsClassName = newsClassViewModel.NewsClassName,
                    NewsClassSort = newsClassViewModel.NewsClassSort,
                    NewsClassPublish = newsClassViewModel.NewsClassPublish,
                    Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                };

                _context.Add(newsClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(newsClassViewModel);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            if (id == null)
            {
                return NotFound();
            }

            var newsClass = await _context.NewsClasses.FindAsync(id);
            if (newsClass == null)
            {
                return NotFound();
            }


            //進入DB搜尋資料
            var newsClassViewModel = (
                from newsClasses in _context.NewsClasses
                where newsClasses.NewsClassNum == id
                select new NewsClassViewModel
                {
                    NewsClassNum = newsClasses.NewsClassNum,
                    NewsClassSort = newsClasses.NewsClassSort,
                    NewsClassId= newsClasses.NewsClassId,
                    NewsClassName = newsClasses.NewsClassName,
                    NewsClassLevel = newsClasses.NewsClassLevel,
                    NewsClassPre = newsClasses.NewsClassPre,
                    NewsClassPublish = newsClasses.NewsClassPublish,

                    CreateTime = newsClasses.CreateTime,
                    Creator = newsClasses.Creator,
                    CreatorName = (from creator in _context.Admins where creator.AdminNum == newsClasses.Creator select creator.AdminName).FirstOrDefault(),
                    EditTime = newsClasses.EditTime,
                    Editor = newsClasses.Editor,
                    EditorName = (from editor in _context.Admins where editor.AdminNum == newsClasses.Editor select editor.AdminName).FirstOrDefault(),
                    Ip = newsClasses.Ip,
                }
            ).FirstOrDefault();


            return View(newsClassViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsClassViewModel newsClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                try
                {
                    //將資料寫入db
                    NewsClass newsClass = new NewsClass()
                    {
                        NewsClassNum = newsClassViewModel.NewsClassNum,
                        NewsClassSort = newsClassViewModel.NewsClassSort,
                        NewsClassId = newsClassViewModel.NewsClassId,
                        NewsClassName = newsClassViewModel.NewsClassName,
                        NewsClassLevel = newsClassViewModel.NewsClassLevel,
                        NewsClassPre = newsClassViewModel.NewsClassPre,
                        NewsClassPublish = newsClassViewModel.NewsClassPublish,
                        CreateTime = newsClassViewModel.CreateTime,
                        Creator = newsClassViewModel.Creator,
                        EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                        Ip = newsClassViewModel.Ip,
                    };


                    _context.Update(newsClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsClassExists(newsClassViewModel.NewsClassNum))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(newsClassViewModel);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            var newsClass = await _context.NewsClasses
                .FirstOrDefaultAsync(m => m.NewsClassNum == id);

            string res = JsonConvert.SerializeObject(newsClass);

            return Json(res);
        }


        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.NewsClasses == null)
            {
                return Problem("Entity set 'BlogMvcContext.NewsClasses'  is null.");
            }
            var newsClass = await _context.NewsClasses.FindAsync(id);
            if (newsClass != null)
            {
                _context.NewsClasses.Remove(newsClass);
            }
            
            await _context.SaveChangesAsync();
            return Json("刪除完成");
        }


        private bool NewsClassExists(long id)
        {
          return (_context.NewsClasses?.Any(e => e.NewsClassNum == id)).GetValueOrDefault();
        }
    }
}
