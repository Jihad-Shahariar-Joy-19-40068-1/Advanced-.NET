using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class EpatientRepo : IRepo_Patient<Epatient, int>
    {
        HospitalEntities db;
        public EpatientRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public List<Epatient> Get()
        {
            return db.Epatients.ToList();
        }

        public Epatient Get(int id)
        {
            var epatient = db.Epatients.Find(id);
            if (epatient != null)
            {
                return epatient;
            }
            return null;
        }

        public bool Create(Epatient obj)
        {
            db.Epatients.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }
        public bool Update(Epatient obj)
        {
            var exst = db.Epatients.FirstOrDefault(x => x.Id == obj.Id);
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
            var exst = db.Epatients.FirstOrDefault(x => x.Id == id);
            if (exst != null)
            {
                db.Epatients.Remove(exst);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
