using ShopWebsite.Areas.BackEnd.ViewModel.NewsClassViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface INewsClassRepository
    {
        public List<NewsClassIndexViewModel> GetList();


        public NewsClassCreateViewModel Create();
        public void Create(NewsClassCreateViewModel newsClassViewModel, long AdminNum);


        public NewsClassEditViewModel Edit(long? id);
        public void Edit(NewsClassEditViewModel newsViewModel, long AdminNum);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id);
    }
}
