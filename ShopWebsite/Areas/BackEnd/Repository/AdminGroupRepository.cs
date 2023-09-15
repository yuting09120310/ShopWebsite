using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.AdminGroupViewModel;

namespace ShopWebsite.Areas.BackEnd.Repository
{
    public class AdminGroupRepository : IAdminGroupRepository
    {

        private ShopWebsiteContext _context;

        public AdminGroupRepository(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public List<AdminGroupIndexViewModel> GetList()
        {
            var admins = _context.Admins.ToList();
            var adminGroups = _context.AdminGroups.ToList();

            var viewModel = (from g in adminGroups
                             select new AdminGroupIndexViewModel
                             {
                                 GroupNum = g.GroupNum,
                                 GroupName = g.GroupName,
                                 GroupPublish = g.GroupPublish,
                                 CreateTime = g.CreateTime,
                             }).ToList();

            return viewModel;
        }


        public AdminGroupCreateViewModel Create()
        {
            AdminGroupCreateViewModel viewModel = new AdminGroupCreateViewModel()
            {
                GroupName = "",
                GroupInfo = "",
                GroupPublish = true,

                AdminRoleModels = new List<AdminRole>(),
                MenuGroupModels = _context.MenuGroups.Where(x => x.MenuGroupPublish == true).ToList(),
                MenuSubModels = _context.MenuSubs.Where(x => x.MenuSubPublish == true).ToList(),
            };

            return viewModel;
        }


        public void Create(IFormCollection Collection, long AdminNum)
        {
            AdminGroup adminGroup = new AdminGroup()
            {
                GroupPublish = Convert.ToBoolean(Collection["GroupPublish"]),
                GroupName = Collection["GroupName"],
                GroupInfo = Collection["GroupInfo"],
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Creator = AdminNum,
            };

            _context.Add(adminGroup);
            _context.SaveChanges();

            //取得關於Role開頭的Key 重組成字典 以便於後續操作
            Dictionary<string, string> roleDicts = Collection
             .Where(kv => kv.Key.StartsWith("Role"))
             .Select(kv => new KeyValuePair<string, string>(kv.Key.Split('_')[1], kv.Value!))
             .ToDictionary(kv => kv.Key, kv => kv.Value);


            //將取出開頭包含Role的字典 跑迴圈 並逐筆變更
            foreach (string roleDict in roleDicts.Keys)
            {
                long menuSubNum = Convert.ToInt64(roleDict);
                AdminRole ar = new AdminRole()
                {
                    GroupNum = adminGroup.GroupNum,
                    MenuSubNum = menuSubNum,
                    Role = roleDicts[roleDict],
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Creator = AdminNum,
                };
                _context.Add(ar);
                _context.SaveChanges();
            }
        }



        public AdminGroupEditViewModel Edit(long? id)
        {
            AdminGroup adminGroup = _context.AdminGroups.Find(id);
            
            AdminGroupEditViewModel adminGroupViewModel = new AdminGroupEditViewModel()
            {
                GroupName = adminGroup.GroupName,
                GroupInfo = adminGroup.GroupInfo,
                GroupPublish = adminGroup.GroupPublish,
                GroupNum = adminGroup.GroupNum,

                AdminRoleModels = _context.AdminRoles.Where(x => x.GroupNum == id).ToList(),
                MenuGroupModels = _context.MenuGroups.Where(x => x.MenuGroupPublish == true).ToList(),
                MenuSubModels = _context.MenuSubs.Where(x => x.MenuSubPublish == true).ToList(),
            };

            return adminGroupViewModel;
        }

        
        public void Edit(IFormCollection Collection, long AdminNum)
        {
            //取得變更的群組id
            int groupNum = Convert.ToInt32(Collection["GroupNum"]);


            //取得關於Role開頭的Key 重組成字典 以便於後續操作
            Dictionary<string, string> roleDicts = Collection
             .Where(kv => kv.Key.StartsWith("Role"))
             .Select(kv => new KeyValuePair<string, string>(kv.Key.Split('_')[1], kv.Value!))
             .ToDictionary(kv => kv.Key, kv => kv.Value);


            //將取出開頭包含Role的字典 跑迴圈 並逐筆變更
            foreach (string roleDict in roleDicts.Keys)
            {
                long menuSubNum = Convert.ToInt64(roleDict);
                AdminRole ar = _context.AdminRoles.Where(x => x.GroupNum == groupNum && x.MenuSubNum == menuSubNum).FirstOrDefault();
                if (ar != null)
                {
                    ar.Role = roleDicts[roleDict];
                    _context.Update(ar);
                }
                else
                {
                    ar = new AdminRole()
                    {
                        GroupNum = groupNum,
                        MenuSubNum = menuSubNum,
                        Role = roleDicts[roleDict],
                        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        Creator = AdminNum,
                    };
                    _context.AdminRoles.Add(ar);
                }
            }


            AdminGroup adminGroup = _context.AdminGroups.Where(x => x.GroupNum == groupNum).FirstOrDefault();
            adminGroup.GroupName = Collection["GroupName"].ToString();
            adminGroup.GroupInfo = Collection["GroupInfo"].ToString();
            adminGroup.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            adminGroup.Editor = AdminNum;
            _context.Update(adminGroup);


            _context.SaveChangesAsync();
        }


        public string Delete(long? id)
        {
            var adminGroup = _context.AdminGroups
                .FirstOrDefault(m => m.GroupNum == id);

            string result = JsonConvert.SerializeObject(adminGroup);

            return result;
        }


        public void DeleteConfirmed(long? id)
        {
            var adminGroup = _context.AdminGroups.Find(id);
            if (adminGroup != null)
            {
                _context.AdminGroups.Remove(adminGroup);
            }

            var adminRole =  _context.AdminRoles.Where(x => x.GroupNum == id).ToList();
            adminRole.ForEach(x => _context.AdminRoles.Remove(x));

            _context.SaveChanges();
        }
    }
}
