using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class EpatientRepo : IRepo<Epatient, int, bool>
    {
        HospitalEntities db;

        public EpatientRepo(HospitalEntities db)
        {
            this.db = db;
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

        public bool Delete(int id)
        {
            var dlts = db.Epatients.FirstOrDefault(x => x.Id == id);
            if (dlts != null)
            {
                db.Epatients.Remove(dlts);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Epatient> Get()
        {
            return db.Epatients.ToList();
        }

        public Epatient Get(int id)
        {
            var single = db.Epatients.Find(id);
            if (single != null)
            {
                return single;
            }
            return null;
        }

        public bool Update(Epatient obj)
        {
            var est = db.Epatients.FirstOrDefault(x => x.Id == obj.Id);
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
