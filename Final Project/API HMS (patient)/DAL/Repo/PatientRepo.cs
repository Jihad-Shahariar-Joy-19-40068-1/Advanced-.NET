using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class PatientRepo : IRepo_Patient<Registration, int, bool>
    {
        HospitalEntities db;
        public PatientRepo(HospitalEntities db)
        {
            this.db = db;
        }
        public List<Registration> Get()
        {
            return db.Registrations.ToList();
        }
        public Registration Get(int id)
        {
            var patient = db.Registrations.Find(id);
            if (patient != null)
            {
                return patient;
            }
            return null;
        }
        public bool Create(Registration obj)
        {
            db.Registrations.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }
        public bool Update(Registration obj)
        {
            var exst = db.Registrations.FirstOrDefault(x => x.Id == obj.Id);
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var exst = db.Registrations.FirstOrDefault(x => x.Id == id);
            if (exst != null)
            {
                db.Registrations.Remove(exst);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
