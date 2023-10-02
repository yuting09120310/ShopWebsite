using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.ViewModel.OrderViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface IOrderRepository
    {
        public List<OrderIndexViewModel> GetList();


        public OrderEditViewModel Edit(long id);
        public void Edit(OrderEditViewModel newsViewModel, long AdminNum);


        public string Delete(long id);
        public void DeleteConfirmed(long id);


        /// <summary>
        /// 取得分類選單
        /// </summary>
        /// <returns>List<SelectListItem></returns>
        public List<SelectListItem> GetNewsClasseList();
    }
}
