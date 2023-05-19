using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexBlogMVC.BackEnd.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using AlexBlogMVC.BackEnd.ViewModel;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class NewsClassController : GenericController
    {
        int menuSubNum = 6;

        public NewsClassController(BlogMvcContext context) : base(context) { }


        public async Task<IActionResult> Index()
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "R"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion

            ViewBag.PageTitle = "消息類別列表";

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
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "C"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion

            ViewBag.PageTitle = "新增消息類別";

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
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "C"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


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
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion

            ViewBag.PageTitle = "編輯消息類別";

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
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


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
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "D"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion

            if (id == null || _context.NewsClasses == null)
            {
                return NotFound();
            }

            var newsClass = await _context.NewsClasses
                .FirstOrDefaultAsync(m => m.NewsClassNum == id);
            if (newsClass == null)
            {
                return NotFound();
            }

            return View(newsClass);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
            return RedirectToAction(nameof(Index));
        }


        private bool NewsClassExists(long id)
        {
          return (_context.NewsClasses?.Any(e => e.NewsClassNum == id)).GetValueOrDefault();
        }
    }
}
