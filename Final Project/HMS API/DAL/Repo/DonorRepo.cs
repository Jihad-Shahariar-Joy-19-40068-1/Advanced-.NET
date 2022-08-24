using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DonorRepo : IRepo<Donor, int, bool>
    {
        HospitalEntities db;

        public DonorRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public bool Create(Donor obj)
        {
            db.Donors.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var dlts = db.Donors.FirstOrDefault(x => x.Id == id);
            if (dlts != null)
            {
                db.Donors.Remove(dlts);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Donor> Get()
        {
            return db.Donors.ToList();
        }

        public Donor Get(int id)
        {
            var single = db.Donors.Find(id);
            if (single != null)
            {
                return single;
            }
            return null;
        }

        public bool Update(Donor obj)
        {
            var est = db.Donors.FirstOrDefault(x => x.Id == obj.Id);
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
