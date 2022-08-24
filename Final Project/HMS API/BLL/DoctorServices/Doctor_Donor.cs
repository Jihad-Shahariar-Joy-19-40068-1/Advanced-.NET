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
    public class Doctor_Donor
    {
        public static List<DonorModel> Get()
        {
            var data = DataAccessFactory.GetDonorDataAccess().Get();
            var rdata = new List<DonorModel>();
            foreach (var item in data)
            {
                rdata.Add(new DonorModel()
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
            return rdata;
        }
        public static bool Update(DonorModel item)
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
    }
}
