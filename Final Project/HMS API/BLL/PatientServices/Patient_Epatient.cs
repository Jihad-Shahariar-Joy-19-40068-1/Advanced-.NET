using BLL.BOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PatientServices
{
    public class Patient_Epatient
    {
        public static List<EpatientModel> Get()      //get all
        {
            var data = DataAccessFactory.GetEpatientDataAccess().Get();
            var edata = new List<EpatientModel>();
            foreach (var item in data)
            {
                edata.Add(new EpatientModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Type = item.Type,
                    Blood_group = item.Blood_group,
                    Checked = item.Checked
                });
            }
            return edata;
        }
        public static List<Epatient> GetVariableCount(int count)
        {
            return DataAccessFactory.GetEpatientDataAccess().Get().Take(count).ToList();
        }
        public static EpatientModel GetOnly(int id)      //get one
        {
            var item = DataAccessFactory.GetEpatientDataAccess().Get(id);
            if (item != null)
            {
                var e = new EpatientModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Type = item.Type,
                    Blood_group = item.Blood_group,
                    Checked = item.Checked
                };
                return e;
            }
            return null;
        }

        public static bool Create(EpatientModel item)        //create
        {
            var epatient = new Epatient()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Gender = item.Gender,
                Email = item.Email,
                Phone_no = item.Phone_no,
                Type = item.Type,
                Blood_group = item.Blood_group,
                Checked = item.Checked
            };
            return DataAccessFactory.GetEpatientDataAccess().Create(epatient);
        }

        public static bool Update(EpatientModel item)        //update
        {
            var epatient = new Epatient()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Gender = item.Gender,
                Email = item.Email,
                Phone_no = item.Phone_no,
                Type = item.Type,
                Blood_group = item.Blood_group,
                Checked = item.Checked
            };
            return DataAccessFactory.GetEpatientDataAccess().Update(epatient);
        }
        public static bool Delete(int id)       //delete
        {
            return DataAccessFactory.GetEpatientDataAccess().Delete(id);
        }
    }
}
