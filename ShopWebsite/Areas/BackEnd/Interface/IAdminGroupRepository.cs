using ShopWebsite.Areas.BackEnd.ViewModel.AdminGroupViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface IAdminGroupRepository
    {
        public List<AdminGroupIndexViewModel> GetList();


        public AdminGroupCreateViewModel Create();
        public void Create(IFormCollection Collection , long AdminNum);


        public AdminGroupEditViewModel Edit(long? id);
        public void Edit(IFormCollection Collection, long AdminNum);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id);
    }
}
