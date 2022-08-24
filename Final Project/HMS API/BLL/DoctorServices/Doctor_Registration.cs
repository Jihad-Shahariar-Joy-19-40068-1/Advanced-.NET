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
    public class Doctor_Registration
    {
        public static List<RegistrationModel> Get()
        {
            var data = DataAccessFactory.GetRegistrationDataAccess().Get();
            var rdata = new List<RegistrationModel>();
            foreach (var item in data)
            {
                rdata.Add(new RegistrationModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Type = item.Type,
                    Blood_group = item.Blood_group,
                    Department = item.Department,
                    Degree = item.Degree



                });
            }
            return rdata;
        }
        public static bool Create(RegistrationModel item)
        {
            var doctor = new Registration()
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Age = item.Age,
                Gender = item.Gender,
                Email = item.Email,
                Phone_no = item.Phone_no,
                Type = item.Type,
                Blood_group = item.Blood_group,
                Department = item.Department,
                Degree = item.Degree

            };
            return DataAccessFactory.GetRegistrationDataAccess().Create(doctor);
        }
        public static bool Update(RegistrationModel item)
        {
            var doctor = new Registration()

            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Age = item.Age,
                Gender = item.Gender,
                Email = item.Email,
                Phone_no = item.Phone_no,
                Type = item.Type,
                Blood_group = item.Blood_group,
                Department = item.Department,
                Degree = item.Degree

            };

            return DataAccessFactory.GetRegistrationDataAccess().Update(doctor);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.GetRegistrationDataAccess().Delete(id);
        }
        public static RegistrationModel GetOnly(int id)
        {
            var item = DataAccessFactory.GetRegistrationDataAccess().Get(id);
            if (item != null)
            {
                var d = new RegistrationModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Type = item.Type,
                    Blood_group = item.Blood_group,
                    Department = item.Department,
                    Degree = item.Degree

                };
                return d;

            }
            return null;

        }
    }
}
