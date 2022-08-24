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
    public class AdminAppointmentService
    {
        public static List<AdminAppointmentModel> Get()      //get all
        {
            var data = DataAccessFactory.GetAdminAppointmentDataAccess().Get();
            var adata = new List<AdminAppointmentModel>();
            foreach (var item in data)
            {
                adata.Add(new AdminAppointmentModel()
                {
                    Id = item.Id,
                    Doctor_Name = item.Doctor_Name,
                    Patient_Name = item.Patient_Name,
                    Problem_list = item.Problem_list,
                    Prescription_File = item.Prescription_File,
                    Prescription = item.Prescription,
                    Payment_status = item.Payment_status,
                    Prescribed = item.Prescribed
                });
            }
            return adata;
        }
        public static List<Appointment> GetVariableCount(int count)
        {
            return DataAccessFactory.GetAdminAppointmentDataAccess().Get().Take(count).ToList();
        }

        public static AdminAppointmentModel GetOnly(int id)      //get one
        {
            var item = DataAccessFactory.GetAdminAppointmentDataAccess().Get(id);
            if (item != null)
            {
                var a = new AdminAppointmentModel()
                {
                    Id = item.Id,
                    Doctor_Name = item.Doctor_Name,
                    Patient_Name = item.Patient_Name,
                    Problem_list = item.Problem_list,
                    Prescription_File = item.Prescription_File,
                    Prescription = item.Prescription,
                    Payment_status = item.Payment_status,
                    Prescribed = item.Prescribed
                };
                return a;
            }
            return null;
        }
        public static bool Create(AdminAppointmentModel item)        //create
        {
            var appointmemnt = new Appointment()
            {
                Id = item.Id,
                Doctor_Name = item.Doctor_Name,
                Patient_Name = item.Patient_Name,
                Problem_list = item.Problem_list,
                Prescription_File = item.Prescription_File,
                Prescription = item.Prescription,
                Payment_status = item.Payment_status,
                Prescribed = item.Prescribed
            };
            return DataAccessFactory.GetAdminAppointmentDataAccess().Create(appointmemnt);
        }

        public static bool Update(AdminAppointmentModel item)        //update
        {
            var appointmemnt = new Appointment()
            {
                Id = item.Id,
                Doctor_Name = item.Doctor_Name,
                Patient_Name = item.Patient_Name,
                Problem_list = item.Problem_list,
                Prescription_File = item.Prescription_File,
                Prescription = item.Prescription,
                Payment_status = item.Payment_status,
                Prescribed = item.Prescribed
            };
            return DataAccessFactory.GetAdminAppointmentDataAccess().Update(appointmemnt);
        }
        public static bool Delete(int id)       //delete
        {
            return DataAccessFactory.GetAdminAppointmentDataAccess().Delete(id);
        }
    }
}
