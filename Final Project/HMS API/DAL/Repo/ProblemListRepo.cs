using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ProblemListRepo : IRepo<ProblemList, int, bool>
    {
        HospitalEntities db;

        public ProblemListRepo(HospitalEntities db)
        {
            this.db = db;
        }


        public bool Create(ProblemList obj)
        {
            db.ProblemLists.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var dlts = db.ProblemLists.FirstOrDefault(x => x.Id == id);
            if (dlts != null)
            {
                db.ProblemLists.Remove(dlts);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ProblemList> Get()
        {
            return db.ProblemLists.ToList();
        }

        public ProblemList Get(int id)
        {
            var single = db.ProblemLists.Find(id);
            if (single != null)
            {
                return single;
            }
            return null;
        }

        public bool Update(ProblemList obj)
        {
            var est = db.ProblemLists.FirstOrDefault(x => x.Id == obj.Id);
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
