using BLL.BOs;
using DAL.EF;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static List<StudentModel> Get()
        {
            var data = StudentRepo.Get();
            var rdata = new List<StudentModel>();
            foreach (var item in data)
            {
                rdata.Add(new StudentModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    Uid = item.Uid,
                    Dob = item.Dob,
                    Email = item.Email,
                    DepartmentId = item.DepartmentId
                });
            }
            return rdata;
        }
        public static List<Student> GetVariableCount(int count)
        {
            return StudentRepo.Get().Take(count).ToList();
        }
        public static StudentModel GetOnly(int id)
        {
            var item = StudentRepo.Get(id);
            var s = new StudentModel() 
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Uid = item.Uid,
                Dob = item.Dob,
                Email = item.Email,
                DepartmentId = item.DepartmentId
            };
            return s;
        }
        /*public static Student Get(int id)
        {
            return StudentRepo.Get(id);
        }*/
        public static bool Create(StudentModel item)
        {
            var student = new Student()
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Uid = item.Uid,
                Dob = item.Dob,
                Email = item.Email,
                DepartmentId = item.DepartmentId
            };
            return StudentRepo.Create(student);
        }
        
        public static bool Update(StudentModel item)
        {
            var student = new Student()
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                Uid = item.Uid,
                Dob = item.Dob,
                Email = item.Email,
                DepartmentId = item.DepartmentId
            };
            return StudentRepo.Update(student);
        }
        public static bool Delete(int id)
        {
            return StudentRepo.Delete(id);
        }
    }
}
