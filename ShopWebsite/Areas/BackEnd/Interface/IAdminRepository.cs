using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.ViewModel.AdminViewModel;
using ShopWebsite.Areas.ViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface IAdminRepository
    {
        public List<AdminIndexViewModel> GetList();


        public List<SelectListItem> GetAdminGroups();


        public AdminCreateViewModel Create();
        public void Create(AdminCreateViewModel adminViewModel, long AdminNum);


        public AdminEditViewModel Edit(long? id);
        public void Edit(AdminEditViewModel adminViewModel, long AdminNum);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id);
    }
}
