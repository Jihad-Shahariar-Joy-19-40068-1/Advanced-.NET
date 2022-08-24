using BLL.BOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DoctorServices
{
    public class Doctor_ProblemList
    {
        public static List<ProblemListModel> Get()
        {
            var data = DataAccessFactory.GetProblemListDataAccess().Get();
            var rdata = new List<ProblemListModel>();
            foreach (var item in data)
            {
                rdata.Add(new ProblemListModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Problem = item.Problem,
                    Reason = item.Reason,
                    Room_no = item.Room_no
                });
            }
            return rdata;
        }
        public static bool Create(ProblemListModel item)
        {
            var problem = new ProblemList()
            {
                Id=item.Id,
                Name = item.Name,
                Problem = item.Problem,
                Reason = item.Reason,
                Room_no = item.Room_no

            };
            return DataAccessFactory.GetProblemListDataAccess().Create(problem);
        }
        public static bool Update(ProblemListModel item)
        {
            var problem = new ProblemList()
            {
                Id = item.Id,
                Name = item.Name,
                Problem = item.Problem,
                Reason = item.Reason,
                Room_no = item.Room_no

            };

            return DataAccessFactory.GetProblemListDataAccess().Update(problem);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.GetProblemListDataAccess().Delete(id);
        }
        public static ProblemListModel GetOnly(int id)
        {
            var item = DataAccessFactory.GetProblemListDataAccess().Get(id);
            if (item != null)
            {
                var d = new ProblemListModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Problem = item.Problem,
                    Reason = item.Reason,
                    Room_no = item.Room_no
                };
                return d;
            }
            return null;




        }
    }
}
