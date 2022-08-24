using BLL.BOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AdminServices
{
    public class AdminNoticeService
    {
        public static List<AdminNoticeModel> Get()      //get all
        {
            var data = DataAccessFactory.GetAdminNoticeDataAccess().Get();
            var adata = new List<AdminNoticeModel>();
            foreach (var item in data)
            {
                adata.Add(new AdminNoticeModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Details = item.Details,
                    Type = item.Type
                });
            }
            return adata;
        }
        public static List<Notice> GetVariableCount(int count)
        {
            return DataAccessFactory.GetAdminNoticeDataAccess().Get().Take(count).ToList();
        }
        public static AdminNoticeModel GetOnly(int id)      //get one
        {
            var item = DataAccessFactory.GetAdminNoticeDataAccess().Get(id);
            if (item != null)
            {
                var a = new AdminNoticeModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Details = item.Details,
                    Type = item.Type
                };
                return a;
            }
            return null;
        }
        public static bool Create(AdminNoticeModel item)        //create
        {
            var notice = new Notice()
            {
                Id = item.Id,
                Title = item.Title,
                Details = item.Details,
                Type = item.Type
            };
            return DataAccessFactory.GetAdminNoticeDataAccess().Create(notice);
        }

        public static bool Update(AdminNoticeModel item)        //update
        {
            var notice = new Notice()
            {
                Id = item.Id,
                Title = item.Title,
                Details = item.Details,
                Type = item.Type
            };
            return DataAccessFactory.GetAdminNoticeDataAccess().Update(notice);
        }
        public static bool Delete(int id)       //delete
        {
            return DataAccessFactory.GetAdminNoticeDataAccess().Delete(id);
        }
    }
}
