using ShopWebsite.Areas.ViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface IAdminGroupRepository
    {
        public List<AdminGroupViewModel> GetList();


        public AdminGroupViewModel Create();
        public void Create(IFormCollection Collection , long AdminNum);


        public AdminGroupViewModel Edit(long? id);
        public void Edit(IFormCollection Collection, long AdminNum);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id);
    }
}
