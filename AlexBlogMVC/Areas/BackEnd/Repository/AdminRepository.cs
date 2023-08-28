using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.ViewModel;

namespace ShopWebsite.Areas.BackEnd.Repository
{
    public class AdminRepository : IAdminRepository
    {

        private BlogMvcContext _context;

        public AdminRepository(BlogMvcContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public List<AdminViewModel> GetList()
        {
            var admins = _context.Admins.ToList();
            var adminGroups = _context.AdminGroups.ToList();

            List<AdminViewModel> viewModel = (from a in admins
                                                     join g in adminGroups on a.GroupNum equals g.GroupNum into ag
                                                     from subg in ag.DefaultIfEmpty()
                                                     select new AdminViewModel
                                                     {
                                                         AdminNum = a.AdminNum,
                                                         AdminAcc = a.AdminAcc,
                                                         AdminName = a.AdminName,
                                                         AdminPublish = a.AdminPublish,
                                                         AdminPwd = a.AdminPwd,
                                                         CreateTime = a.CreateTime,
                                                         Creator = a.Creator,
                                                         EditTime = a.EditTime,
                                                         Editor = a.Editor,
                                                         GroupNum = a.GroupNum,
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


        /// <summary>
        /// 建立新資料
        /// </summary>
        /// <param name="adminViewModel"></param>
        public void PostCreate(AdminViewModel adminViewModel)
        {
            Admin admin = new Admin()
            {
                AdminNum = adminViewModel.AdminNum,
                GroupNum = adminViewModel.GroupNum,
                AdminAcc = adminViewModel.AdminAcc,
                AdminPwd = adminViewModel.AdminPwd,
                AdminName = adminViewModel.AdminName,
                AdminPublish = adminViewModel.AdminPublish,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Creator = Convert.ToInt32(adminViewModel.Creator),
            };

            _context.Add(admin);
            _context.SaveChanges();
        }


        /// <summary>
        /// 取得用戶
        /// </summary>
        /// <param name="adminViewModel"></param>
        public AdminViewModel GetEdit(long? id)
        {
            //進入DB搜尋資料
            var adminViewModel = (
                from admins in _context.Admins
                join adminGroup in _context.AdminGroups on admins.GroupNum equals adminGroup.GroupNum into adminGroups
                from adminGroup in adminGroups.DefaultIfEmpty()
                where admins.AdminNum == id
                select new AdminViewModel
                {
                    AdminNum = admins.AdminNum,
                    GroupName = adminGroup.GroupName,
                    AdminAcc = admins.AdminAcc,
                    AdminPwd = null,
                    AdminName = admins.AdminName,
                    AdminPublish = admins.AdminPublish,
                    LastLogin = admins.LastLogin,
                    CreateTime = admins.CreateTime,
                    Creator = admins.Creator,
                    CreatorName = (from creator in _context.Admins where creator.AdminNum == admins.Creator select creator.AdminName).FirstOrDefault(),
                    EditTime = admins.EditTime,
                    Editor = admins.Editor,
                    EditorName = (from editor in _context.Admins where editor.AdminNum == admins.Editor select editor.AdminName).FirstOrDefault(),
                    Ip = admins.Ip,
                    GroupNum = admins.GroupNum
                }
            ).FirstOrDefault();

            return adminViewModel;
        }


        /// <summary>
        /// 取得用戶
        /// </summary>
        /// <param name="adminViewModel"></param>
        public void PostEdit(AdminViewModel adminViewModel)
        {
            adminViewModel.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            Admin admin = new Admin()
            {
                AdminNum = adminViewModel.AdminNum,
                GroupNum = adminViewModel.GroupNum,
                AdminAcc = adminViewModel.AdminAcc,
                AdminPwd = adminViewModel.AdminPwd,
                AdminName = adminViewModel.AdminName,
                LastLogin = adminViewModel.LastLogin,
                AdminPublish = adminViewModel.AdminPublish,
                CreateTime = adminViewModel.CreateTime,
                Creator = adminViewModel.Creator,
                EditTime = adminViewModel.EditTime,
                Editor = adminViewModel.Editor,
                Ip = adminViewModel.Ip,
            };

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
