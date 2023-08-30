using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.ViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface IAdminRepository
    {
        public List<AdminViewModel> GetList();


        public List<SelectListItem> GetAdminGroups();


        public void Create(AdminViewModel adminViewModel);


        public AdminViewModel Edit(long? id);
        public void Edit(AdminViewModel adminViewModel);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id);
    }
}
