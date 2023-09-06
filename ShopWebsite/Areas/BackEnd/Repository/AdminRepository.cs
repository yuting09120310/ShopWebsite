using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.AdminViewModel;

namespace ShopWebsite.Areas.BackEnd.Repository
{
    public class AdminRepository : IAdminRepository
    {

        private ShopWebsiteContext _context;

        public AdminRepository(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public List<AdminIndexViewModel> GetList()
        {
            var admins = _context.Admins.ToList();
            var adminGroups = _context.AdminGroups.ToList();

            List<AdminIndexViewModel> viewModel = (from a in admins
                                                     join g in adminGroups on a.GroupNum equals g.GroupNum into ag
                                                     from subg in ag.DefaultIfEmpty()
                                                     select new AdminIndexViewModel
                                                     {
                                                         AdminNum = a.AdminNum,
                                                         AdminAcc = a.AdminAcc,
                                                         AdminName = a.AdminName,
                                                         AdminPublish = a.AdminPublish,
                                                         GroupName = subg?.GroupName,
                                                         LastLogin = a.LastLogin,
                                                     }).ToList();

            return viewModel;
        }


        /// <summary>
        /// 取得群組選單資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetAdminGroups()
        {
            return _context.AdminGroups
                                    .Where(g => g.GroupPublish == true)
                                    .Select(g => new SelectListItem { Text = g.GroupName, Value = g.GroupNum.ToString() })
                                    .ToList();
        }

       
        public AdminCreateViewModel Create()
        {
            return new AdminCreateViewModel();
        }


        /// <summary>
        /// 建立新資料
        /// </summary>
        /// <param name="adminViewModel"></param>
        public void Create(AdminCreateViewModel adminViewModel, long AdminNum)
        {
            Admin admin = new Admin()
            {
                GroupNum = adminViewModel.GroupNum,
                AdminAcc = adminViewModel.AdminAcc,
                AdminPwd = adminViewModel.AdminPwd,
                AdminName = adminViewModel.AdminName,
                AdminPublish = adminViewModel.AdminPublish,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Creator = AdminNum,
            };

            _context.Add(admin);
            _context.SaveChanges();
        }


        /// <summary>
        /// 取得用戶
        /// </summary>
        /// <param name="adminViewModel"></param>
        public AdminEditViewModel Edit(long? id)
        {
            //進入DB搜尋資料
            var adminViewModel = (
                from admins in _context.Admins
                join adminGroup in _context.AdminGroups on admins.GroupNum equals adminGroup.GroupNum into adminGroups
                from adminGroup in adminGroups.DefaultIfEmpty()
                where admins.AdminNum == id
                select new AdminEditViewModel
                {
                    GroupNum = admins.GroupNum,
                    AdminNum = admins.AdminNum,
                    AdminAcc = admins.AdminAcc,
                    AdminPwd = null,
                    AdminName = admins.AdminName,
                    AdminPublish = admins.AdminPublish,
                }
            ).FirstOrDefault();

            return adminViewModel;
        }


        /// <summary>
        /// 取得用戶
        /// </summary>
        /// <param name="adminViewModel"></param>
        public void Edit(AdminEditViewModel adminViewModel, long AdminNum)
        {
            Admin admin = _context.Admins.Where(x => x.AdminNum == adminViewModel.AdminNum).FirstOrDefault()!;

            admin.GroupNum = adminViewModel.GroupNum;
            admin.AdminAcc = adminViewModel.AdminAcc;
            admin.AdminPwd = adminViewModel.AdminPwd;
            admin.AdminName = adminViewModel.AdminName;
            admin.AdminPublish = adminViewModel.AdminPublish;
            admin.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            admin.Editor = AdminNum;

            _context.Update(admin);
            _context.SaveChanges();
        }


        /// <summary>
        /// 取得刪除json
        /// </summary>
        /// <param name="adminViewModel"></param>
        public string Delete(long? id)
        {
            var admin =  _context.Admins
                .FirstOrDefault(m => m.AdminNum == id);

            return JsonConvert.SerializeObject(admin);
        }


        public void DeleteConfirmed(long? id)
        {
            var admin = _context.Admins.Find(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }

            _context.SaveChangesAsync();
        }
    }
}
