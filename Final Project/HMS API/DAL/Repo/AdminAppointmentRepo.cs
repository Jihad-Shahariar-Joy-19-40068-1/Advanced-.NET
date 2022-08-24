using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminAppointmentRepo : AdminIRepo<Appointment, int>
    {
        HospitalEntities db;
        public AdminAppointmentRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public bool Create(Appointment obj)
        {
            db.Appointments.Add(obj);      //create 
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var exst = db.Appointments.FirstOrDefault(x => x.Id == id);
            if (exst != null)
            {
                db.Appointments.Remove(Get(id));       //delete
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Appointment> Get()
        {
            return db.Appointments.ToList();
        }

        public Appointment Get(int id)
        {
            var appointment = db.Appointments.Find(id);    //get one
            if (appointment != null)
            {
                return appointment;
            }
            return null;
        }

        public bool Update(Appointment obj)
        {
            var exst = db.Appointments.FirstOrDefault(x => x.Id == obj.Id);
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(obj);    //update 
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
