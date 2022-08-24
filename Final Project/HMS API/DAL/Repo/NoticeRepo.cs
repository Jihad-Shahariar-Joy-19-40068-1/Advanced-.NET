using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class NoticeRepo : IRepo<Notice, int, bool>
    {
        HospitalEntities db;

        public NoticeRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public bool Create(Notice obj)
        {
            db.Notices.Add(obj);
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var dlts = db.Notices.FirstOrDefault(x => x.Id == id);
            if (dlts != null)
            {
                db.Notices.Remove(dlts);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Notice> Get()
        {
            return db.Notices.ToList();
        }

        public Notice Get(int id)
        {
            var single = db.Notices.Find(id);
            if (single != null)
            {
                return single;
            }
            return null;
        }

        public bool Update(Notice obj)
        {
            var est = db.Notices.FirstOrDefault(x => x.Id == obj.Id);
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
