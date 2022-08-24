using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminNoticeRepo : AdminIRepo<Notice, int>
    {

        HospitalEntities db;
        public AdminNoticeRepo(HospitalEntities db)
        {
            this.db = db;
        }

        public bool Create(Notice obj)
        {
            db.Notices.Add(obj);      //create 
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var exst = db.Notices.FirstOrDefault(x => x.Id == id);
            if (exst != null)
            {
                db.Notices.Remove(Get(id));       //delete
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
            var notice = db.Notices.Find(id);    //get one
            if (notice != null)
            {
                return notice;
            }
            return null;
        }

        public bool Update(Notice obj)
        {
            var exst = db.Notices.FirstOrDefault(x => x.Id == obj.Id);
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
