using BLL.BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DoctorServices
{
    public class Doctor_Notice
    {
        public static List<NoticeModel> Get()
        {
            var data = DataAccessFactory.GetNoticeDataAccess().Get();
            var rdata = new List<NoticeModel>();
            foreach (var item in data)
            {
                rdata.Add(new NoticeModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Details = item.Details,
                    Type = item.Type
                });
            }
            return rdata;
        }
    }
}
