using BLL.BOs;
using DAL;
using DAL.EF;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PatientService
    {
        public static List<PatientModel> Get()      //get all
        {
            var data = DataAccessFactory.GetRegistrationDataAccess().Get();
            var pdata = new List<PatientModel>();
            foreach (var item in data)
            {
                pdata.Add(new PatientModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Type = item.Type,
                    Blood_group = item.Blood_group
                });
            }
            return pdata;
        }
        /*public static List<Registration> GetVariableCount(int count)
        {
            return PatientRepo.Get().Take(count).ToList();
        }*/
        public static PatientModel GetOnly(int id)      //get one
        {
            var item = DataAccessFactory.GetRegistrationDataAccess().Get(id);
            if(item != null)
            {
                var s = new PatientModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Age = item.Age,
                    Gender = item.Gender,
                    Email = item.Email,
                    Phone_no = item.Phone_no,
                    Type = item.Type,
                    Blood_group = item.Blood_group
                };
                return s;
            }
            return null;
        }
        
        public static bool Create(PatientModel item)        //create
        {
            var patient = new Registration()
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
                Salary = item.Salary,
                Department = item.Department,
                Degree = item.Degree,
                Image = item.Image
            };
            return DataAccessFactory.GetRegistrationDataAccess().Create(patient);
        }

        public static bool Update(PatientModel item)        //update
        {
            var patient = new Registration()
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
                Salary = item.Salary,
                Department = item.Department,
                Degree = item.Degree,
                Image = item.Image
            };
            return DataAccessFactory.GetRegistrationDataAccess().Update(patient);
        }
        public static bool Delete(int id)       //delete
        {
            return DataAccessFactory.GetRegistrationDataAccess().Delete(id);
        }
    }
}
