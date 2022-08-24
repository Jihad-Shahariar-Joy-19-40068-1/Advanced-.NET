using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class DonorRepo : IRepo_Patient<Donor, int, bool>
    {
        HospitalEntities db;
        public DonorRepo(HospitalEntities db)
        {
            this.db = db;
        }
        public List<Donor> Get()
        {
            return db.Donors.ToList();
        }

        public Donor Get(int id)
        {
            var donor = db.Donors.Find(id);
            if (donor != null)
            {
                return donor;
            }
            return null;
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
        public bool Update(Donor obj)
        {
            var exst = db.Donors.FirstOrDefault(x => x.Id == obj.Id);
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
            var exst = db.Donors.FirstOrDefault(x => x.Id == id);
            if (exst != null)
            {
                db.Donors.Remove(exst);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
