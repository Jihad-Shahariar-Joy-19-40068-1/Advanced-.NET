using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AppointmentRepo : IRepo<Appointment, int, bool>
    {
        HospitalEntities db;

        public AppointmentRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public bool Create(Appointment obj)
        {
            db.Appointments.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var dlts = db.Appointments.FirstOrDefault(x => x.Id == id);
            if (dlts != null)
            {
                db.Appointments.Remove(dlts);
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
            var single = db.Appointments.Find(id);
            if (single != null)
            {
                return single;
            }
            return null;
        }

        public bool Update(Appointment obj)
        {
            var est = db.Appointments.FirstOrDefault(x => x.Id == obj.Id);
            if (est != null)
            {
                db.Entry(est).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
