using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.BannerViewModel;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsClassViewModel;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsViewModel;
using ShopWebsite.Areas.ViewModel;
using System.Reflection;

namespace ShopWebsite.Areas.BackEnd.Repository
{
    public class NewsClassRepository : INewsClassRepository
    {

        private ShopWebsiteContext _context;

        public NewsClassRepository(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public List<NewsClassIndexViewModel> GetList()
        {
            List<NewsClassIndexViewModel> viewModel = _context.NewsClasses
                                                 .Select(n => new NewsClassIndexViewModel
                                                 {
                                                     NewsClassNum = n.NewsClassNum,
                                                     NewsClassName = n.NewsClassName,
                                                     CreateTime = n.CreateTime,
                                                     NewsClassPublish = n.NewsClassPublish
                                                 }).ToList();

            return viewModel;
        }


        public NewsClassCreateViewModel Create()
        {
            NewsClassCreateViewModel viewModel = new NewsClassCreateViewModel();
            return viewModel;
        }


        public void Create(NewsClassCreateViewModel newsClassViewModel, long AdminNum)
        {
            NewsClass newsClass = new NewsClass
            {
                NewsClassName = newsClassViewModel.NewsClassName,
                NewsClassSort = newsClassViewModel.NewsClassSort,
                NewsClassPublish = newsClassViewModel.NewsClassPublish,
                Creator = AdminNum,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
            };

            _context.Add(newsClass);
            _context.SaveChangesAsync();
        }


        public NewsClassEditViewModel Edit(long? id)
        {
            //進入DB搜尋資料
            var newsClassViewModel = (
                from newsClasses in _context.NewsClasses
                where newsClasses.NewsClassNum == id
                select new NewsClassEditViewModel
                {
                    NewsClassNum = newsClasses.NewsClassNum,
                    NewsClassSort = newsClasses.NewsClassSort,
                    NewsClassName = newsClasses.NewsClassName,
                    NewsClassPublish = newsClasses.NewsClassPublish,
                }
            ).FirstOrDefault()!;

            return newsClassViewModel;
        }

        
        public void Edit(NewsClassEditViewModel newsViewModel, long AdminNum)
        {
            NewsClass newsClass = _context.NewsClasses.Where(x => x.NewsClassNum == newsViewModel.NewsClassNum).FirstOrDefault()!;

            //將資料寫入db
            newsClass.NewsClassName = newsViewModel.NewsClassName;
            newsClass.NewsClassSort = newsViewModel.NewsClassSort;
            newsClass.NewsClassPublish = newsViewModel.NewsClassPublish;
            newsClass.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            newsClass.Editor = AdminNum;

            _context.Update(newsClass);
            _context.SaveChanges();
        }


        public string Delete(long? id)
        {
            var newsClass = _context.NewsClasses
                .FirstOrDefault(m => m.NewsClassNum == id);

            string result = JsonConvert.SerializeObject(newsClass);

            return result;
        }


        public void DeleteConfirmed(long? id)
        {
            var newsClasses = _context.NewsClasses.Find(id);
            if (newsClasses != null)
            {
                _context.NewsClasses.Remove(newsClasses);
            }

            _context.SaveChanges();
        }

        
    }
}
