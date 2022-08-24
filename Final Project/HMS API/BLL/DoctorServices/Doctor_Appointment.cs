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
    public class Doctor_Appointment
    {
        public static List<AppointmentModel> Get()
        {
            var data = DataAccessFactory.GetAppointmentDataAccess().Get();
            var rdata = new List<AppointmentModel>();
            foreach (var item in data)
            {
                rdata.Add(new AppointmentModel()
                {
                    Id = item.Id,
                    Doctor_Name = item.Doctor_Name,
                    Patient_Name = item.Patient_Name,
                    Problem_list = item.Problem_list,
                    Prescription_File = item.Prescription_File,
                    Prescription = item.Prescription,
                    Payment_status = item.Payment_status,
                    Prescribed = item.Prescribed,

                });
            }
            return rdata;
        }

        public static bool Update(AppointmentModel item)
        {
            var appointment = new Appointment()
            {
                Id = item.Id,
                Patient_Name = item.Patient_Name,
                Problem_list = item.Problem_list,
                Prescription_File = item.Prescription_File,
                Doctor_Name = item.Doctor_Name,
                Prescription = item.Prescription,
                Payment_status = item.Payment_status,
                Prescribed = item.Prescribed,
            };
            return DataAccessFactory.GetAppointmentDataAccess().Update(appointment);
        }
    }
}
