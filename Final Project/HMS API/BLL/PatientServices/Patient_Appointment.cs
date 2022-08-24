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
    public class Patient_Appointment
    {
        public static List<AppointmentModel> Get()      //get all
        {
            var data = DataAccessFactory.GetAppointmentDataAccess().Get();
            var adata = new List<AppointmentModel>();
            foreach (var item in data)
            {
                adata.Add(new AppointmentModel()
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
            return DataAccessFactory.GetAppointmentDataAccess().Get().Take(count).ToList();
        }
        public static AppointmentModel GetOnly(int id)      //get one
        {
            var item = DataAccessFactory.GetAppointmentDataAccess().Get(id);
            if (item != null)
            {
                var a = new AppointmentModel()
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

        public static bool Create(AppointmentModel item)        //create
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
            return DataAccessFactory.GetAppointmentDataAccess().Create(appointmemnt);
        }

        public static bool Update(AppointmentModel item)        //update
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
            return DataAccessFactory.GetAppointmentDataAccess().Update(appointmemnt);
        }
        public static bool Delete(int id)       //delete
        {
            return DataAccessFactory.GetAppointmentDataAccess().Delete(id);
        }
    }
}
