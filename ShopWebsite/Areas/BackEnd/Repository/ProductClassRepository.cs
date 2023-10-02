using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.ProductClassViewModel;

namespace ShopWebsite.Areas.BackEnd.Repository
{
    public class ProductClassRepository : IProductClassRepository
    {

        private ShopWebsiteContext _context;

        public ProductClassRepository(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public List<ProductClassIndexViewModel> GetList()
        {
            List<ProductClassIndexViewModel> viewModel = _context.ProductClasses
                                                 .Select(n => new ProductClassIndexViewModel
                                                 {
                                                     ProductClassNum = n.ProductClassNum,
                                                     ProductClassName = n.ProductClassName,
                                                     CreateTime = n.CreateTime,
                                                     ProductClassPublish = n.ProductClassPublish
                                                 }).ToList();

            return viewModel;
        }


        public ProductClassCreateViewModel Create()
        {
            ProductClassCreateViewModel viewModel = new ProductClassCreateViewModel();
            return viewModel;
        }


        public void Create(ProductClassCreateViewModel newsClassViewModel, long AdminNum)
        {
            ProductClass newsClass = new ProductClass
            {
                ProductClassName = newsClassViewModel.ProductClassName,
                ProductClassSort = newsClassViewModel.ProductClassSort,
                ProductClassPublish = newsClassViewModel.ProductClassPublish,
                Creator = AdminNum,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
            };

            _context.Add(newsClass);
            _context.SaveChangesAsync();
        }


        public ProductClassEditViewModel Edit(long? id)
        {
            //進入DB搜尋資料
            ProductClassEditViewModel newsClassViewModel = (
                from p in _context.ProductClasses
                where p.ProductClassNum == id
                select new ProductClassEditViewModel
                {
                    ProductClassNum = p.ProductClassNum,
                    ProductClassSort = p.ProductClassSort,
                    ProductClassName = p.ProductClassName,
                    ProductClassPublish = p.ProductClassPublish,
                }
            ).FirstOrDefault()!;

            return newsClassViewModel;
        }

        
        public void Edit(ProductClassEditViewModel newsViewModel, long AdminNum)
        {
            ProductClass productClass = _context.ProductClasses.Where(x => x.ProductClassNum == newsViewModel.ProductClassNum).FirstOrDefault()!;

            //將資料寫入db
            productClass.ProductClassName = newsViewModel.ProductClassName;
            productClass.ProductClassSort = newsViewModel.ProductClassSort;
            productClass.ProductClassPublish = newsViewModel.ProductClassPublish;
            productClass.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            productClass.Editor = AdminNum;

            _context.Update(productClass);
            _context.SaveChanges();
        }


        public string Delete(long? id)
        {
            var productClass = _context.ProductClasses
                .FirstOrDefault(m => m.ProductClassNum == id);

            string result = JsonConvert.SerializeObject(productClass);

            return result;
        }


        public void DeleteConfirmed(long? id)
        {
            var productClass = _context.ProductClasses.Find(id);
            if (productClass != null)
            {
                _context.ProductClasses.Remove(productClass);
            }

            _context.SaveChanges();
        }

        
    }
}
