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
    public class Patient_Donor
    {
        public static List<DonorModel> Get()      //get all
        {
            var data = DataAccessFactory.GetDonorDataAccess().Get();
            var pdata = new List<DonorModel>();
            foreach (var item in data)
            {
                pdata.Add(new DonorModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Gender = item.Gender,
                    Phone_no = item.Phone_no,
                    Blood_group = item.Blood_group,
                    Organ_type = item.Organ_type,
                    Blood_pressure = item.Blood_pressure,
                    Diabetes = item.Diabetes,
                    Allergy = item.Allergy,
                    Asthama = item.Asthama,
                    Approval = item.Approval,
                    Approved_by = item.Approved_by,
                    Location = item.Location
                });
            }
            return pdata;
        }
        public static List<Donor> GetVariableCount(int count)
        {
            return DataAccessFactory.GetDonorDataAccess().Get().Take(count).ToList();
        }
        public static DonorModel GetOnly(int id)      //get one
        {
            var item = DataAccessFactory.GetDonorDataAccess().Get(id);
            if (item != null)
            {
                var d = new DonorModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Gender = item.Gender,
                    Phone_no = item.Phone_no,
                    Blood_group = item.Blood_group,
                    Organ_type = item.Organ_type,
                    Blood_pressure = item.Blood_pressure,
                    Diabetes = item.Diabetes,
                    Allergy = item.Allergy,
                    Asthama = item.Asthama,
                    Approval = item.Approval,
                    Approved_by = item.Approved_by,
                    Location = item.Location
                };
                return d;
            }
            return null;
        }

        public static bool Create(DonorModel item)        //create
        {
            var donor = new Donor()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Gender = item.Gender,
                Phone_no = item.Phone_no,
                Blood_group = item.Blood_group,
                Organ_type = item.Organ_type,
                Blood_pressure = item.Blood_pressure,
                Diabetes = item.Diabetes,
                Allergy = item.Allergy,
                Asthama = item.Asthama,
                Approval = item.Approval,
                Approved_by = item.Approved_by,
                Location = item.Location
            };
            return DataAccessFactory.GetDonorDataAccess().Create(donor);
        }

        public static bool Update(DonorModel item)        //update
        {
            var donor = new Donor()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Gender = item.Gender,
                Phone_no = item.Phone_no,
                Blood_group = item.Blood_group,
                Organ_type = item.Organ_type,
                Blood_pressure = item.Blood_pressure,
                Diabetes = item.Diabetes,
                Allergy = item.Allergy,
                Asthama = item.Asthama,
                Approval = item.Approval,
                Approved_by = item.Approved_by,
                Location = item.Location
            };
            return DataAccessFactory.GetDonorDataAccess().Update(donor);
        }
        public static bool Delete(int id)       //delete
        {
            return DataAccessFactory.GetDonorDataAccess().Delete(id);
        }
    }
}
