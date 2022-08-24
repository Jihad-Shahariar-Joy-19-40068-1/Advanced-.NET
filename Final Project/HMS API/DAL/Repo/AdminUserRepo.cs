using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminUserRepo:AdminIRepo<Registration, int>, AdmindoctorRepo<Registration, int>, AdminPatientRepo<Registration, int>
    {
        HospitalEntities db;
        public AdminUserRepo(HospitalEntities db)
        {
            this.db = db;
        }



        public bool Create(Registration obj)
        {
            db.Registrations.Add(obj);      //create 
            var res = db.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var exst = db.Registrations.FirstOrDefault(x => x.Id == id);
            if (exst != null)
            {
                db.Registrations.Remove(Get(id));       //delete
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Registration obj)
        {
            var exst = db.Registrations.FirstOrDefault(x => x.Id == obj.Id);
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(obj);    //update 
                db.SaveChanges();
                return true;
            }
            return false;
        }

        List<Registration> AdminIRepo<Registration, int>.Get()
        {
            return db.Registrations.ToList();
        }

        public Registration Get(int id)
        {
            var registration = db.Registrations.Find(id);    //get one
            if (registration != null)
            {
                return registration;
            }
            return null;
        }
        public List<Registration> Getdoc()
        {
            var alldoctor = (from p in db.Registrations
                             where p.Type.Equals("D")
                             select p).ToList();
            //get one
            if (alldoctor != null)
            {
                return alldoctor;
            }
            return null;
        }
        public int Dcccount()
        {
            var alldoctor = (from p in db.Registrations
                             where p.Type.Equals("D")
                             select p).ToList();
            //get one
            var doctorcount = alldoctor.Count();
            if (doctorcount != null)
            {
                return doctorcount;
            }
            return 0;
        }
        public int Patientcount()
        {
            var allpatient = (from p in db.Registrations
                              where p.Type.Equals("P")
                              select p).ToList();
            //get one
            var allpatientcount = allpatient.Count();
            if (allpatientcount != null)
            {
                return allpatientcount;
            }
            return 0;
        }
        public List<Registration> GetPatient()
        {
            var allpatient = (from p in db.Registrations
                              where p.Type.Equals("P")
                              select p).ToList();
            //get one
            if (allpatient != null)
            {
                return allpatient;
            }
            return null;

        }
    }
}
