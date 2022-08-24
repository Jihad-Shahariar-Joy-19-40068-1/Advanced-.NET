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
    public class AdminUserService
    {
        public static List<AdminRegistrationModel> Get()      //get all
        {
            var data = DataAccessFactory.GetAdminUserDataAccess().Get();
            var adata = new List<AdminRegistrationModel>();
            foreach (var item in data)
            {
                adata.Add(new AdminRegistrationModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Blood_group = item.Blood_group,
                    Type = item.Type,
                    Salary = item.Salary,
                    Department = item.Department,
                    Degree = item.Degree
                });
            }
            return adata;
        }
        public static AdminRegistrationModel GetOnly(int id)      //get one
        {
            var item = DataAccessFactory.GetAdminUserDataAccess().Get(id);
            if (item != null)
            {
                var s = new AdminRegistrationModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Blood_group = item.Blood_group,
                    Type = item.Type,
                    Salary = item.Salary,
                    Department = item.Department,
                    Degree = item.Degree
                };
                return s;
            }
            return null;
        }
        public static bool Create(AdminRegistrationModel item)        //create
        {
            var registration = new Registration()
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Age = item.Age,
                Gender = item.Gender,
                Email = item.Email,
                Phone_no = item.Phone_no,
                Blood_group = item.Blood_group,
                Type = item.Type,
                Salary = item.Salary,
                Department = item.Department,
                Degree = item.Degree
            };
            return DataAccessFactory.GetAdminUserDataAccess().Create(registration);
        }
        public static bool Update(AdminRegistrationModel item)        //update
        {
            var regiter = new Registration()
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Age = item.Age,
                Gender = item.Gender,
                Email = item.Email,
                Phone_no = item.Phone_no,
                Blood_group = item.Blood_group,
                Type = item.Type,
                Salary = item.Salary,
                Department = item.Department,
                Degree = item.Degree
            };
            return DataAccessFactory.GetAdminUserDataAccess().Update(regiter);
        }
        public static bool Delete(int id)       //delete
        {
            return DataAccessFactory.GetAdminUserDataAccess().Delete(id);
        }
        public static List<AdminRegistrationModel> Getdoc()      //get all
        {
            var data = DataAccessFactory.GetAdminDoctorDataAccess().Getdoc();
            var adata = new List<AdminRegistrationModel>();

            foreach (var item in data)
            {
                adata.Add(new AdminRegistrationModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Blood_group = item.Blood_group,
                    Type = item.Type,
                    Salary = item.Salary,
                    Department = item.Department,
                    Degree = item.Degree

                });
            }
            return adata;
        }

        public static int Dcccount()      //get all
        {
            return DataAccessFactory.GetAdminDoctorDataAccess().Dcccount();



        }
        public static int Patientcount()      //get all
        {
            return DataAccessFactory.GetAdminPatientDataAccess().Patientcount();



        }





        public static List<AdminRegistrationModel> GetPatient()      //get all
        {
            var data = DataAccessFactory.GetAdminPatientDataAccess().GetPatient();
            var adata = new List<AdminRegistrationModel>();
            foreach (var item in data)
            {
                adata.Add(new AdminRegistrationModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Blood_group = item.Blood_group,
                    Type = item.Type,

                });
            }
            return adata;
        }
    }
}
