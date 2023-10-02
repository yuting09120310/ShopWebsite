using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.ProductViewModel;

namespace ShopWebsite.Areas.BackEnd.Repository
{
    public class ProductRepository : IProductRepository
    {

        private ShopWebsiteContext _context;

        public ProductRepository(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public List<ProductIndexViewModel> GetList()
        {
            List<ProductIndexViewModel> viewModel = _context.Products
                                            .Select(n => new ProductIndexViewModel
                                            {
                                                ProductNum = n.ProductNum,
                                                ProductTitle = n.ProductTitle,
                                                ProductDescription = n.ProductDescription,
                                                ProductImg1 = n.ProductImg1,
                                                ProductPutTime = n.ProductPutTime,
                                                CreateTime = n.CreateTime,
                                                EditTime = n.EditTime,
                                                ProductOffTime = n.ProductOffTime,
                                                ProductPublish = n.ProductPublish
                                            }).ToList();

            return viewModel;
        }


        public ProductCreateViewModel Create()
        {
            ProductCreateViewModel viewModel = new ProductCreateViewModel();
            return viewModel;
        }


        public void Create(ProductCreateViewModel ProductViewModel, long AdminNum)
        {
            Product Product = new Product()
            {
                ProductClass = ProductViewModel.ProductClass,
                ProductTitle = ProductViewModel.ProductTitle,
                ProductDescription = ProductViewModel.ProductDescription,
                ProductContxt = ProductViewModel.ProductContxt,
                ProductImg1 = ProductViewModel.ProductImg1.FileName,
                ProductPublish = ProductViewModel.ProductPublish,
                ProductPutTime = ProductViewModel.ProductPutTime,
                ProductOffTime = ProductViewModel.ProductOffTime,
                Creator = AdminNum,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Tag = ProductViewModel.Tag
            };

            _context.Add(Product);
            _context.SaveChanges();
        }


        public ProductEditViewModel Edit(long? id)
        {
            //進入DB搜尋資料
            ProductEditViewModel ProductViewModel = (
                from Product in _context.Products
                where Product.ProductNum == id
                select new ProductEditViewModel
                {
                    ProductNum = Product.ProductNum,
                    ProductTitle = Product.ProductTitle,
                    ProductClass = Product.ProductClass,
                    ProductDescription = Product.ProductDescription,
                    ProductContxt = Product.ProductContxt,
                    ProductPublish = Product.ProductPublish,
                    ProductPutTime = Product.ProductPutTime,
                    ProductOffTime = Product.ProductOffTime,
                    ProductImg1 = new FormFile(new MemoryStream(), 0, 0, Product.ProductImg1.ToString(), Product.ProductImg1.ToString()),
                    Tag = Product.Tag
                }
            ).FirstOrDefault()!;

            return ProductViewModel;
        }

        
        public void Edit(ProductEditViewModel ProductViewModel, long AdminNum)
        {
            Product Product = _context.Products.Where(x => x.ProductNum == ProductViewModel.ProductNum).FirstOrDefault()!;

            //將資料寫入db
            Product.ProductTitle = ProductViewModel.ProductTitle;
            Product.ProductClass = ProductViewModel.ProductClass;
            Product.ProductDescription = ProductViewModel.ProductDescription;
            Product.ProductContxt = ProductViewModel.ProductContxt;
            Product.ProductPublish = ProductViewModel.ProductPublish;
            Product.ProductPutTime = ProductViewModel.ProductPutTime;
            Product.ProductOffTime = ProductViewModel.ProductOffTime;
            Product.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Product.Editor = AdminNum;

            if (ProductViewModel.ProductImg1 != null)
            {
                Product.ProductImg1 = ProductViewModel.ProductImg1.FileName;
            }

            _context.Update(Product);
            _context.SaveChanges();
        }


        public string Delete(long? id)
        {
            var Product = _context.Products
               .FirstOrDefault(m => m.ProductNum == id);

            string result = JsonConvert.SerializeObject(Product);

            return result;
        }


        public void DeleteConfirmed(long? id, string path)
        {
            var Product = _context.Products.Find(id);
            if (Product != null)
            {
                _context.Products.Remove(Product);
            }

            _context.SaveChanges();

            //取得該篇文章的圖片並刪除
            var direPath = Path.Combine(path, "uploads", "Product");
            var filePath = Path.Combine(direPath, Product.ProductImg1);
            System.IO.File.Delete(filePath);
        }


        public void SaveFile(IFormFile file, string path)
        {
            var direPath = Path.Combine(path, "uploads", "Product");
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


        public void SaveFile(List<IFormFile> file, string path)
        {
            var direPath = Path.Combine(path, "uploads", "Product");
            if (!Directory.Exists(direPath))
            {
                Directory.CreateDirectory(direPath);
            }

            foreach( var item in file)
            {
                var filePath = Path.Combine(direPath, item.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    item.CopyTo(fileStream);
                }
            }
        }



        public List<SelectListItem> GetProductClasseList()
        {
            return _context.ProductClasses
                           .Where(g => g.ProductClassPublish == true)
                           .Select(g => new SelectListItem { Text = g.ProductClassName, Value = g.ProductClassNum.ToString() })
                           .ToList();
        }
    }
}
