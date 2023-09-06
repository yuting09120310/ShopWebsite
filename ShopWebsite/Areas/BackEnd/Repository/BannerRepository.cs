using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.BannerViewModel;
using ShopWebsite.Areas.ViewModel;

namespace ShopWebsite.Areas.BackEnd.Repository
{
    public class BannerRepository : IBannerRepository
    {

        private ShopWebsiteContext _context;

        public BannerRepository(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public List<BannerIndexViewModel> GetList()
        {
            List<BannerIndexViewModel> viewModel = _context.Banners
                                                        .Select(a => new BannerIndexViewModel
                                                        {
                                                            BannerNum = a.BannerNum,
                                                            BannerTitle = a.BannerTitle,
                                                            BannerDescription = a.BannerDescription,
                                                            BannerPutTime = a.BannerPutTime,
                                                            BannerImg1 = a.BannerImg1,
                                                            CreateTime = a.CreateTime,
                                                            EditTime = a.EditTime,
                                                            BannerOffTime = a.BannerOffTime,
                                                            BannerPublish = a.BannerPublish
                                                        }).ToList();

            return viewModel;
        }


        public BannerCreateViewModel Create()
        {
            BannerCreateViewModel viewModel = new BannerCreateViewModel();
            return viewModel;
        }


        public void Create(BannerCreateViewModel bannerViewModel, long AdminNum)
        {
            Banner banner = new Banner()
            {
                BannerTitle = bannerViewModel.BannerTitle,
                BannerDescription = bannerViewModel.BannerDescription,
                BannerContxt = bannerViewModel.BannerContxt,
                BannerPublish = bannerViewModel.BannerPublish,
                BannerPutTime = bannerViewModel.BannerPutTime,
                BannerOffTime = bannerViewModel.BannerOffTime,
                Creator = AdminNum,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                BannerImg1 = bannerViewModel.BannerImg1.FileName,
            };

            _context.Add(banner);
            _context.SaveChanges();
        }


        public BannerEditViewModel Edit(long? id)
        {
            //進入DB搜尋資料
            var bannerViewModel = (
                from banner in _context.Banners
                where banner.BannerNum == id
                select new BannerEditViewModel
                {
                    BannerNum = banner.BannerNum,
                    BannerTitle = banner.BannerTitle,
                    BannerDescription = banner.BannerDescription,
                    BannerContxt = banner.BannerContxt,
                    BannerPublish = banner.BannerPublish,
                    BannerPutTime = banner.BannerPutTime,
                    BannerOffTime = banner.BannerOffTime,
                    EditTime = banner.EditTime,
                    Editor = banner.Editor,
                    BannerImg1 = new FormFile(new MemoryStream(), 0, 0, banner.BannerImg1.ToString(), banner.BannerImg1.ToString()),
                }
            ).FirstOrDefault();

            return bannerViewModel;
        }

        
        public void Edit(BannerEditViewModel bannerViewModel, long AdminNum)
        {
            Banner banner = _context.Banners.Where(x => x.BannerNum == bannerViewModel.BannerNum).FirstOrDefault()!;

            //將資料寫入db
            banner.BannerNum = bannerViewModel.BannerNum;
            banner.BannerTitle = bannerViewModel.BannerTitle;
            banner.BannerDescription = bannerViewModel.BannerDescription;
            banner.BannerContxt = bannerViewModel.BannerContxt;
            banner.BannerPublish = bannerViewModel.BannerPublish;
            banner.BannerPutTime = bannerViewModel.BannerPutTime;
            banner.BannerOffTime = bannerViewModel.BannerOffTime;
            banner.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            banner.Editor = AdminNum;

            if (bannerViewModel.BannerImg1 != null)
            {
                banner.BannerImg1 = bannerViewModel.BannerImg1.FileName;
            }

            _context.Update(banner);
            _context.SaveChanges();
        }


        public string Delete(long? id)
        {
            var banner = _context.Banners
                .FirstOrDefault(m => m.BannerNum == id);

            string result = JsonConvert.SerializeObject(banner);

            return result;
        }


        public void DeleteConfirmed(long? id, string path)
        {
            var banner = _context.Banners.Find(id);
            if (banner != null)
            {
                _context.Banners.Remove(banner);
            }

            _context.SaveChanges();

            //取得該篇廣告的圖片並刪除
            var direPath = Path.Combine(path, "uploads", "Banner");
            var filePath = Path.Combine(direPath, banner.BannerImg1);
            System.IO.File.Delete(filePath);
        }


        public void SaveFile(IFormFile file, string path)
        {
            var direPath = Path.Combine(path, "uploads", "Banner");
            if (!Directory.Exists(direPath))
            {
                Directory.CreateDirectory(direPath);
            }

            var filePath = Path.Combine(direPath, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(fileStream);
            }
        }
    }
}
