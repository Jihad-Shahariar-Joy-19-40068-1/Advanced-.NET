using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminEpatientRepo : AdminIRepo<Epatient, int>
    {
        HospitalEntities db;
        public AdminEpatientRepo(HospitalEntities db)
        {
            this.db = db;
        }
        public bool Create(Epatient obj)
        {
            db.Epatients.Add(obj);      //create 
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var exst = db.Epatients.FirstOrDefault(x => x.Id == id);
            if (exst != null)
            {
                db.Epatients.Remove(Get(id));       //delete
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
            var notice = db.Epatients.Find(id);    //get one
            if (notice != null)
            {
                return notice;
            }
            return null;
        }

        public bool Update(Epatient obj)
        {
            var exst = db.Epatients.FirstOrDefault(x => x.Id == obj.Id);
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
