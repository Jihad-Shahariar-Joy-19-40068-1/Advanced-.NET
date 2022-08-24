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
    public class Doctor_Epatient
    {
        public static List<EpatientModel> Get()
        {
            var data = DataAccessFactory.GetEpatientDataAccess().Get();
            var rdata = new List<EpatientModel>();
            foreach (var item in data)
            {
                rdata.Add(new EpatientModel()
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
            return rdata;
        }

        public static bool Update(EpatientModel item)
        {
            var doctor = new Epatient()

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

            return DataAccessFactory.GetEpatientDataAccess().Update(doctor);
        }
    }
}
